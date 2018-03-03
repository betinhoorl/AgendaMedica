using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class TokenRepositorio : Repositorio<Token>
    {
        public TokenRepositorio(ContextoDb contexto) : base(contexto)
        {
        }
    }
}
