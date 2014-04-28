using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace FindBus.Models
{
    public class Versao
    {
        [DisplayName("Versão Aplicativo")]
        public string VersaoAPK { get; set; }
        [DisplayName("Versão Base")]
        public string VersaoBase { get; set; }
        [DisplayName("Data Ultima Atualização")]
        public DateTime? DataInclusaoRegistro { get; set; }

        FindBusEntities fn = new FindBusEntities();

        public Versao()
        {
            this.VersaoAPK = null;
            this.VersaoBase = null;
            this.DataInclusaoRegistro = null;
        }
        public Versao RetornaVersao()
        {
            var versaoAtual = (from ver in fn.tblVersao
                               join app in fn.tblAplicativo on ver.AplicativoID equals app.AplicativoID
                               join bas in fn.tblBase on ver.BaseID equals bas.BaseID
                               select new
                               {
                                   VersaoAPK = app.VersaoAplicativo,
                                   VersaoBase = bas.VersaoBase,
                                   DataInclusaoRegistro = ver.DataInclusaoRegistro
                               }
                         ).FirstOrDefault();
            if (versaoAtual != null)
            {
                this.VersaoAPK = versaoAtual.VersaoAPK;
                this.VersaoBase = versaoAtual.VersaoBase;
                this.DataInclusaoRegistro = versaoAtual.DataInclusaoRegistro;
            }
            return this;
        }
        public List<SelectListItem> RetornaVersoesApp()
        {
            List<SelectListItem> versoesApp = new List<SelectListItem>();
            foreach (tblAplicativo app in fn.tblAplicativo.ToList())
            {
                if (app.AplicativoID == (fn.tblVersao.Count() == 0 ? 0 : fn.tblVersao.First().AplicativoID))
                    versoesApp.Add(new SelectListItem { Text = app.VersaoAplicativo.ToString(), Value = app.AplicativoID.ToString(), Selected = true });
                else
                    versoesApp.Add(new SelectListItem { Text = app.VersaoAplicativo.ToString(), Value = app.AplicativoID.ToString(), Selected = false });
            }
            return versoesApp;
        }
        public List<SelectListItem> RetornaVersoesBase()
        {
            List<SelectListItem> versoesBase = new List<SelectListItem>();
            foreach (tblBase bas in fn.tblBase.ToList())
            {
                if (bas.BaseID == (fn.tblVersao.Count() == 0 ? 0 : fn.tblVersao.First().BaseID))
                    versoesBase.Add(new SelectListItem { Text = bas.VersaoBase.ToString(), Value = bas.BaseID.ToString(), Selected = true });
                else
                    versoesBase.Add(new SelectListItem { Text = bas.VersaoBase.ToString(), Value = bas.BaseID.ToString(), Selected = false });
            }
            return versoesBase;
        }
        public string RetornaUrlRoot()
        {
            return string.Format("{0}://{1}:{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port);
        }
    }
}