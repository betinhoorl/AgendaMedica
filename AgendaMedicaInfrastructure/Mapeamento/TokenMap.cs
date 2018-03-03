using AgendaMedicaDomain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace AgendaMedicaInfrastructure.Mapeamento
{
    public class TokenMap : EntityTypeConfiguration<Token>
    {
        public TokenMap()
        {
            HasKey(t => t.IdToken);

            Property(t => t.IdToken).IsRequired();
            Property(t => t.IdUsuario).IsRequired();
            Property(t => t.NumeroToken).IsRequired();
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsOptional();

            ToTable("Token");
            Property(t => t.IdToken).HasColumnName("idToken");
            Property(t => t.IdUsuario).HasColumnName("idUsuario");
            Property(t => t.NumeroToken).HasColumnName("numeroToken");
            Property(t => t.DataInclusao).HasColumnName("dtInclusao");
            Property(t => t.DataAlteracao).HasColumnName("dtAlteracao");

            HasRequired(t => t.Usuario);
        }
    }
}
