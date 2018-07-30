using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecnun.Applications.Model
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel()
        {
            ProfessorId = Guid.NewGuid(); 
        }

        [Key]
        public Guid ProfessorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Preencha o campo data de nascimento")]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o campo  telefone")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Buscar")]
        public string Buscar { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
