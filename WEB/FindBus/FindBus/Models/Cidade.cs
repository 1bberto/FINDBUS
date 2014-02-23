using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    public class Cidade
    {
        // Atributos        
        private int cidadeID;
        private string descricao;
        private string uf;
        private DateTime dataInclusaoRegistro;

        // Propriedades
        [DisplayName("Código")]
        public int CidadeID
        {
            get { return cidadeID; }
            set { cidadeID = value; }
        }
        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Descrição deve ser preenchida!")]
        [StringLength(50, ErrorMessage = "O nomde da cidade permite no máximo 50 caracteres!")]	       
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        [DisplayName("Estado")]
        [Required(ErrorMessage = "Estado deve Ser preenchido")]
        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }
        [DisplayName("Data Inclusão")]
        [DataType(DataType.Date)]
        public DateTime DataInclusaoRegistro
        {
            get { return dataInclusaoRegistro; }
            set { dataInclusaoRegistro = value; }
        }
    }
}
