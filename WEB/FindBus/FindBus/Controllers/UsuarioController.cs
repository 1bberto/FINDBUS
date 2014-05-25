using FindBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            if (Session["CriaUsuario"] != null)
                return View(new Usuario().RetornaUsuarios());
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpGet()]
        public ActionResult AlterarUsuario(int usuID)
        {
            if (Session["CriaUsuario"] != null)
                return View(new Usuario().retornaUsuario(usuID));
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost()]
        public ActionResult AlterarUsuario(Usuario usuario)
        {
            if (Session["CriaUsuario"] != null)
            {
                new Usuario().AlterarUsuario(usuario);
                return Json("Usuario Alterado com Sucesso", JsonRequestBehavior.AllowGet);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Excluir(int usuID)
        {
            if (Session["CriaUsuario"] != null)
            {
                new Usuario().ExcluirUsuario(usuID);
                return Json("Usuario Excluido com Sucesso");
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpGet()]
        public ActionResult AdicionarUsuario()
        {
            if (Session["CriaUsuario"] != null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost()]
        public ActionResult AdicionarUsuario(Usuario usuario)
        {
            if (Session["CriaUsuario"] != null)
            {
                new Usuario().InserirUsuario(usuario);
                return Json("Usuário Incluído com Sucesso!", JsonRequestBehavior.AllowGet);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpGet()]
        public ActionResult VerificaNomeUsuario(string nomeUsuario)
        {
            return Json(new Usuario().VerificaNomeUsuario(nomeUsuario), JsonRequestBehavior.AllowGet);
        }
    }
}
