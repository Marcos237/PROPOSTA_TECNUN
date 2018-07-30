using DomainValidation.Interfaces.Specification;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;

namespace Tecnun.Dominio.Specifications.Professores
{
    public class CpfProfessorUnicoSpecification : ISpecification<Professor>
    {
        private readonly IProfessorRepository _professorrepository;

        public CpfProfessorUnicoSpecification(IProfessorRepository professorrepository)
        {
            _professorrepository = professorrepository;
        }

        public bool IsSatisfiedBy(Professor professor)
        {
            return _professorrepository.ObterCpf(professor.CPF.Codigo) == null;
        }
    }
}
