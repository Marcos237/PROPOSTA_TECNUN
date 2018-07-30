using System;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Dominio.Intefaces.Services;
using Tecnun.Dominio.Validations;
using Tecnun.Dominio.Validations.AlunoTurmas;

namespace Tecnun.Dominio.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmarepository;
        private readonly IAlunoTurmaRepository _alunoturmarepository;

        public TurmaService(ITurmaRepository turmarepository, IAlunoTurmaRepository alunoturmarepository)
        {
            _turmarepository = turmarepository;
            _alunoturmarepository = alunoturmarepository;
        }

        public Turma AdicionarTurma(Turma turma)
        {
            if (!turma.IsValid())
            {
                return turma;
            }

            turma.ValidationResult = new TurmaProntoParaCadastroValidation().Validate(turma);
            if (!turma.ValidationResult.IsValid)
            {
                return turma;
            }

            turma.ValidationResult.Message = "Turma cadastrada com sucesso.)";
            return _turmarepository.AdicionarTurma(turma);
        }

        public Turma AtualizarTurma(Turma turma)
        {
            return _turmarepository.AtualizarTurma(turma);
        }

        public Turma BuscarTurmaPorId(Guid id)
        {
            return _turmarepository.BuscarTurmaPorId(id);
        }


        public void Dispose()
        {
            _turmarepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Paged<TurmaDTO> ObterTodasTurmas(string descicao, int pageSize, int pageNumber)
        {
            return _turmarepository.ObterTodasTurmas(descicao, pageSize, pageNumber);
        }

        public AlunoTurma AdicionarAlunoTurma(AlunoTurma alunoturma)
        {
            alunoturma.ValidationResult = new AlunoTurmaProntoParaCadastroValidations(_alunoturmarepository).Validate(alunoturma);
            if (!alunoturma.ValidationResult.IsValid)
            {
                return alunoturma;
            }

            alunoturma.ValidationResult.Message = "Aluno cadastrado com sucesso :)";
            return _alunoturmarepository.AdicionarAlunoTurma(alunoturma);
        }

        public Paged<AlunoTurmaDTO> BuscarAlunoTurma(string descricao, int pageSize, int pageNumber)
        {
            return _alunoturmarepository.BuscarAlunoTurma(descricao, pageSize, pageNumber);
        }
    }
}