﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class Atualizacao
    {
        public string VersaoAplicativo { get; set; }
        public string UrlAplicativo { get; set; }
        public string VersaoBase { get; set; }
        public string UrlBase { get; set; }
        
        public Atualizacao(string VersaoAplicativo, string VersaoBase, string urlServer)
        {
            FindBusEntities fn = new FindBusEntities();
            var retorno = (from p in fn.tblVersao
                           join bs in fn.tblBase on p.BaseID equals bs.BaseID
                           join app in fn.tblAplicativo on p.AplicativoID equals app.AplicativoID
                           select new
                           {
                               Versaoapp = app.VersaoAplicativo,
                               Urlapp = app.LocalAPK,
                               Versaobs = bs.VersaoBase,
                               Urlbase = bs.LocalBase
                           }).FirstOrDefault();

            if (retorno != null)
            {
                if (string.Compare(VersaoAplicativo, retorno.Versaoapp) == -1)
                {
                    this.VersaoAplicativo = retorno.Versaoapp;
                    this.UrlAplicativo = string.Format("{0}{1}", urlServer.Remove(urlServer.Length-1), retorno.Urlapp);
                }
                if (string.Compare(VersaoBase, retorno.Versaobs) == -1)
                {
                    this.VersaoBase = retorno.Versaobs;
                    this.UrlBase = string.Format("{0}{1}", urlServer.Remove(urlServer.Length - 1), retorno.Urlbase);
                }
            }
        }
    }
}