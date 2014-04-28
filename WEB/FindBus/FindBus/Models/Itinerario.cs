using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    public class Itinerario
    {
        // Atributos
        private int itinerarioID;
        private string diaSemana;
        private DateTime horaSaida;
        private DateTime horaChegada;

        // Propriedades
        public int ItinerarioID
        {
            get { return itinerarioID; }
            set { itinerarioID = value; }
        }

        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }

        public DateTime HoraSaida
        {
            get { return horaSaida; }
            set { horaSaida = value; }
        }

        public DateTime HoraChegada
        {
            get { return horaChegada; }
            set { horaChegada = value; }
        }
    }
}
