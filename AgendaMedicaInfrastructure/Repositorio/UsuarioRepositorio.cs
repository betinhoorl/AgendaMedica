using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>
    {
        public UsuarioRepositorio(ContextoDb contexto) : base(contexto)
        {
        }
    }
}
