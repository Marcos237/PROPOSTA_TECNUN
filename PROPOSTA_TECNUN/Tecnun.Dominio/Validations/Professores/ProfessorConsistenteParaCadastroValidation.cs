using DomainValidation.Validation;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Dominio.Specifications.Professores;

namespace Tecnun.Dominio.Validations.Professores
{
    public class ProfessorConsistenteParaCadastroValidation : Validator<Professor>
    {
        public ProfessorConsistenteParaCadastroValidation(IProfessorRepository professorrepository)
        {
            var cpfDuplicado = new CpfProfessorUnicoSpecification(professorrepository);

            base.Add("cpfDuplicado", new Rule<Professor>(cpfDuplicado, "CPF já cadastrado."));

        }
    }
}
