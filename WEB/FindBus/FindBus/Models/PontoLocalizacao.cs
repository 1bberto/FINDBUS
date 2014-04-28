using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class PontoLocalizacao
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool PontoParada { get; set; }
        public int OrdemPonto { get; set; }
        public decimal DistanciaProximoPonto { get; set; }
    }
}