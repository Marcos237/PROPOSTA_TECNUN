using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecnun.Applications.Model
{
    public  class TurmaViewModel
    {
        public TurmaViewModel()
        {
            TurmaId = Guid.NewGuid();
        }

        [Key]
        [DisplayName("Código")]
        public Guid TurmaId { get;  set; }

        [DisplayName("Data Turma")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Preencha o campo data da turma")]
        public DateTime DataTurma { get;  set; }

        [Required(ErrorMessage = "Preencha o campo Professor")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Professor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo período")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Período")]
        public string PeriodoTurma { get;  set; }

        [DisplayName("Horário da Turma")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        [Required(ErrorMessage = "Preencha o campo horário")]
        public DateTime HorarioTurma { get;  set; }

        public Guid ProfessorId { get;  set; }

        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Buscar")]
        public string Buscar { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
