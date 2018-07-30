using System;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces;
using Tecnun.Dominio.Intefaces.Services;
using Tecnun.Dominio.Validations.Alunos;

namespace Tecnun.Dominio.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunorepository;

        public AlunoService(IAlunoRepository alunorepository)
        {
            _alunorepository = alunorepository;
        }

        public Aluno AdicionarAluno(Aluno aluno)
        {
            if (!aluno.IsValid())
            {
                return aluno;
            }

            aluno.ValidationResult = new AlunoConsistenteParaCadastroValidation(_alunorepository).Validate(aluno);
            if (!aluno.ValidationResult.IsValid)
            {
                return aluno;
            }

            aluno.ValidationResult.Message = "Aluno cadastrado com sucesso :)";
            return _alunorepository.Adicionar(aluno);
        }

        public Aluno AtualizarAluno(Aluno aluno)
        {
            return _alunorepository.Atualizar(aluno);
        }

        public void Remover(Guid id)
        {
            _alunorepository.Remover(id);
        }

        public Aluno BuscarAlunoPorId(Guid id)
        {
            return _alunorepository.BuscarAlunoPorId(id);
        }


        public void Dispose()
        {
            _alunorepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Paged<AlunoDTO> ObterTodosAlunos(string descicao, int pageSize, int pageNumber)
        {
            return _alunorepository.ObterTodosAlunos(descicao, pageSize, pageNumber);
        }

        public void DeletarAluno(Guid id)
        {
            _alunorepository.DeletarAluno(id);
        }
    }
}
