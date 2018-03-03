using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class AgendamentoRepositorio : Repositorio<Agendamento>
    {
        public AgendamentoRepositorio(ContextoDb contexto) : base(contexto)
        {

        }
    }
}
