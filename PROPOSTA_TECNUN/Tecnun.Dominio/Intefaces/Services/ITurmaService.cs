using System;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Dominio.Intefaces.Services
{
    public interface ITurmaService
    {
        Turma AdicionarTurma(Turma obj);
        Turma AtualizarTurma(Turma obj);
        Turma BuscarTurmaPorId(Guid id);
        Paged<TurmaDTO> ObterTodasTurmas(string descricao, int pageSize, int pageNumber);
        AlunoTurma AdicionarAlunoTurma(AlunoTurma alunoturma);
        Paged<AlunoTurmaDTO> BuscarAlunoTurma(string descricao, int pageSize, int pageNumber);
        void Dispose();
    }
}
