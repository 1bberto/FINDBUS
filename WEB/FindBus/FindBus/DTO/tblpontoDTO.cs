using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindBus.DTO
{
    public class tblpontoDTO
    {
        public int PontoId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool PontoParada { get; set; }
        public string DataInclusaoRegistro { get; set; }
    }
}
