using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public Localizacao(string Lat, string Long)
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
        public void InserirLocalizacao()
        {
            using (findbusEntities bd = new findbusEntities())
            {
                tblponto ponto = bd.tblponto.SingleOrDefault(x => x.Latitude.Equals(this.Latitude) && x.Longitude.Equals(this.Longitude));
                if (ponto != null)
                {
 
                }




                tblcidade cidade = bd.tblcidade.SingleOrDefault(x => x.Uf.Equals(this.Estado) && x.Descricao.Equals(this.Cidade));
                tblbairro bairro = bd.tblbairro.SingleOrDefault(x => x.Descricao.Equals(this.Bairro));
                tblrua rua = bd.tblrua.SingleOrDefault(x => x.Descricao.Equals(this.Rua));
            }

        }
    }
}