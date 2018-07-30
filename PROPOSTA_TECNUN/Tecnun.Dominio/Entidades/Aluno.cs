using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using Tecnun.Dominio.Entidades.ValueObjects;
using Tecnun.Dominio.Validations.Alunos;

namespace Tecnun.Dominio.Entidades
{
    public class Aluno
    {
        public Guid AlunoId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public CPF CPF { get; private set; }
        public TELEFONE Telefone { get; private set; }
        public EMAIL Email { get; private set; }
        public string InformacoersAdicionais { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }

        protected Aluno()
        {

        }

        public Aluno( Guid alunoid, string nome, DateTime datanascimento, string cpf, string telefone, string email, string informacoesadicionais)
        {
            AlunoId = alunoid;
            Nome = nome;
            DataNascimento = datanascimento;
            CPF = new CPF(cpf);
            Telefone = new TELEFONE(telefone);
            Email = new EMAIL(email);
            InformacoersAdicionais = informacoesadicionais;          
        }


        public bool IsValid()
        {
            ValidationResult = new AlunoProntoParaCadastroValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
