using FindBus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    public class VersaoAppController : Controller
    {
        //
        // GET: /VersaoBase/
        findbusEntities fn;
        List<VersaoApp> versoesBase;
        public ActionResult Index()
        {
            fn = new findbusEntities();
            versoesBase = new List<VersaoApp>();
            foreach (tblaplicativo vapp in fn.tblaplicativo.ToList())
            {
                versoesBase.Add(new VersaoApp() { AppID = vapp.AplicativoID, versaoApp = vapp.VersaoAplicativo, Localapp = vapp.LocalAPK, DataInclusaoRegistro = vapp.DataInclusaoRegistro });
            }
            return View(versoesBase);
        }
        public ActionResult AdicionarVersao()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdicionarVersaoApp()
        {
            try
            {
                fn = new findbusEntities();
                string versao = Request.Form["versao"];
                tblaplicativo novabase = (from bas in fn.tblaplicativo
                                          where bas.VersaoAplicativo.Contains(versao)
                                          select bas).FirstOrDefault<tblaplicativo>();
                if (novabase == null)
                {
                    HttpPostedFileBase baseFile = Request.Files[0];
                    if (baseFile != null && baseFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(baseFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Mobile/App/"), Request.Form["versao"].ToString());
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        baseFile.SaveAs(string.Format("{0}/{1}", path, fileName));
                        fn.tblaplicativo.Add(new tblaplicativo() { VersaoAplicativo = Request.Form["versao"].ToString(), LocalAPK = string.Format(@"/Mobile/App/{0}/{1}", Request.Form["versao"].ToString(), fileName), DataInclusaoRegistro = DateTime.Now });
                        fn.SaveChanges();
                    }
                    return Json("Versão do App Inserida com Sucesso");
                }
                else
                {
                    return Json("Versão do App Já Existente!");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }
        }

    }
}
