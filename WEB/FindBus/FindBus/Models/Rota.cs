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
        private List<Itinerario> itinerario;
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
        public List<Itinerario> Etinerario
        {
            get { return itinerario; }
            set { itinerario = value; }
        }
        public Rota()
        {

        }
        public Rota(int rotaID)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                tblRota tbRota = fn.tblRota.Where(x => x.RotaID == rotaID).Single<tblRota>();
                this.rotaID = tbRota.RotaID;
                this.descricao = tbRota.Descricao;
            }
        }
        public object VerificaNomeRota(string nomeRota)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                int qtdRota = (from p in fn.tblRota
                               where p.Descricao.Equals(nomeRota)
                               select p).Count();

                return qtdRota > 0 ? new { Retorno = true } : new { Retorno = false };
            }
        }
    }
}
