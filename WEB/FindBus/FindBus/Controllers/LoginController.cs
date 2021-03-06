﻿using FindBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RealizaLogin(string Login, string Senha)
        {
            if (string.IsNullOrEmpty(Login))
            { return Json("Login deve ser Preenchida"); }
            if (string.IsNullOrEmpty(Senha))
            { return Json("Senha deve ser Preenchida"); }
            Usuario user = new Usuario().Login(Login, Senha);
            if ((!string.IsNullOrEmpty(user.NomeUsuario)) && (!string.IsNullOrEmpty(user.Senha)))
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(user.NomeUsuario, false);
                if (user.NivelAcesso == 1)
                    Session["CriaUsuario"] = true;
                return Json(string.Format("Seja Bem Vindo {0}", user.NomeUsuario));
            }
            else
            {
                System.Web.Security.FormsAuthentication.SignOut();
                Session["CriaUsuario"] = null;
                return Json("Usuario ou Senha Incorretos");
            }
        }
        public ActionResult LogOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["CriaUsuario"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}
