using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    class Rua : Bairro
    {
        // Atributos
        private int ruaID;
        private string descricao;
        private DateTime dataInclusaoRegistro;

        // Propriedades
        public int RuaID
        {
            get { return ruaID; }
            set { ruaID = value; }
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
