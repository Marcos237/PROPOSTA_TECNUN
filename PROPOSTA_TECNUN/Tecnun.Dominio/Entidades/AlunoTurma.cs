using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using Tecnun.Dominio.Validations.AlunoTurmas;

namespace Tecnun.Dominio.Entidades
{
    public class AlunoTurma
    {
        public Guid AlunoTurmaId { get; private set; }
        public Guid AlunoId { get; private set; }
        public Guid TurmaId { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }

        protected AlunoTurma()
        {

        }

        public AlunoTurma(Guid alunoturmaid, Guid alunoid, Guid turmaid)
        {
            AlunoTurmaId = alunoturmaid;
            AlunoId = alunoid;
            TurmaId = turmaid;
        }
    }
}
