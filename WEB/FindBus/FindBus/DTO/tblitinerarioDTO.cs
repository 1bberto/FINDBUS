using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindBus.DTO
{
    public class tblitinerarioDTO
    {
        public int ItinerarioId { get; set; }
        public int RotaId { get; set; }
        public string DiaSemana { get; set; }
        public string HoraSaida { get; set; }
        public string HoraChegada { get; set; }
    }
}
