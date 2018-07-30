using DomainValidation.Interfaces.Specification;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Entidades.ValueObjects;

namespace Tecnun.Dominio.Specifications.Professores
{
    public class CpfProfessorCorretoSpecification : ISpecification<Professor>
    {
        public bool IsSatisfiedBy(Professor entity)
        {
            return CPF.Validar(entity.CPF.Codigo);
        }
    }
}
