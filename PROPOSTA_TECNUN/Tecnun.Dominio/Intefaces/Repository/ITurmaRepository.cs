using System;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Dominio.Intefaces.Repository
{
    public interface ITurmaRepository
    {
        Turma AdicionarTurma(Turma turma);
        Turma AtualizarTurma(Turma turma);
        Turma BuscarTurmaPorId(Guid id);
        Paged<TurmaDTO> ObterTodasTurmas(string descricao, int pageSize, int pageNumber);   
        void Dispose();
    }
}
