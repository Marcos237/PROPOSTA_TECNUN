using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using Tecnun.Dominio.Validations;

namespace Tecnun.Dominio.Entidades
{
    public class Turma
    {
        public Guid TurmaId { get; private set; }
        public DateTime DataTurma { get; private set; }
        public string PeriodoTurma { get; private set; }
        public DateTime HorarioTurma { get; private set; }
        public Guid ProfessorId { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }

        public virtual Professor Professor { get; set; }

        protected Turma()
        {

        }

        public Turma(Guid turmaid, DateTime dataturma, string periodoturma, DateTime horaturma, Guid professorid )
        {
            TurmaId = turmaid;
            DataTurma = dataturma;
            PeriodoTurma = periodoturma;
            HorarioTurma = horaturma;
            ProfessorId = professorid;
        }

        public bool IsValid()
        {
            ValidationResult = new TurmaProntoParaCadastroValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
