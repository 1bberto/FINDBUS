using FindBus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    [Authorize]
    public class VersaoBaseController : Controller
    {
        //
        // GET: /VersaoBase/
        FindBusEntities fn;
        List<VersaoBase> versoesBase;
        public ActionResult Index()
        {
            fn = new FindBusEntities();
            versoesBase = new List<VersaoBase>();
            foreach (tblBase vbase in fn.tblBase.ToList())
            {
                versoesBase.Add(new VersaoBase() { BaseID = vbase.BaseID, versaoBase = vbase.VersaoBase, LocalBase = vbase.LocalBase, DataInclusaoRegistro = vbase.DataInclusaoRegistro });
            }
            return View(versoesBase);
        }
        public ActionResult AdicionarVersao()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdicionarVersaoBase()
        {
            try
            {
                fn = new FindBusEntities();
                string versao = Request.Form["versao"];
                tblBase novabase = (from bas in fn.tblBase
                                    where bas.VersaoBase.Contains(versao)
                                    select bas).FirstOrDefault<tblBase>();
                if (novabase == null)
                {
                    var path = Path.Combine(Server.MapPath("~/Mobile/Data/"), Request.Form["versao"].ToString());
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    new VersaoBase().GerarBaseDados(path);
                    fn.tblBase.Add(new tblBase() { VersaoBase = Request.Form["versao"].ToString(), LocalBase = string.Format(@"/Mobile/Data/{0}/{1}", Request.Form["versao"].ToString(), "data.json"), DataInclusaoRegistro = DateTime.Now });
                    fn.SaveChanges();
                    return Json("Versão de Base Inserida com Sucesso");
                }
                else
                {
                    return Json("Versão de Base Já Existente!");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }
        }
    }
}
