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
    
    public partial class tblRota
    {
        public tblRota()
        {
            this.tblItinerario = new HashSet<tblItinerario>();
            this.tblRotaPonto = new HashSet<tblRotaPonto>();
        }
    
        public int RotaID { get; set; }
        public string Descricao { get; set; }
        public System.DateTime DataInclusaoRegistro { get; set; }
    
        public virtual ICollection<tblItinerario> tblItinerario { get; set; }
        public virtual ICollection<tblRotaPonto> tblRotaPonto { get; set; }
    }
}
