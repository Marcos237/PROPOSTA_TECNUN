using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tecnun.Dominio.Entidades;
using Tecnun.Infra.Data.EntityConfiguration;

namespace Tecnun.Infra.Data.Context
{
    public class TecnunContext : DbContext
    {
        public TecnunContext()
          : base("DefaultConnection")
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<AlunoTurma> AlunoTurma { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                 .Where(p => p.Name == p.ReflectedType.Name + "Id")
                 .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AlunoConfiguration());
            modelBuilder.Configurations.Add(new ProfessorConfiguration());
            modelBuilder.Configurations.Add(new TurmaConfiguration());
            modelBuilder.Configurations.Add(new AlunoTurmaConfiguration());
        }

    }

    public static class ChangeDb
    {
        public static void ChangeConnection(this TecnunContext context, string con)
        {
            context.Database.Connection.ConnectionString = con;
        }
    }
}
