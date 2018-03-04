using AgendaMedicaDomain.Dto;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.UnitOfWork;
using AgendaMedicaRules.Regras;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgendaMedicaInterface.Controllers
{
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        private readonly UnitOfWorkControleAcesso _uow;

        public UsuarioController()
        {
            _uow = new UnitOfWorkControleAcesso(new ContextoDb());
        }

        [HttpPost]
        [Route("Autenticacao")]
        public HttpResponseMessage Autenticacao(UsuarioAutenticacaoDto usuarioAutenticacao)
        {
            if (usuarioAutenticacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var usuarioAutenticado = UsuarioRegras.CreateInstance.AutenticarUsuario(usuarioAutenticacao);
            var usuario = _uow.UsuarioRepositorio.AutenticaUsuario(usuarioAutenticado);

            if (usuario == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Usuario não existe ou não está ativo!");


            GerenciarCookieRegras.SetIdUser(usuario.IdUsuario);
            var novaSessao = SessaoRegras.CreateInstance.CriarNovaSessao(usuario.IdUsuario);
            _uow.SessaoRepositorio.Adicionar(novaSessao);
            _uow.Commit();

            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }



        [HttpPost]
        [Route("CadastroUsuario")]
        public HttpResponseMessage CadastroUsuario(UsuarioDto dto)
        {
            if (dto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var usuario = UsuarioRegras.CreateInstance.CadastroNovoUsuario(dto);
             _uow.UsuarioRepositorio.Adicionar(usuario);

            if (usuario == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var token = TokenRegras.CreateInstance.RegistrarToken(usuario.IdUsuario);
            GravacaoArquivosRegras.CreateInstance.SalvarTokenUsuario(usuario.Login, token.NumeroToken);

            _uow.TokenRepositorio.Adicionar(token);
            _uow.Commit();

            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        [HttpPost]
        [Route("EncerrarSessao")]
        public HttpResponseMessage EncerrarSessao()
        {
            var idUsuario = GerenciarCookieRegras.GetIdUser();

            var novaSessao = SessaoRegras.CreateInstance.EncerrarSessao(Convert.ToInt32(idUsuario));
            _uow.SessaoRepositorio.Atualizar(novaSessao);

            return Request.CreateResponse(HttpStatusCode.OK, novaSessao);
        }

    }
}
