using DomainValidation.Interfaces.Specification;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;

namespace Tecnun.Dominio.Specifications.AlunoTurmas
{
    public class AlunoUnicoPorTumaSpecifications : ISpecification<AlunoTurma>
    {
        private readonly IAlunoTurmaRepository _alunoturmarepository;

        public AlunoUnicoPorTumaSpecifications(IAlunoTurmaRepository alunoturmarepository)
        {
            _alunoturmarepository = alunoturmarepository;
        }

        public bool IsSatisfiedBy(AlunoTurma alunoturma)
        {
            return _alunoturmarepository.BuscarAlunoturmaPorIds(alunoturma.AlunoId, alunoturma.TurmaId) == null;
        }
    }
}