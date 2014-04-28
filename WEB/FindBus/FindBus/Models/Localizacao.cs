using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        public Localizacao(string Lat, string Long)
        {
            if (!string.IsNullOrEmpty(Lat) && !string.IsNullOrEmpty(Long))
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
                if (((Newtonsoft.Json.Linq.JValue)(((Newtonsoft.Json.Linq.JProperty)(obj.Last)).Value)).Value.Equals("OK"))
                {
                    foreach (JToken json in (obj["results"][0]["address_components"] as Newtonsoft.Json.Linq.JArray))
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
                    this.Latitude = Lat;
                    this.Longitude = Long;
                }
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
                    this.pontoId = fn.Database.SqlQuery<int>("exec [dbo].[USP_INS_PONTO] @Rua,@Cidade,@UF,@Bairro,@Rota,@Latitude,@Longitude,@PontoParada", parameters).ToList<int>()[0];                    
                    fn.tblRotaPonto.Add(new tblRotaPonto()
                    {
                        RotaId = fn.tblRota.First(x => x.Descricao == NomeRota).RotaID,
                        PontoId = this.pontoId,
                        DistanciaPontoAnterior = ponto.DistanciaProximoPonto,
                        OrdemPonto = ponto.OrdemPonto,
                    });
                    fn.SaveChanges();
                }
                catch (Exception ex)
                { }
            }
        }
    }
}