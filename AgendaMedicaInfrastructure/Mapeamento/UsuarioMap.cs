using AgendaMedicaDomain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace AgendaMedicaInfrastructure.Mapeamento
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            HasKey(t => t.IdUsuario);

            Property(t => t.IdUsuario).IsRequired();
            Property(t => t.Login).IsRequired().HasMaxLength(Usuario.LoginMaxLength);
            Property(t => t.Senha).IsRequired().HasMaxLength(Usuario.SenhaMaxLength);
            Property(t => t.Ativo).IsRequired();

            ToTable("Usuario");
            Property(t => t.IdUsuario).HasColumnName("idUsuario");
            Property(t => t.Login).HasColumnName("usuario");
            Property(t => t.Senha).HasColumnName("senha");
            Property(t => t.Ativo).HasColumnName("ativo");
        }
    }
}
