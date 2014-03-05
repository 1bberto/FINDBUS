using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    public class Etinerario
    {
        // Atributos
        private int etinerarioID;
        private string diaSemana;
        private DateTime horaSaida;
        private DateTime horaChegada;

        // Propriedades
        public int EtinerarioID
        {
            get { return etinerarioID; }
            set { etinerarioID = value; }
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
