using AgendaMedicaDomain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace AgendaMedicaInfrastructure.Mapeamento
{
    public class MedicoMap : EntityTypeConfiguration<Medico>
    {
        public MedicoMap()
        {
            HasKey(t => t.IdMedico);

            Property(t => t.IdMedico).IsRequired();
            Property(t => t.Nome).IsRequired().HasMaxLength(Medico.MaxLenghtMedico);
            Property(t => t.Crm).IsRequired().HasMaxLength(Medico.MaxLenhgtlenghtCRM);

            ToTable("Medico");
            Property(t => t.IdMedico).HasColumnName("idMedico");
            Property(t => t.Nome).HasColumnName("medico");
            Property(t => t.Crm).HasColumnName("crm");

            HasMany(t => t.Agendamentos);
        }
    }
}
