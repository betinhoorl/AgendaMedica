using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Mapeamento;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AgendaMedicaInfrastructure.Dao
{
    public class ContextoDb : DbContext
    {
        public ContextoDb()
            : base("ConnStrgMeuClube")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Agendamento> AgendamentoDb { get; set; }
        public DbSet<Medico> MedicoDb { get; set; }
        public DbSet<Paciente> PacienteDb { get; set; }
        public DbSet<Usuario> UsuarioDb { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AgendamentoMap());
            modelBuilder.Configurations.Add(new MedicoMap());
            modelBuilder.Configurations.Add(new PacienteMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
