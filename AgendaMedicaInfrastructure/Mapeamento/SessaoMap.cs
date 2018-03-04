using AgendaMedicaDomain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace AgendaMedicaInfrastructure.Mapeamento
{
    public class SessaoMap : EntityTypeConfiguration<Sessao>
    {
        public SessaoMap()
        {
            HasKey(t => t.IdSessao);

            Property(t => t.IdSessao).IsRequired();
            Property(t => t.IdUsuario).IsRequired();
            Property(t => t.EstaLogado).IsRequired();
            Property(t => t.DataAbertura).IsRequired();
            Property(t => t.DataEncerramento).IsOptional();

            ToTable("Sessao");
            Property(t => t.IdSessao).HasColumnName("idSessao");
            Property(t => t.IdUsuario).HasColumnName("idUsuario");
            Property(t => t.EstaLogado).HasColumnName("estaLogado");
            Property(t => t.DataAbertura).HasColumnName("dtAbertura");
            Property(t => t.DataEncerramento).HasColumnName("dtEncerramento");

            HasRequired(t => t.Usuario);
        }
    }
}
