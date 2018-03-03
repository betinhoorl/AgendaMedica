using AgendaMedicaDomain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace AgendaMedicaInfrastructure.Mapeamento
{
    public class PacienteMap : EntityTypeConfiguration<Paciente>
    {
        public PacienteMap()
        {
            HasKey(t => t.IdPaciente);

            Property(t => t.IdPaciente).IsRequired();
            Property(t => t.Nome).IsRequired().HasMaxLength(Paciente.MaxLenghtPaciente);
            Property(t => t.Cpf.Codigo).IsRequired().HasMaxLength(Paciente.MaxLenghtCPF);

            ToTable("Paciente");
            Property(t => t.IdPaciente).HasColumnName("idPaciente");
            Property(t => t.Nome).HasColumnName("paciente");
            Property(t => t.Cpf.Codigo).HasColumnName("cpf");

            HasMany(t => t.Agendamentos);
        }
    }
}
