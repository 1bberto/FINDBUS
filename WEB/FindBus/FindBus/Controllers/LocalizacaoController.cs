using FindBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    public class LocalizacaoController : Controller
    {
        //
        // GET: /Localizacao/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet()]
        public ActionResult VerificaLocalizacao(string Lat, string Long)
        {
            Localizacao localizacao = new Localizacao(Lat, Long);

            return Json(localizacao,JsonRequestBehavior.AllowGet);
        }
        public ActionResult InserirRota(List<PontoLocalizacao> pontos,string NomeRota)
        {
            if (pontos != null)
            {
                foreach (PontoLocalizacao ponto in pontos)
                {
                    Localizacao localizacao = new Localizacao(ponto.Latitude, ponto.Longitude);
                    localizacao.InserirLocalizacao(ponto, NomeRota);                    
                }
            }
            return Json("Rota Inserida Com Sucesso!");
        }
    }
}
