using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class RotaEtinerario
    {
        [Display(Name="Código")]        
        public int RotaEtinerarioID { get; set; }
        public Rota Rota { get; set; }
        public List<Etinerario> Etinerario { get; set; }
        public RotaEtinerario()
        {

        }
        public RotaEtinerario(int RotaEtinerarioID)
        {
            //db = new findbusEntities();
        }
        public IEnumerable<RotaEtinerario> RetornaRotas()
        {
            using (findbusEntities db = new findbusEntities())
            {
                var Rotas = (from rota in db.tblrota
                             join etinerario in db.tblitinerario on rota.RotaId equals etinerario.RotaId into et
                             from iti in et.DefaultIfEmpty()
                             select new
                             {
                                 rotaEtinerarioID = iti == null ? 0 : iti.ItinerarioId,
                                 rotaNome = rota.Descricao
                             }).ToList().OrderBy(x => x.rotaEtinerarioID);
                foreach (var rota in Rotas)
                {
                    yield return new RotaEtinerario() { RotaEtinerarioID = rota.rotaEtinerarioID, Rota = new Rota() { Descricao = rota.rotaNome } };
                }
            }
        }
    }

}