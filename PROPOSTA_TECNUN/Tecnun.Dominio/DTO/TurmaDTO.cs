using DomainValidation.Validation;
using System;

namespace Tecnun.Dominio.DTO
{
    public class TurmaDTO
    {
        public Guid TurmaId { get; set; }
        public string Nome { get; set; }
        public string PeriodoTurma { get; set; }
        public DateTime HorarioTurma { get; set; }
        public DateTime DataTurma { get; set; }
        public Guid ProfessorId { get; set; }
        ValidationResult ValidationResult { get; set; }
    }
}
