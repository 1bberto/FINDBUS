using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindBus.DTO
{
    public class tblusuarioDTO
    {
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string UsuarioSenha { get; set; }
        public string DataInclusaoRegistro { get; set; }
        public int NiveldoAcesso { get; set; }
    }
}
