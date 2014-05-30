using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    public class Itinerario
    {
        // Atributos
        private int itinerarioID;
        private string diaSemana;
        private DateTime horaSaida;
        private DateTime horaChegada;

        // Propriedades
        public int ItinerarioID
        {
            get { return itinerarioID; }
            set { itinerarioID = value; }
        }

        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }

        public DateTime HoraSaida
        {
            get { return horaSaida; }
            set { horaSaida = value; }
        }

        public DateTime HoraChegada
        {
            get { return horaChegada; }
            set { horaChegada = value; }
        }

        public void InserirItinerarioRota(USP_SEL_Itinerario_Result itinerario)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                RemoveItinerarioRota(itinerario, fn);
                if (Convert.ToBoolean(itinerario.Segunda))
                    InsereItinerarioDiaSemana(itinerario, fn, "Segunda-Feira");
                if (Convert.ToBoolean(itinerario.Terca))
                    InsereItinerarioDiaSemana(itinerario, fn, "Terca-Feira");
                if (Convert.ToBoolean(itinerario.Quarta))
                    InsereItinerarioDiaSemana(itinerario, fn, "Quarta-Feira");
                if (Convert.ToBoolean(itinerario.Quinta))
                    InsereItinerarioDiaSemana(itinerario, fn, "Quinta-Feira");
                if (Convert.ToBoolean(itinerario.Sexta))
                    InsereItinerarioDiaSemana(itinerario, fn, "Sexta-Feira");
                if (Convert.ToBoolean(itinerario.Sabado))
                    InsereItinerarioDiaSemana(itinerario, fn, "Sabado");
                if (Convert.ToBoolean(itinerario.Domingo))
                    InsereItinerarioDiaSemana(itinerario, fn, "Domingo");
            }
        }
        public void ExcluirItinerarioRota(USP_SEL_Itinerario_Result itinerario)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                RemoveItinerarioRota(itinerario, fn);
            }
        }
        private static void InsereItinerarioDiaSemana(USP_SEL_Itinerario_Result itinerario, FindBusEntities fn, string diaSemana)
        {
            fn.tblItinerario.Add(new tblItinerario
            {
                RotaID = itinerario.rotaid,
                DiaSemana = diaSemana,
                HoraSaida = itinerario.HoraSaida,
                HoraChegada = itinerario.HoraChegada
            });
            fn.SaveChanges();
        }

        private static void RemoveItinerarioRota(USP_SEL_Itinerario_Result itinerario, FindBusEntities fn)
        {
            IEnumerable<tblItinerario> itinerariosFora = fn.tblItinerario.Where(x => x.RotaID == itinerario.rotaid && x.HoraSaida.Equals(itinerario.HoraSaida) && x.HoraChegada.Equals(itinerario.HoraChegada));
            foreach (tblItinerario item in itinerariosFora)
            {
                fn.tblItinerario.Remove(item);
            }
            fn.SaveChanges();
        }
    }
}
