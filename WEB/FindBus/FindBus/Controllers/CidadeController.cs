using FindBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBus.Controllers
{
    [Authorize]
    public class CidadeController : Controller
    {
        FindBusEntities fn = new FindBusEntities();
        //
        // GET: /Cidade/
        List<Cidade> cidades = new List<Cidade>();
        public ActionResult Index()
        {
            foreach (tblCidade cidade in fn.tblCidade.ToList())
            {
                cidades.Add(new Models.Cidade { CidadeID = cidade.CidadeID, Descricao = cidade.Descricao, Uf = cidade.UF, DataInclusaoRegistro = cidade.DataInclusaoRegistro });
            }
            return View(cidades);
        }
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cidade cidade)
        {
            if (string.IsNullOrEmpty(cidade.Descricao))
                return Json("Cidade deve ser preenchida");
            if (string.IsNullOrEmpty(cidade.Uf))
                return Json("Estado deve ser preenchido");
            tblCidade novacidade = (from cid in fn.tblCidade
                                    where cid.Descricao.Equals(cidade.Descricao) && cid.UF.Equals(cidade.Uf)
                                    select cid).FirstOrDefault<tblCidade>();
            if (novacidade != null)
            {
                return Json("Cidade Ja Cadastrada!");
            }
            else
            {
                fn.tblCidade.Add(new Models.tblCidade { Descricao = cidade.Descricao, UF = cidade.Uf, DataInclusaoRegistro = DateTime.Now });
                fn.SaveChanges();
                return Json("Cidade Cadastrada com Sucesso");
            }
        }

        public List<SelectListItem> RetornaUf()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Acre", Value = "AC" });
            items.Add(new SelectListItem { Text = "Alagoas", Value = "AL" });
            items.Add(new SelectListItem { Text = "Amapá", Value = "AP" });
            items.Add(new SelectListItem { Text = "Amazonas", Value = "AM" });
            items.Add(new SelectListItem { Text = "Bahia", Value = "BA" });
            items.Add(new SelectListItem { Text = "Ceará", Value = "CE" });
            items.Add(new SelectListItem { Text = "Distrito Federal", Value = "DF" });
            items.Add(new SelectListItem { Text = "Espirito Santo", Value = "ES" });
            items.Add(new SelectListItem { Text = "Goias", Value = "GO" });
            items.Add(new SelectListItem { Text = "Mato Grosso", Value = "MT" });
            items.Add(new SelectListItem { Text = "Mato Grosso do Sul", Value = "MS" });
            items.Add(new SelectListItem { Text = "Paraná", Value = "PR" });
            items.Add(new SelectListItem { Text = "Paraíba", Value = "PB" });
            items.Add(new SelectListItem { Text = "Para", Value = "PA" });
            items.Add(new SelectListItem { Text = "Pernambuco", Value = "PE" });
            items.Add(new SelectListItem { Text = "Piauí", Value = "PI" });
            items.Add(new SelectListItem { Text = "Rio de Janeiro", Value = "RJ" });
            items.Add(new SelectListItem { Text = "Rio Grande do Norte", Value = "RN" });
            items.Add(new SelectListItem { Text = "Rio Grande do Sul", Value = "RS" });
            items.Add(new SelectListItem { Text = "Rondonia", Value = "RO" });
            items.Add(new SelectListItem { Text = "Roraima", Value = "RR" });
            items.Add(new SelectListItem { Text = "Santa Catarina", Value = "SC" });
            items.Add(new SelectListItem { Text = "Sergipe", Value = "SE" });
            items.Add(new SelectListItem { Text = "São Paulo", Value = "SP" });
            items.Add(new SelectListItem { Text = "Tocatins", Value = "TO" }); return items;
        }
    }
}
