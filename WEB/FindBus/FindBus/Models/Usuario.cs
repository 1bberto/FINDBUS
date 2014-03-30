using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBus.Models
{
    public class Usuario
    {
        // Atributos
        private int usuarioID;
        private string nomeUsuario;
        private string senha;
        private int nivelAcesso;
        private DateTime dataInclusaoRegistro;

        // Propriedades
        public int UsuarioID
        {
            get { return usuarioID; }
            set { usuarioID = value; }
        }

        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { nomeUsuario = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public int NivelAcesso
        {
            get { return nivelAcesso; }
            set { nivelAcesso = value; }
        }

        public DateTime DataInclusaoRegistro
        {
            get { return dataInclusaoRegistro; }
            set { dataInclusaoRegistro = value; }
        }
        public Usuario()
        {
            UsuarioID = 0;
            NomeUsuario = string.Empty;
            Senha = string.Empty;
            NivelAcesso = 0;
            DataInclusaoRegistro = DateTime.Now;
        }

        findbusEntities fn = new findbusEntities();
        public Usuario Login(string login, string senha)
        {
            var usuario = (from p in fn.tblusuario
                           where p.NomeUsuario.Equals(login) && p.UsuarioSenha.Equals(senha)
                           select p).SingleOrDefault();
            if (usuario != null)
            {
                this.usuarioID = usuario.UsuarioId;
                this.NomeUsuario = usuario.NomeUsuario;
                this.senha = usuario.UsuarioSenha;
                this.nivelAcesso = usuario.NiveldoAcesso;
                this.dataInclusaoRegistro = usuario.DataInclusaoRegistro;
            }
            return this;
        }
    }
}
