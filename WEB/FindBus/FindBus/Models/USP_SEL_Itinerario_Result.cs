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
using System.ComponentModel.DataAnnotations;
    
    public partial class USP_SEL_Itinerario_Result
    {
        [Display(Name="RotaID")]
        public int rotaid { get; set; }
        [Display(Name = "Nome Rota")]
        public string Descricao { get; set; }
        [Display(Name = "Hora Saida")]
        public string HoraSaida { get; set; }
        [Display(Name = "Hora Chegada")]
        public string HoraChegada { get; set; }
        [Display(Name = "Segunda")]
        public string Segunda { get; set; }
        [Display(Name = "Ter�a")]
        public string Terca { get; set; }
        [Display(Name = "Quarta")]
        public string Quarta { get; set; }
        [Display(Name = "Quinta")]
        public string Quinta { get; set; }
        [Display(Name = "Sexta")]
        public string Sexta { get; set; }
        [Display(Name = "S�bado")]
        public string Sabado { get; set; }
        [Display(Name = "Domingo")]
        public string Domingo { get; set; }

    }
}
