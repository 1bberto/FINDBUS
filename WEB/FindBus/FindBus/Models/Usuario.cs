using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        [Display(Name = "Login")]
        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { nomeUsuario = value; }
        }
        [Display(Name = "Senha")]
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        [Display(Name = "Nivel de Acesso")]
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

        public Usuario Login(string login, string senha)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                var usuario = (from p in fn.tblUsuario
                               where p.NomeUsuario.Equals(login) && p.UsuarioSenha.Equals(senha)
                               select p).SingleOrDefault();
                if (usuario != null)
                {
                    this.usuarioID = usuario.UsuarioID;
                    this.NomeUsuario = usuario.NomeUsuario;
                    this.senha = usuario.UsuarioSenha;
                    this.nivelAcesso = usuario.NiveldoAcesso;
                    this.dataInclusaoRegistro = usuario.DataInclusaoRegistro;
                }
                return this;
            }
        }
        public List<SelectListItem> RetornaNiveisAcesso()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Administrador", Value = "1" });
            items.Add(new SelectListItem { Text = "Comum", Value = "2" });
            return items;
        }

        public IEnumerable<Usuario> RetornaUsuarios()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                List<tblUsuario> tbUsuario = fn.tblUsuario.ToList<tblUsuario>();
                foreach (tblUsuario tbusu in tbUsuario)
                {
                    yield return new Usuario
                    {
                        UsuarioID = tbusu.UsuarioID,
                        NomeUsuario = tbusu.NomeUsuario,
                        Senha = tbusu.UsuarioSenha,
                        NivelAcesso = tbusu.NiveldoAcesso,
                        DataInclusaoRegistro = tbusu.DataInclusaoRegistro
                    };
                }
            }
        }
        public void InserirUsuario(Usuario usuario)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                fn.tblUsuario.Add(new tblUsuario { NomeUsuario = usuario.NomeUsuario, UsuarioSenha = usuario.Senha, NiveldoAcesso = usuario.NivelAcesso, DataInclusaoRegistro = usuario.DataInclusaoRegistro });
                fn.SaveChanges();
            }
        }
        public void AlterarUsuario(Usuario usuario)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                tblUsuario tbusuario = fn.tblUsuario.Find(usuario.UsuarioID);
                if (tbusuario != null)
                {
                    tbusuario.NomeUsuario = usuario.NomeUsuario;
                    tbusuario.UsuarioSenha = usuario.Senha;
                    tbusuario.NiveldoAcesso = usuario.NivelAcesso;
                    fn.SaveChanges();
                }
            }
        }
        public void ExcluirUsuario(int usuID)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                fn.tblUsuario.Remove(fn.tblUsuario.Find(usuID));
                fn.SaveChanges();
            }
        }
        public Usuario retornaUsuario(int usuID)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                tblUsuario tbusu = fn.tblUsuario.Find(usuID);
                return new Usuario
                {
                    UsuarioID = tbusu.UsuarioID,
                    NomeUsuario = tbusu.NomeUsuario,
                    Senha = tbusu.UsuarioSenha,
                    NivelAcesso = tbusu.NiveldoAcesso,
                    DataInclusaoRegistro = tbusu.DataInclusaoRegistro
                };
            }
        }
        public object VerificaNomeUsuario(string nomeUsuario)
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                int qtdRota = (from p in fn.tblUsuario
                               where p.NomeUsuario.Equals(nomeUsuario)
                               select p).Count();

                return qtdRota > 0 ? new { Retorno = true } : new { Retorno = false };
            }
        }
    }
}
