using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.Repositorio.Generico;

namespace AgendaMedicaInfrastructure.Repositorio
{
    public class MedicoRepositorio : Repositorio<Medico>
    {
        public MedicoRepositorio(ContextoDb contexto) : base(contexto)
        {
        }
    }
}
