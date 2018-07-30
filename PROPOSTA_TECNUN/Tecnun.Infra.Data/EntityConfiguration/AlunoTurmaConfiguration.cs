using System.Data.Entity.ModelConfiguration;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Infra.Data.EntityConfiguration
{
    public class AlunoTurmaConfiguration : EntityTypeConfiguration<AlunoTurma>
    {
        public AlunoTurmaConfiguration()
        {
            HasKey(a => a.AlunoTurmaId);

            Property(a => a.AlunoTurmaId)
                .IsRequired()
                .HasColumnName("AlunoTurmaId");

            Property(a => a.AlunoId)
                .HasColumnName("AlunoId")
                .IsRequired();

            Property(a => a.TurmaId)
                .HasColumnName("TurmaId")
                .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("AlunoTurma");
        }
    }
}
