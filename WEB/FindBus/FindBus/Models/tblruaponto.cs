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
    
    public partial class tblruaponto
    {
        public int RuaPontoId { get; set; }
        public int RuaId { get; set; }
        public int PontoId { get; set; }
    
        public virtual tblponto tblponto { get; set; }
        public virtual tblrua tblrua { get; set; }
    }
}
