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
        public RotaItinerario() { }
        public List<USP_SEL_Itinerario_Result> RetornarItinerarioRota(int RotaEtinerarioID)
        {
            using (FindBusEntities db = new FindBusEntities())
            {
                List<USP_SEL_Itinerario_Result> itinerarios = new List<USP_SEL_Itinerario_Result>();
                USP_SEL_Itinerario_Result itinerario;
                foreach (USP_SEL_Itinerario_Result iti in db.USP_SEL_Itinerario(RotaEtinerarioID))
                {
                    itinerario = new USP_SEL_Itinerario_Result
                    {
                        rotaid = iti.rotaid,
                        Descricao = iti.Descricao,
                        HoraSaida = iti.HoraSaida,
                        HoraChegada = iti.HoraChegada,
                        Segunda = iti.Segunda,
                        Terca = iti.Terca,
                        Quarta = iti.Quarta,
                        Quinta = iti.Quinta,
                        Sexta = iti.Sexta,
                        Sabado = iti.Sabado,
                        Domingo = iti.Domingo
                    };
                    itinerarios.Add(itinerario);
                }
                return itinerarios;
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