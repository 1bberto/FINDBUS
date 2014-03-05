using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FindBus.Models;
using System.Web;

namespace FindBus.Controllers
{
    public class AtualizacaoController : ApiController
    {
        /// <summary>
        /// Metodo responsavel por retornar para o usuario a versao do app e a versao da base que ele deve utilizar caso a 
        /// sua versao esteja diferente da versao que deve ser utilizada
        /// </summary>
        /// <param name="VersaoApp">Versao do aplicativo (Android)</param>
        /// <param name="VersaoBase">Versao da Base de dados do Aplicativo</param>
        /// <returns>objeto com a versao do aplicativo + url para download do app + versao da base + url para download da versao da base</returns>
        [HttpGet]
        public Atualizacao Atualizacao(string VersaoApp, string VersaoBase)
        {
            String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
            return new Atualizacao(VersaoApp, VersaoBase, strUrl);
        }
        
    }
}
