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
    
    public partial class tblrotaponto
    {
        public int RotaPontoId { get; set; }
        public int RotaId { get; set; }
        public int PontoId { get; set; }
        public int OrdemPonto { get; set; }
        public decimal Quilometragem { get; set; }
    
        public virtual tblrota tblrota { get; set; }
        public virtual tblponto tblponto { get; set; }
    }
}
