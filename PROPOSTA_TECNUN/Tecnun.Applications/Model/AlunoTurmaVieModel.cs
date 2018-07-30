using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tecnun.Applications.Model
{
    public class AlunoTurmaVieModel
    {

        public AlunoTurmaVieModel()
        {
            TurmaId = Guid.NewGuid();
        }

        [Key]
        public Guid AlunoTurmaId { get; set; }

        public Guid AlunoId { get; set; }

        public Guid TurmaId { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
