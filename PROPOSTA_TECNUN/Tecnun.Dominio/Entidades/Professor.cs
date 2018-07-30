using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using Tecnun.Dominio.Entidades.ValueObjects;
using Tecnun.Dominio.Validations.Alunos;

namespace Tecnun.Dominio.Entidades
{
    public class Professor
    {
        public Guid ProfessorId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public CPF CPF { get; private set; }
        public TELEFONE Telefone { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual ICollection<Turma> Turma { get; set; }


        protected Professor()
        {

        }

        public Professor(Guid professorid, string nome, DateTime datanascimeto, string cpf, string telefone)
        {
            ProfessorId = professorid;
            Nome = nome;
            DataNascimento = datanascimeto;
            CPF = new CPF(cpf);
            Telefone = new TELEFONE(telefone);
        }

        public bool IsValid()
        {
            ValidationResult = new ProfessorProntoParaCadastroValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
