using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class PacienteRepositorio : Repositorio<Paciente>
    {
        public PacienteRepositorio(ContextoDb contexto) : base(contexto)
        {
        }
    }
}
