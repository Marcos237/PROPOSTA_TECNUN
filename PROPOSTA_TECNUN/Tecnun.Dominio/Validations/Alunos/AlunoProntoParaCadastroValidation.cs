using DomainValidation.Validation;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Specifications;

namespace Tecnun.Dominio.Validations.Alunos
{
    public class AlunoProntoParaCadastroValidation : Validator<Aluno>
    {
        public AlunoProntoParaCadastroValidation()
        {
            var cpfFormato = new CpfAlunoCorretoSpecification();
            base.Add("cpfFormato", new Rule<Aluno>(cpfFormato, "CPF com formato incorreto."));
        }
    }
}
