using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindBus.DTO
{
    public class tblrotapontoDTO
    {
        public int RotaPontoId { get; set; }
        public int RotaId { get; set; }
        public int PontoId { get; set; }
        public int OrdemPonto { get; set; }
        public decimal Quilometragem { get; set; }
    }
}
