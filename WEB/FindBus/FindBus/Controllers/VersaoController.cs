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
        findbusEntities fn = new findbusEntities();
        // GET: /Versao/        
        public ActionResult Index()
        {
            return View(new Versao().RetornaVersao());
        }
        public ActionResult RetornaVersaoApp()
        {
            using (fn = new findbusEntities())
            {
                var versaoAtual = (from ver in fn.tblversao
                                   join app in fn.tblaplicativo on ver.AplicativoID equals app.AplicativoID
                                   select new
                                   {
                                       VersaoAPK = app.LocalAPK
                                   }
                        ).FirstOrDefault();

                if (versaoAtual != null)
                {
                    return new FileStreamResult(new FileStream(string.Format("{0}{1}",Server.MapPath("/"), versaoAtual.VersaoAPK), FileMode.Open), "application/vnd.android.package-archive")
                    {
                        FileDownloadName = "FindBus.apk"
                    };
                }
                else
                    return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult AlterarVersao()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AlterarVersao(string VersaoAPK, string VersaoBase)
        {
            try
            {
                tblversao versaoAtual = fn.tblversao.SingleOrDefault();
                if (versaoAtual != null)
                {
                    fn.tblversao.Remove(versaoAtual);
                    fn.tblversao.Add(new tblversao
                    {
                        AplicativoID = Convert.ToInt32(VersaoAPK),
                        BaseID = Convert.ToInt32(VersaoBase),
                        DataInclusaoRegistro = DateTime.Now
                    });
                    fn.SaveChanges();
                }
                else
                {
                    fn.tblversao.Add(new tblversao
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

