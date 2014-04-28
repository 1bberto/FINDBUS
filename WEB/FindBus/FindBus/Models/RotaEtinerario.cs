using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class RotaItinerario
    {
        [Display(Name = "Código")]
        public int RotaItinerarioID { get; set; }
        public Rota Rota { get; set; }
        public List<Itinerario> Etinerario { get; set; }
        public RotaItinerario()
        {

        }
        public IEnumerable<USP_SEL_Itinerario_Result> RetornarItinerarioRota(int RotaEtinerarioID)
        {
            using (FindBusEntities db = new FindBusEntities())
            {
                foreach (USP_SEL_Itinerario_Result itinerario in db.USP_SEL_Itinerario(RotaEtinerarioID))
                {
                    yield return itinerario;
                }
            }
        }
        public IEnumerable<RotaItinerario> RetornaRotas()
        {
            using (FindBusEntities db = new FindBusEntities())
            {
                foreach (var rota in db.tblRota)
                {
                    yield return new RotaItinerario() { RotaItinerarioID = rota.RotaID, Rota = new Rota() { Descricao = rota.Descricao } };
                }
            }
        }
    }

}