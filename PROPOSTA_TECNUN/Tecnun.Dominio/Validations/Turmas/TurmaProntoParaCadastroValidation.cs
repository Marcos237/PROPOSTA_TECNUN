using DomainValidation.Validation;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Specifications.Turmas;

namespace Tecnun.Dominio.Validations
{
    public class TurmaProntoParaCadastroValidation  : Validator<Turma>
    {
        public TurmaProntoParaCadastroValidation()
        {
            var professorid = new ProfessorIdNaoEhNuloSpecification();

            base.Add("professorid", new Rule<Turma>(professorid, "O Professor nao pode ser nulo."));

        }
    }
}