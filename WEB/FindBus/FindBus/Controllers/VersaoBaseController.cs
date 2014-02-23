﻿using FindBus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    public class VersaoBaseController : Controller
    {
        //
        // GET: /VersaoBase/
        findbusEntities fn;
        List<VersaoBase> versoesBase;
        public ActionResult Index()
        {
            fn = new findbusEntities();
            versoesBase = new List<VersaoBase>();
            foreach (tblbase vbase in fn.tblbase.ToList())
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
                fn = new findbusEntities();
                string versao = Request.Form["versao"];
                tblbase novabase = (from bas in fn.tblbase
                                    where bas.VersaoBase.Contains(versao)
                                    select bas).FirstOrDefault<tblbase>();
                if (novabase == null)
                {
                    HttpPostedFileBase baseFile = Request.Files[0];
                    if (baseFile != null && baseFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(baseFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Mobile/Data/"), Request.Form["versao"].ToString());
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        baseFile.SaveAs(string.Format("{0}/{1}", path, fileName));
                        fn.tblbase.Add(new tblbase() { VersaoBase = Request.Form["versao"].ToString(), LocalBase = string.Format(@"/Mobile/Data/{0}/{1}", Request.Form["versao"].ToString(), fileName), DataInclusaoRegistro = DateTime.Now });
                        fn.SaveChanges();
                    }
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