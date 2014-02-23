using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    class Bairro : Cidade
    {
        // Atributos
        private int bairroID;
        private string descricao;
        private DateTime dataInclusaoRegistro;

        // Propriedades
        public int BairroID
        {
            get { return bairroID; }
            set { bairroID = value; }
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
    }
}
