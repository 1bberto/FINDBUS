using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    class Rota
    {
        // Atributos
        private int rotaID;
        private string descricao;
        private DateTime dataInclusaoRegistro;
        private List<Etinerario> etinerario;
        private List<RotaPonto> pontos;


        // Propriedades
        public List<RotaPonto> Pontos
        {
            get { return pontos; }
            set { pontos = value; }
        }

        public int RotaID
        {
            get { return rotaID; }
            set { rotaID = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public DateTime DataInclusaoRegistro
        {
            get { return dataInclusaoRegistro; }
            set { dataInclusaoRegistro = value; }
        }
        public List<Etinerario> Etinerario
        {
            get { return etinerario; }
            set { etinerario = value; }
        }
    }
}
