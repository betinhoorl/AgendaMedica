using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;
using System.Linq;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class SessaoRepositorio : Repositorio<Sessao>
    {
        private readonly ContextoDb _contexto;

        public SessaoRepositorio(ContextoDb contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public bool VerificaExistenciaSessaoAbertaPorUsuario(int idUsuario)
        {
            return _contexto.SessaoDb.AsNoTracking().Any(x => x.EstaLogado && x.DataEncerramento == null);
        }
    }
}
