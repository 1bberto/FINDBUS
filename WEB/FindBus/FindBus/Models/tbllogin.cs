//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FindBus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbllogin
    {
        public int LoginId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioSenha { get; set; }
    
        public virtual tblusuario tblusuario { get; set; }
    }
}