using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecnun.Applications.Model
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {
            AlunoId = Guid.NewGuid();
        }

        [Key]
        [DisplayName("Código")]
        public Guid AlunoId { get;  set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Preencha o campo data de nascimento")]
        public DateTime Data_Nascimento { get;  set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get;  set; }

        [Required(ErrorMessage = "Preencha o campo  telefone")]
        [MaxLength(14)]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [DisplayName("Telefone")]
        public string Telefone { get;  set; }

        [Required(ErrorMessage = "Preencha o campo  email")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "Preencha o campo  informações adicionais")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [Display(Name = "Informacões Adicionais")]
        public string Informacoes_Adicionais { get; set; }

        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Buscar")]
        public string Buscar { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
