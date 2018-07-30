using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecnun.Applications.Model
{
    public class AlunoMatriculadoViewModel
    {
        [Key]
        public Guid AlunoTurmaId { get; set; }

        [DisplayName("Código")]
        public Guid TurmaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Aluno")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo período")]
        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Período")]
        public string PeriodoTurma { get; set; }


        [MaxLength(150)]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Buscar")]
        public string Buscar { get; set; }
    }
}
