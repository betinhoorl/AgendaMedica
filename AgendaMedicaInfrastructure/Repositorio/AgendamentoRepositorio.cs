using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class AgendamentoRepositorio : Repositorio<Agendamento>
    {
        private readonly ContextoDb _contexto;

        public AgendamentoRepositorio(ContextoDb contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Agendamento> GetAllAgendamentos()
        {
            return _contexto.AgendamentoDb.AsNoTracking().OrderBy(x => x.DataHora);
        }
    }
}
