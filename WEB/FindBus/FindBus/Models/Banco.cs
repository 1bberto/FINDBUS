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
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblVersao.ToList())
                {
                    yield return new tblversaoDTO()
                    {
                        AplicativoID = item.AplicativoID,
                        BaseID = item.BaseID,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblusuarioDTO> RetornaTblUsuarios()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblUsuario.ToList())
                {
                    yield return new tblusuarioDTO()
                    {
                        UsuarioId = item.UsuarioID,
                        NomeUsuario = item.NomeUsuario,
                        NiveldoAcesso = item.NiveldoAcesso,
                        UsuarioSenha = item.UsuarioSenha,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblruapontoDTO> RetornaTblRuaPontos()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblRuaPonto.ToList())
                {
                    yield return new tblruapontoDTO()
                    {
                        RuaPontoId = item.RuaPontoID,
                        PontoId = item.PontoID,
                        RuaId = item.RuaID
                    };
                }
            }
        }

        private IEnumerable<tblruaDTO> RetornaTblRuas()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblRua.ToList())
                {
                    yield return new tblruaDTO()
                    {
                        RuaId = item.RuaID,
                        Descricao = item.Descricao,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblrotapontoDTO> RetornaTblRotaPontos()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblRotaPonto.ToList())
                {
                    yield return new tblrotapontoDTO()
                    {
                        RotaPontoId = item.RotaPontoID,
                        PontoId = item.PontoId,
                        RotaId = item.RotaId,
                        Quilometragem = item.DistanciaPontoAnterior,
                        OrdemPonto = item.OrdemPonto
                    };
                }
            }
        }

        private IEnumerable<tblrotaDTO> RetornaTblRotas()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblRota.ToList())
                {
                    yield return new tblrotaDTO()
                    {
                        RotaId = item.RotaID,
                        Descricao = item.Descricao,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblpontoDTO> RetornaTblPonto()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblPonto.ToList())
                {
                    yield return new tblpontoDTO()
                    {
                        PontoId = item.PontoID,
                        PontoParada = item.PontoParada,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblloginDTO> RetornaTblLogin()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblLogin.ToList())
                {
                    yield return new tblloginDTO()
                    {
                        LoginId = item.LoginID,
                        UsuarioId = item.UsuarioID,
                        UsuarioSenha = item.UsuarioSenha
                    };
                }
            }
        }

        private IEnumerable<tblitinerarioDTO> RetornaTblItinerarios()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblItinerario.ToList())
                {
                    yield return new tblitinerarioDTO()
                    {
                        ItinerarioId = item.ItinerarioID,
                        RotaId = item.RotaID,
                        DiaSemana = item.DiaSemana,
                        HoraSaida = item.HoraSaida,
                        HoraChegada = item.HoraChegada
                    };
                }
            }
        }

        private IEnumerable<tblcidadebairroDTO> RetornaTblCidadeBairros()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblCidadeBairro.ToList())
                {
                    yield return new tblcidadebairroDTO()
                    {
                        CidadeBairroId = item.CidadeBairroID,
                        CidadeId = item.CidadeID,
                        BairroId = item.BairroID
                    };
                }
            }
        }

        private IEnumerable<tblcidadeDTO> RetornaTblCidades()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblCidade.ToList())
                {
                    yield return new tblcidadeDTO()
                    {
                        CidadeId = item.CidadeID,
                        Descricao = item.Descricao,
                        Uf = item.UF,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblbaseDTO> RetornaTblBases()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblBase.ToList())
                {
                    yield return new tblbaseDTO()
                    {
                        BaseID = item.BaseID,
                        LocalBase = item.LocalBase,
                        VersaoBase = item.VersaoBase,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblbairroruaDTO> RetornaTblBairroRuas()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblBairroRua.ToList())
                {
                    yield return new tblbairroruaDTO()
                    {
                        BairroRuaId = item.BairroRuaID,
                        BairroId = item.BairroID,
                        RuaId = item.RuaID
                    };
                }
            }
        }

        private IEnumerable<tblbairroDTO> RetornaTblBairros()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblBairro.ToList())
                {
                    yield return new tblbairroDTO()
                    {
                        BairroId = item.BairroID,
                        Descricao = item.Descricao,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }

        private IEnumerable<tblaplicativoDTO> RetornaTblAplicativos()
        {
            using (FindBusEntities fn = new FindBusEntities())
            {
                foreach (var item in fn.tblAplicativo.ToList())
                {
                    yield return new tblaplicativoDTO()
                    {
                        AplicativoID = item.AplicativoID,
                        LocalAPK = item.LocalAPK,
                        VersaoAplicativo = item.VersaoAplicativo,
                        DataInclusaoRegistro = item.DataInclusaoRegistro.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                }
            }
        }
    }
}