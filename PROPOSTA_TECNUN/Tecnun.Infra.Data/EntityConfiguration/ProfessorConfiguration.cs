using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Infra.Data.EntityConfiguration
{
    public class ProfessorConfiguration : EntityTypeConfiguration<Professor>
    {
        public ProfessorConfiguration()
        {
            HasKey(p => p.ProfessorId);

            Property(c => c.ProfessorId)
               .IsRequired();

            Property(c => c.Nome)
              .HasColumnName("Nome")
              .IsRequired()
              .HasMaxLength(100);

            Property(c => c.DataNascimento)
              .HasColumnName("DataNascimento")
              .IsRequired();

            Property(c => c.CPF.Codigo)
              .HasColumnName("CPF")
              .IsRequired()
              .HasMaxLength(11)
              .IsFixedLength()
              .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(c => c.Telefone.Numero)
              .HasColumnName("Telefone")
              .IsRequired()
              .HasMaxLength(11);

            Ignore(c => c.ValidationResult);

            ToTable("Professor");
        }
    }
}
