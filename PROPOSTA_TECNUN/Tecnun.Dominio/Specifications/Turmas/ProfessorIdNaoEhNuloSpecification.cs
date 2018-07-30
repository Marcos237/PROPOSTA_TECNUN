using DomainValidation.Interfaces.Specification;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Dominio.Specifications.Turmas
{
    public class ProfessorIdNaoEhNuloSpecification : ISpecification<Turma>
    {
        public bool IsSatisfiedBy(Turma turma)
        {
            return turma.ProfessorId != null;
        }
    }
}