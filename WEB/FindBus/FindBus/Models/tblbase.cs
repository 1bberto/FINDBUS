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
    
    public partial class tblBase
    {
        public tblBase()
        {
            this.tblVersao = new HashSet<tblVersao>();
        }
    
        public int BaseID { get; set; }
        public string LocalBase { get; set; }
        public System.DateTime DataInclusaoRegistro { get; set; }
        public string VersaoBase { get; set; }
    
        public virtual ICollection<tblVersao> tblVersao { get; set; }
    }
}
