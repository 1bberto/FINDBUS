﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using System.IO;

namespace FindBus.Models
{
    public class VersaoBase
    {
        public int BaseID { get; set; }
        public string LocalBase { get; set; }
        public System.DateTime DataInclusaoRegistro { get; set; }
        [Display(Name = "Versão Base")]
        public string versaoBase { get; set; }


        public void GerarBaseDados(string local)
        {
            using (findbusEntities fn = new findbusEntities())
            {
                using (StreamWriter outfile = new StreamWriter(string.Format("{0}\\{1}", local, "data.json")))
                    outfile.Write(JsonConvert.SerializeObject(new Banco()));
            }
        }
    }
}