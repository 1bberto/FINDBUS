using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    public class RotaPonto
    {
        // Atributos
        private int rotaPontoID;
        private int rotaID;
        private int pontoID;
        private int ordemPonto;
        private decimal quilometragem;

        // Propriedades
        public int RotaPontoID
        {
            get { return rotaPontoID; }
            set { rotaPontoID = value; }
        }

        public int RotaID
        {
            get { return rotaID; }
            set { rotaID = value; }
        }

        public int PontoID
        {
            get { return pontoID; }
            set { pontoID = value; }
        }

        public int OrdemPonto
        {
            get { return ordemPonto; }
            set { ordemPonto = value; }
        }

        public decimal Quilometragem
        {
            get { return quilometragem; }
            set { quilometragem = value; }
        }
    }
}
