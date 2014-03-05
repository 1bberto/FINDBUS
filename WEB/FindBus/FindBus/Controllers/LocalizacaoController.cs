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
        public ActionResult VerificaLocalizacao(string Lat, string Long)
        {
            Localizacao localizacao = new Localizacao(Lat, Long);

            return Json(localizacao);
        }
        public ActionResult InserirRota(List<PontoLocalizacao> pontos)
        {
            foreach (PontoLocalizacao ponto in pontos)
            {
                Localizacao localizacao = new Localizacao(ponto.Latitude, ponto.Longitude);
                localizacao.InserirLocalizacao();
            }
            return Json("MAOIIIIIIII");
        }
    }
}
