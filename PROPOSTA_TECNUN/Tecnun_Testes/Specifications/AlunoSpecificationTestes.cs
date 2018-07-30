using System;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Specifications;
using Xunit;

namespace Tecnun_Testes.Specifications
{

    public class AlunoSpecificationTestes
    {
        public Aluno aluno { get; set; }
        Guid alunoid = Guid.NewGuid();


        [Fact(DisplayName = "CPF Formato Inválido Specifications")]
        [Trait("Categoria", "Validar CPF")]
        public void CPF_Formato_Incorreto()
        {
            aluno = new Aluno(alunoid, "Marcos", DateTime.Now, "7069278306", "976337889", "teste@teste.com", "Informacoes");
            var cpf = new CpfAlunoCorretoSpecification();

            Assert.False(cpf.IsSatisfiedBy(aluno));
        }

        [Fact(DisplayName = "CPF Formato Válido Specifications")]
        [Trait("Categoria", "Validar CPF")]
        public void CPF_Formato_Correto()
        {
            aluno = new Aluno(alunoid, "Marcos", DateTime.Now, "70692783067", "976337889", "teste@teste.com", "Informacoes");
            var cpf = new CpfAlunoCorretoSpecification();

            Assert.True(cpf.IsSatisfiedBy(aluno));
        }
    }
}
