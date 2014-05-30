using FindBus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{

    public class VersaoController : Controller
    {
        FindBusEntities fn = new FindBusEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View(new Versao().RetornaVersao());
        }
        public ActionResult RetornaVersaoApp()
        {
            using (fn = new FindBusEntities())
            {
                var versaoAtual = (from ver in fn.tblVersao
                                   join app in fn.tblAplicativo on ver.AplicativoID equals app.AplicativoID
                                   select new
                                   {
                                       VersaoAPK = app.LocalAPK
                                   }
                        ).FirstOrDefault();

                if (versaoAtual != null)
                {
                    return new FileStreamResult(new FileStream(string.Format("{0}{1}", Server.MapPath("/"), versaoAtual.VersaoAPK), FileMode.Open), "application/vnd.android.package-archive")
                    {
                        FileDownloadName = "FindBus.apk"
                    };
                }
                else
                    return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public ActionResult AlterarVersao()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AlterarVersao(string VersaoAPK, string VersaoBase)
        {
            try
            {
                tblVersao versaoAtual = fn.tblVersao.SingleOrDefault();
                if (versaoAtual != null)
                {
                    fn.tblVersao.Remove(versaoAtual);
                    fn.tblVersao.Add(new tblVersao
                    {
                        AplicativoID = Convert.ToInt32(VersaoAPK),
                        BaseID = Convert.ToInt32(VersaoBase),
                        DataInclusaoRegistro = DateTime.Now
                    });
                    fn.SaveChanges();
                }
                else
                {
                    fn.tblVersao.Add(new tblVersao
                    {
                        AplicativoID = Convert.ToInt32(VersaoAPK),
                        BaseID = Convert.ToInt32(VersaoBase),
                        DataInclusaoRegistro = DateTime.Now
                    });
                    fn.SaveChanges();
                }
                return Json("Versão Atualizada Com Sucesso");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}

