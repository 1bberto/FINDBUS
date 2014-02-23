using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class VersaoApp
    {
        public int AppID { get; set; }
        public string Localapp { get; set; }
        public System.DateTime DataInclusaoRegistro { get; set; }
        public string versaoApp { get; set; }
    }
}