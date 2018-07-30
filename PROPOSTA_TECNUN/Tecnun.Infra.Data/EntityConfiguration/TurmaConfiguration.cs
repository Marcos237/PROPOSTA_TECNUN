using System.Data.Entity.ModelConfiguration;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Infra.Data.EntityConfiguration
{
    public class TurmaConfiguration : EntityTypeConfiguration<Turma>
    {
        public TurmaConfiguration()
        {
            HasKey(t => t.TurmaId);

            Property(t => t.TurmaId)
                .IsRequired();

            Property(t => t.DataTurma)
                .IsRequired()
                .HasColumnName("DataTurma");

            Property(t => t.PeriodoTurma)
                .IsRequired()
                .HasColumnName("PeriodoTurma")
                .HasMaxLength(100);

            Property(t => t.HorarioTurma)
                .IsRequired()
                .HasColumnName("HorarioTurma");

            Property(t => t.ProfessorId)
                .IsRequired()
                .HasColumnName("ProfessorId");

            Ignore(c => c.ValidationResult);

            ToTable("Turma");

        }
    }
}
