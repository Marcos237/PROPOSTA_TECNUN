using System;
using Tecnun.Applications.Model;
using Tecnun.Dominio.DTO;

namespace Tecnun.Applications.Interfaces
{
    public interface ITurmaAppService
    {
        TurmaViewModel AdicionarTurma(TurmaViewModel turma);
        TurmaViewModel AtualizarTurma(TurmaViewModel turma);
        TurmaViewModel BuscarTurmaPorId(Guid id);
        PagedViewModel<TurmaViewModel> ObterTodasTurmas(string descricao, int pageSize, int pageNumber);
        string[] BuscarPeridoTurma();
        AlunoTurmaVieModel AdicionarAlunoTurma(AlunoTurmaVieModel model);
        PagedViewModel<AlunoMatriculadoViewModel> BuscarAlunoTurma(string descricao, int pageSize, int pageNumber);
        void Dispose();
    }
}
