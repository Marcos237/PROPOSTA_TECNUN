using DomainValidation.Interfaces.Specification;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces;

namespace Tecnun.Dominio.Specifications.Alunos
{
    public class CpfAlunoUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunorepository;

        public CpfAlunoUnicoSpecification(IAlunoRepository alunorepository)
        {
            _alunorepository = alunorepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunorepository.ObterCpf(aluno.CPF.Codigo) == null;
        }
    }
}
