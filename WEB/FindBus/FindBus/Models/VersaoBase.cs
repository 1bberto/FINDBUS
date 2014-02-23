using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class VersaoBase
    {
        public int BaseID { get; set; }
        public string LocalBase { get; set; }
        public System.DateTime DataInclusaoRegistro { get; set; }
        public string versaoBase { get; set; }
    }
}