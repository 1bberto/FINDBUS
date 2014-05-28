using FindBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    [Authorize]
    public class ItinerarioController : Controller
    {
        //
        // GET: /Etinerario/

        public ActionResult Index()
        {
            return View(new RotaItinerario().RetornaRotas());
        }
        [HttpGet()]
        public ActionResult ConsultaItinerario(int ItinerarioID)
        {
            //return Json(new RotaItinerario().RetornarItinerarioRota(ItinerarioID), JsonRequestBehavior.AllowGet);
            return Json(new RotaItinerario().RetornarItinerarioRota(ItinerarioID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult RetornaItinerarioRota(int rotaID)
        {
            return PartialView("RetornaItinerarioRota", new RotaItinerario().RetornarItinerarioRota(rotaID));
        }
        [HttpPost()]
        public ActionResult InserirItinerarioRota(USP_SEL_Itinerario_Result itinerario)
        {
            new Itinerario().InserirItinerarioRota(itinerario);
            return Json("Itinerário Incluido com Sucesso!", JsonRequestBehavior.AllowGet);
        }
    }
}
