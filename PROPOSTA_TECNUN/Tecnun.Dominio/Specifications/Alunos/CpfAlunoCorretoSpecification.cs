using DomainValidation.Interfaces.Specification;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Entidades.ValueObjects;

namespace Tecnun.Dominio.Specifications
{
    public class CpfAlunoCorretoSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno entity)
        {
            return CPF.Validar(entity.CPF.Codigo);
        }
    }
}
