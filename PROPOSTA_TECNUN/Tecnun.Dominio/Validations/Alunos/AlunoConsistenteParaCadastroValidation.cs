using DomainValidation.Validation;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces;
using Tecnun.Dominio.Specifications.Alunos;

namespace Tecnun.Dominio.Validations.Alunos
{
    public class AlunoConsistenteParaCadastroValidation : Validator<Aluno>
    {
        public AlunoConsistenteParaCadastroValidation(IAlunoRepository alunorepository)
        {
            var cpfDuplicado = new CpfAlunoUnicoSpecification(alunorepository);

            base.Add("cpfDuplicado", new Rule<Aluno>(cpfDuplicado, "CPF já cadastrado."));

        }
    }
}