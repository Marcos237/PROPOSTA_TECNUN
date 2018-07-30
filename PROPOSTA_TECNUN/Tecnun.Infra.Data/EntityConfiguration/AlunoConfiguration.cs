using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Infra.Data.EntityConfiguration
{
    public class AlunoConfiguration: EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            HasKey(c => c.AlunoId);

            Property(c => c.AlunoId)
             .IsRequired();

            Property(c => c.Nome)
             .HasColumnName("Nome")
             .IsRequired()
             .HasMaxLength(100);

            Property(c => c.DataNascimento)
              .HasColumnName("Data_Nascimento")
              .HasColumnType("DateTime")
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


            Property(c => c.Email.Endereco)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);


            Property(c => c.InformacoersAdicionais)
                .HasColumnName("Informacoes_Adicionais")
                .HasMaxLength(150);

            Ignore(c => c.ValidationResult);

            ToTable("Aluno");


        }
    }
}
