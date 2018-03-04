using AgendaMedicaDomain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace AgendaMedicaInfrastructure.Mapeamento
{
    public class AgendamentoMap : EntityTypeConfiguration<Agendamento>
    {
        public AgendamentoMap()
        {
            HasKey(t => t.IdAgendamento);

            Property(t => t.IdAgendamento).IsRequired();
            Property(t => t.DataHora).IsRequired();
            Property(t => t.IdMedico).IsRequired();
            Property(t => t.IdPaciente).IsRequired();

            ToTable("Agendamento");
            Property(t => t.IdAgendamento).HasColumnName("idAgendamento");
            Property(t => t.DataHora).HasColumnName("dataHora");
            Property(t => t.IdMedico).HasColumnName("idMedico");
            Property(t => t.IdPaciente).HasColumnName("idPaciente");

            HasRequired(t => t.Medico);
            HasRequired(t => t.Paciente);
        }
    }
}
