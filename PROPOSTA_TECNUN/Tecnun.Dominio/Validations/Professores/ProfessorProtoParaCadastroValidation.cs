using DomainValidation.Validation;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Specifications.Professores;

namespace Tecnun.Dominio.Validations.Alunos
{
    public class ProfessorProntoParaCadastroValidation : Validator<Professor>
    {
        public ProfessorProntoParaCadastroValidation()
        {
            var cpfFormato = new CpfProfessorCorretoSpecification();
            base.Add("cpfFormato", new Rule<Professor>(cpfFormato, "CPF com formato incorreto."));
        }
    }
}
