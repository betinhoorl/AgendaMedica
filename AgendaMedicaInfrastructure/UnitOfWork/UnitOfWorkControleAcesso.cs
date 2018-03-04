using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio;

namespace AgendaMedicaInfrastructure.UnitOfWork
{
    public class UnitOfWorkControleAcesso : IUnitOfWork
    {
        // Campos
        private readonly ContextoDb _contexto;
        private UsuarioRepositorio _usuario;
        private TokenRepositorio _token;
        private SessaoRepositorio _sessao;

        // Construtor
        public UnitOfWorkControleAcesso(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Propriedades
        public UsuarioRepositorio UsuarioRepositorio
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new UsuarioRepositorio(_contexto);
                }
                return _usuario;
            }
        }

        public TokenRepositorio TokenRepositorio
        {
            get
            {
                if (_token == null)
                {
                    _token = new TokenRepositorio(_contexto);
                }
                return _token;
            }
        }

        public SessaoRepositorio SessaoRepositorio
        {
            get
            {
                if (_sessao == null)
                {
                    _sessao = new SessaoRepositorio(_contexto);
                }
                return _sessao;
            }
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}
