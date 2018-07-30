using DomainValidation.Validation;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Dominio.Specifications.AlunoTurmas;

namespace Tecnun.Dominio.Validations.AlunoTurmas
{
    public class AlunoTurmaProntoParaCadastroValidations : Validator<AlunoTurma>
    {
        public AlunoTurmaProntoParaCadastroValidations(IAlunoTurmaRepository alunoturmarepository)
        {
            var alunoturmaunico = new AlunoUnicoPorTumaSpecifications(alunoturmarepository);
            base.Add("alunoturmaunico", new Rule<AlunoTurma>(alunoturmaunico, "ALuno já cadastrado nessa turma."));
        }
    }
}

