using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace FindBus.Models
{
    public class Localizacao
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        private string urlGoogle = "http://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&sensor=true";
        private int pontoId;
        public Localizacao()
        {

        }
        public Localizacao(string Lat, string Long)
        {

            try
            {
                if (!string.IsNullOrEmpty(Lat) && !string.IsNullOrEmpty(Long))
                {
                    using (FindBusEntities fn = new FindBusEntities())
                    {
                        var localizacao = (from p in fn.tblPonto
                                           where p.Longitude.Equals(Long) && p.Latitude.Equals(Lat)
                                           select p
                                           ).SingleOrDefault<tblPonto>();
                        if (localizacao == null)
                        {
                            Lat = Lat.Replace(',', '.');
                            Long = Long.Replace(',', '.');
                            WebRequest request = WebRequest.Create(string.Format(urlGoogle, Lat, Long));
                            request.Method = "GET";
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            string s = response.ToString();
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            String jsonresponse = string.Empty;
                            String temp = null;
                            while ((temp = reader.ReadLine()) != null)
                            {
                                jsonresponse += temp;
                            }
                            JObject obj = JObject.Parse(jsonresponse);
                            JArray array = (JArray)obj["results"];
                            if (((Newtonsoft.Json.Linq.JValue)(((Newtonsoft.Json.Linq.JProperty)(obj.Last)).Value)).Value.Equals("OK"))
                            {
                                for (int i = 0; i < array.Count(); i++)
                                {
                                    foreach (JToken json in (obj["results"][i]["address_components"] as Newtonsoft.Json.Linq.JArray))
                                    {
                                        foreach (JToken Tipo in ((json["types"] as Newtonsoft.Json.Linq.JArray)))
                                        {
                                            if (Tipo.ToString().Contains("route"))
                                            {
                                                this.Rua = json["long_name"].ToString();
                                            }
                                            if (Tipo.ToString().Contains("neighborhood"))
                                            {
                                                this.Bairro = json["long_name"].ToString();
                                            }
                                            if (Tipo.ToString().Contains("locality"))
                                            {
                                                this.Cidade = json["long_name"].ToString();
                                            }
                                            if (Tipo.ToString().Contains("administrative_area_level_1"))
                                            {
                                                this.Estado = json["short_name"].ToString();
                                            }
                                        }
                                    }
                                }
                                this.Latitude = Lat;
                                this.Longitude = Long;
                            }
                        }
                        else
                        {
                            var loc = (from a in fn.tblPonto
                                       join b in fn.tblRuaPonto on a.PontoID equals b.PontoID
                                       join c in fn.tblRua on b.RuaID equals c.RuaID
                                       join d in fn.tblBairroRua on c.RuaID equals d.RuaID
                                       join e in fn.tblBairro on d.BairroID equals e.BairroID
                                       join f in fn.tblCidadeBairro on e.BairroID equals f.BairroID
                                       join g in fn.tblCidade on f.CidadeID equals g.CidadeID
                                       where a.Longitude.Equals(localizacao.Longitude) && a.Latitude.Equals(localizacao.Latitude)
                                       select new
                                       {
                                           Lati = a.Latitude,
                                           Longi = a.Longitude,
                                           rua = c.Descricao,
                                           bairro = e.Descricao,
                                           cidade = g.Descricao,
                                           estado = g.UF
                                       }
                                      ).SingleOrDefault();
                            this.Latitude = loc.Lati;
                            this.Longitude = loc.Longi;
                            this.Rua = loc.rua;
                            this.Bairro = loc.bairro;
                            this.Cidade = loc.cidade;
                            this.Estado = loc.estado;
                        }
                        if (string.IsNullOrEmpty(this.Bairro) || string.IsNullOrEmpty(this.Cidade) || string.IsNullOrEmpty(this.Estado))
                            throw new Exception("Ponto Nao Encontrado no Google favor Comece Novamente!!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InserirLocalizacao(PontoLocalizacao ponto, string NomeRota)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                try
                {
                    var parameters = new DbParameter[] { 
                        new SqlParameter { ParameterName = "Rua", Value = this.Rua },
                        new SqlParameter { ParameterName = "Cidade", Value = this.Cidade },
                        new SqlParameter { ParameterName = "UF", Value = this.Estado },
                        new SqlParameter { ParameterName = "Bairro", Value = this.Bairro },
                        new SqlParameter { ParameterName = "Rota", Value =NomeRota },
                        new SqlParameter { ParameterName = "Latitude", Value = ponto.Latitude },
                        new SqlParameter { ParameterName = "Longitude", Value = ponto.Longitude },
                        new SqlParameter { ParameterName = "PontoParada", Value = ponto.PontoParada }
                    };
                    this.pontoId = fn.USP_INS_PONTO(this.Rua, this.Cidade, this.Estado, this.Bairro, NomeRota, ponto.Latitude, ponto.Longitude, ponto.PontoParada);
                    this.pontoId = fn.Database.SqlQuery<int>("exec [dbo].[USP_INS_PONTO] @Rua,@Cidade,@UF,@Bairro,@Rota,@Latitude,@Longitude,@PontoParada", parameters).ToList<int>()[0];
                    fn.tblRotaPonto.Add(new tblRotaPonto()
                    {
                        RotaId = fn.tblRota.First(x => x.Descricao == NomeRota).RotaID,
                        PontoId = this.pontoId,
                        DistanciaPontoAnterior = ponto.DistanciaPontoAnterior,
                        OrdemPonto = ponto.OrdemPonto,
                    });
                    fn.SaveChanges();
                }
                catch (Exception ex)
                { }
            }
        }
        public List<tblRotaPonto> RetornaPontosRota(int RotaID)
        {
            return new FindBusEntities().tblRotaPonto.Where(x => x.RotaId == RotaID).ToList<tblRotaPonto>();
        }
        public void ExcluirRota(int rotaid)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                var pontos = fn.tblRotaPonto.Where(x => x.RotaId == rotaid);
                foreach (tblRotaPonto ponto in pontos)
                    fn.tblRotaPonto.Remove(ponto);
                var rotas = fn.tblRota.Where(x => x.RotaID == rotaid);
                foreach (tblRota rota in rotas)
                    fn.tblRota.Remove(rota);
                fn.SaveChanges();
            }
        }
    }
}