using AgendaMedicaDomain.Entidades;
using AgendaMedicaInfrastructure.Mapeamento;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;

namespace AgendaMedicaInfrastructure.Dao
{
    public class ContextoDb : DbContext
    {
        public ContextoDb()
            : base("ConnStrgAgendaMedico")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Agendamento> AgendamentoDb { get; set; }
        public DbSet<Medico> MedicoDb { get; set; }
        public DbSet<Paciente> PacienteDb { get; set; }
        public DbSet<Usuario> UsuarioDb { get; set; }
        public DbSet<Token> TokenDb { get; set; }
        public DbSet<Sessao> SessaoDb { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AgendamentoMap());
            modelBuilder.Configurations.Add(new MedicoMap());
            modelBuilder.Configurations.Add(new PacienteMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TokenMap());
            modelBuilder.Configurations.Add(new SessaoMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
