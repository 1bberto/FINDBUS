using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    class Ponto : Rua
    {
        // Atributos
        private int pontoID;
        private double latitude;
        private double longitude;
        private bool pontoParada;
        private DateTime dataInclusaoRegistro;

        // Propriedades
        public int PontoID
        {
            get { return pontoID; }
            set { pontoID = value; }
        }

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public bool PontoParada
        {
            get { return pontoParada; }
            set { pontoParada = value; }
        }

        public DateTime DataInclusaoRegistro
        {
            get { return dataInclusaoRegistro; }
            set { dataInclusaoRegistro = value; }
        }
    }
}
