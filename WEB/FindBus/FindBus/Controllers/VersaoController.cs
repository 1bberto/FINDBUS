using FindBus.Models;
using System;
using System.Collections.Generic;
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
            Versao ver = new Versao();
            ver.RetornaVersao();
            return View(ver);
        }
        public FileResult RetornaVersaoApp()
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

                string contentType = "application/vnd.android.package-archive";
                return File(string.Format("{0}",versaoAtual.VersaoAPK), contentType, "FindBus.apk");
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

