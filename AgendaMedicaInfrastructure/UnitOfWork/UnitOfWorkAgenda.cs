using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio;

namespace AgendaMedicaInfrastructure.UnitOfWork
{
    public class UnitOfWorkAgenda : IUnitOfWork
    {
        private readonly ContextoDb _contexto;
        private AgendamentoRepositorio _agendamento;
        private MedicoRepositorio _medico;
        private PacienteRepositorio _paciente;
        private UsuarioRepositorio _usuario;

        public UnitOfWorkAgenda(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        public AgendamentoRepositorio AgendamentoRepositorio
        {
            get
            {
                if (_agendamento == null)
                {
                    _agendamento = new AgendamentoRepositorio(_contexto);
                }
                return _agendamento;
            }
        }
        public MedicoRepositorio MedicoRepositorio
        {
            get
            {
                if (_medico == null)
                {
                    _medico = new MedicoRepositorio(_contexto);
                }
                return _medico;
            }
        }
        public PacienteRepositorio PacienteRepositorio
        {
            get
            {
                if (_paciente == null)
                {
                    _paciente = new PacienteRepositorio(_contexto);
                }
                return _paciente;
            }
        }
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

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}
