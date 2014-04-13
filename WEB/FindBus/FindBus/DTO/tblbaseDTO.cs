using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindBus.DTO
{
    public class tblbaseDTO
    {
        public int BaseID { get; set; }
        public string LocalBase { get; set; }
        public System.DateTime DataInclusaoRegistro { get; set; }
        public string VersaoBase { get; set; }
    }
}
