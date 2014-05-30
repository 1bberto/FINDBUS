using FindBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    [Authorize]
    public class LocalizacaoController : Controller
    {
        public ActionResult Index()
        {
            return View(new FindBusEntities().tblRota.ToList());
        }
        [HttpGet()]
        public ActionResult AlteraRota(int rotaID)
        {
            return View(new Rota(rotaID));
        }
        [HttpGet()]
        public ActionResult VisualizaRota(int rotaID)
        {
            return View(new Rota(rotaID));
        }
        public ActionResult AdicionaRota()
        {
            return View();
        }
        [HttpPost()]
        public ActionResult Excluir(int RotaID)
        {
            try
            {
                new Localizacao().ExcluirRota(RotaID);
                return Json("Rota Excluida com Sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet()]
        public ActionResult VerificaLocalizacao(string Lat, string Long)
        {
            Localizacao localizacao = new Localizacao(Lat, Long);

            return Json(localizacao, JsonRequestBehavior.AllowGet);
        }
        [HttpPost()]
        public ActionResult InserirRota(List<PontoLocalizacao> pontos, string NomeRota)
        {
            if (pontos != null)
            {
                using (FindBusEntities fn = new FindBusEntities())
                {
                    var pontosRota = (from p in fn.tblRotaPonto
                                      where p.tblRota.Descricao.Equals(NomeRota)
                                      select p).ToList<tblRotaPonto>();
                    foreach (tblRotaPonto rotaponto in pontosRota)
                        fn.tblRotaPonto.Remove(rotaponto);
                    fn.SaveChanges();
                }
                foreach (PontoLocalizacao ponto in pontos)
                {
                    Localizacao localizacao = new Localizacao(ponto.Latitude, ponto.Longitude);
                    localizacao.InserirLocalizacao(ponto, NomeRota);
                }
            }
            return Json("Rota Inserida Com Sucesso!");
        }

        [HttpGet()]
        public ActionResult RetornaPontosRota(int rotaID)
        {
            try
            {
                return Json(new PontoLocalizacao().RetornaPontosRota(rotaID).OrderBy(x => x.OrdemPonto), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet()]
        public ActionResult VerificaNomeRota(string nomeRota)
        {
            return Json(new Rota().VerificaNomeRota(nomeRota), JsonRequestBehavior.AllowGet);
        }
    }
}
