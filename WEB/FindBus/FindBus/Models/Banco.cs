using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FindBus.DTO;
using System.Collections;
namespace FindBus.Models
{
    public class Banco
    {
        public IEnumerable<tblaplicativoDTO> tblaplicativo;
        public IEnumerable<tblbairroDTO> tblbairro;
        public IEnumerable<tblbairroruaDTO> tblbairrorua;
        public IEnumerable<tblbaseDTO> tblbase;
        public IEnumerable<tblcidadeDTO> tblcidade;
        public IEnumerable<tblcidadebairroDTO> tblcidadebairro;
        public IEnumerable<tblitinerarioDTO> tblitinerario;
        public IEnumerable<tblloginDTO> tbllogin;
        public IEnumerable<tblpontoDTO> tblponto;
        public IEnumerable<tblrotaDTO> tblrota;
        public IEnumerable<tblrotapontoDTO> tblrotaponto;
        public IEnumerable<tblruaDTO> tblrua;
        public IEnumerable<tblruapontoDTO> tblruaponto;
        public IEnumerable<tblusuarioDTO> tblusuario;
        public IEnumerable<tblversaoDTO> tblversao;

        public Banco()
        {
            tblaplicativo = RetornaTblAplicativos();
            tblbairro = RetornaTblBairros();
            tblbairrorua = RetornaTblBairroRuas();
            tblbase = RetornaTblBases();
            tblcidade = RetornaTblCidades();
            tblcidadebairro = RetornaTblCidadeBairros();
            tblitinerario = RetornaTblItinerarios();
            tbllogin = RetornaTblLogin();
            tblponto = RetornaTblPonto();
            tblrota = RetornaTblRotas();
            tblrotaponto = RetornaTblRotaPontos();
            tblrua = RetornaTblRuas();
            tblruaponto = RetornaTblRuaPontos();
            tblusuario = RetornaTblUsuarios();
            tblversao = RetornaTblVersoes();
        }

        private IEnumerable<tblversaoDTO> RetornaTblVersoes()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblversao.ToList())
                {
                    yield return new tblversaoDTO()
                    {
                        AplicativoID = item.AplicativoID,
                        BaseID = item.BaseID,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblusuarioDTO> RetornaTblUsuarios()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblusuario.ToList())
                {
                    yield return new tblusuarioDTO()
                    {
                        UsuarioId = item.UsuarioId,
                        NomeUsuario = item.NomeUsuario,
                        NiveldoAcesso = item.NiveldoAcesso,
                        UsuarioSenha = item.UsuarioSenha,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblruapontoDTO> RetornaTblRuaPontos()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblruaponto.ToList())
                {
                    yield return new tblruapontoDTO()
                    {
                        RuaPontoId = item.RuaPontoId,
                        PontoId = item.PontoId,
                        RuaId = item.RuaId
                    };
                }
            }
        }

        private IEnumerable<tblruaDTO> RetornaTblRuas()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblrua.ToList())
                {
                    yield return new tblruaDTO()
                    {
                        RuaId = item.RuaId,
                        Descricao = item.Descricao,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblrotapontoDTO> RetornaTblRotaPontos()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblrotaponto.ToList())
                {
                    yield return new tblrotapontoDTO()
                    {
                        RotaPontoId = item.RotaPontoId,
                        PontoId = item.PontoId,
                        RotaId = item.RotaId,
                        Quilometragem = item.Quilometragem,
                        OrdemPonto = item.OrdemPonto
                    };
                }
            }
        }

        private IEnumerable<tblrotaDTO> RetornaTblRotas()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblrota.ToList())
                {
                    yield return new tblrotaDTO()
                    {
                        RotaId = item.RotaId,
                        Descricao = item.Descricao,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblpontoDTO> RetornaTblPonto()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblponto.ToList())
                {
                    yield return new tblpontoDTO()
                    {
                        PontoId = item.PontoId,
                        PontoParada = item.PontoParada,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblloginDTO> RetornaTblLogin()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tbllogin.ToList())
                {
                    yield return new tblloginDTO()
                    {
                        LoginId = item.LoginId,
                        UsuarioId = item.UsuarioId,
                        UsuarioSenha = item.UsuarioSenha
                    };
                }
            }
        }

        private IEnumerable<tblitinerarioDTO> RetornaTblItinerarios()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblitinerario.ToList())
                {
                    yield return new tblitinerarioDTO()
                    {
                        ItinerarioId = item.ItinerarioId,
                        RotaId = item.RotaId,
                        DiaSemana = item.DiaSemana,
                        HoraSaida = item.HoraSaida,
                        HoraChegada = item.HoraChegada
                    };
                }
            }
        }

        private IEnumerable<tblcidadebairroDTO> RetornaTblCidadeBairros()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblcidadebairro.ToList())
                {
                    yield return new tblcidadebairroDTO()
                    {
                        CidadeBairroId = item.CidadeBairroId,
                        CidadeId = item.CidadeId,
                        BairroId = item.BairroId
                    };
                }
            }
        }

        private IEnumerable<tblcidadeDTO> RetornaTblCidades()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblcidade.ToList())
                {
                    yield return new tblcidadeDTO()
                    {
                        CidadeId = item.CidadeId,
                        Descricao = item.Descricao,
                        Uf = item.Uf,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblbaseDTO> RetornaTblBases()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblbase.ToList())
                {
                    yield return new tblbaseDTO()
                    {
                        BaseID = item.BaseID,
                        LocalBase = item.LocalBase,
                        VersaoBase = item.VersaoBase,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblbairroruaDTO> RetornaTblBairroRuas()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblbairrorua.ToList())
                {
                    yield return new tblbairroruaDTO()
                    {
                        BairroRuaId = item.BairroRuaId,
                        BairroId = item.BairroId,
                        RuaId = item.RuaId
                    };
                }
            }
        }

        private IEnumerable<tblbairroDTO> RetornaTblBairros()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblbairro.ToList())
                {
                    yield return new tblbairroDTO()
                    {
                        BairroId = item.BairroId,
                        Descricao = item.Descricao,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }

        private IEnumerable<tblaplicativoDTO> RetornaTblAplicativos()
        {
            using (findbusEntities fn = new findbusEntities())
            {
                foreach (var item in fn.tblaplicativo.ToList())
                {
                    yield return new tblaplicativoDTO()
                    {
                        AplicativoID = item.AplicativoID,
                        LocalAPK = item.LocalAPK,
                        VersaoAplicativo = item.VersaoAplicativo,
                        DataInclusaoRegistro = item.DataInclusaoRegistro
                    };
                }
            }
        }
    }
}