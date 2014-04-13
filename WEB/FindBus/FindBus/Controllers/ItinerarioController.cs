using FindBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    public class ItinerarioController : Controller
    {
        //
        // GET: /Etinerario/

        public ActionResult Index()
        {
            return View(new RotaEtinerario().RetornaRotas());
        }

    }
}
