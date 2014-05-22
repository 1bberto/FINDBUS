using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class PontoLocalizacao
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool PontoParada { get; set; }
        public int OrdemPonto { get; set; }
        public decimal DistanciaPontoAnterior { get; set; }


        public IEnumerable<PontoLocalizacao> RetornaPontosRota(int rotaID)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                var pontosRota = (from rota in fn.tblRotaPonto
                                  join ponto in fn.tblPonto on rota.PontoId equals ponto.PontoID
                                  where rota.RotaId == rotaID
                                  select new
                                  {
                                      latitude = ponto.Latitude,
                                      longitude = ponto.Longitude,
                                      pontoParada = ponto.PontoParada,
                                      ordemPonto = rota.OrdemPonto,
                                      distanciaProximoPonto = rota.DistanciaPontoAnterior
                                  }).ToList();


                foreach (var pontos in pontosRota)
                {
                    yield return new PontoLocalizacao
                    {
                        Latitude = pontos.latitude,
                        Longitude = pontos.longitude,
                        PontoParada = pontos.pontoParada,
                        OrdemPonto = pontos.ordemPonto,
                        DistanciaPontoAnterior = pontos.distanciaProximoPonto
                    };
                }
            }
        }
    }
}