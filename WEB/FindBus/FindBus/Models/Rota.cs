using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    public class Rota
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
        [Display(Name = "Rota")]
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
        public Rota()
        {

        }
    }
}
