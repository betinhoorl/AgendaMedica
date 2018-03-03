using AgendaMedicaDomain.Dto;
using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;
using System.Data.Entity;
using System.Linq;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>
    {
        private readonly ContextoDb _contexto;

        public UsuarioRepositorio(ContextoDb contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Usuario AutenticaUsuario(UsuarioAutenticacaoDto dto)
        {
            var usuarioAutenticado = _contexto.UsuarioDb.Where(usuario =>
                usuario.Login == dto.UsuarioLogin &&
                usuario.Senha == dto.SenhaCriptografada &&
                usuario.Ativo).FirstOrDefault();

            if (usuarioAutenticado == null)
                return usuarioAutenticado;

            _contexto.Entry(usuarioAutenticado).State = EntityState.Modified;
            return usuarioAutenticado;
        }

    }
}
