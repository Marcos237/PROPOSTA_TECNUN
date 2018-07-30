using System;
using Tecnun.Applications.Model;

namespace Tecnun.Applications.Interfaces
{
    public interface IAlunoAppService
    {
        AlunoViewModel AdicionarAluno(AlunoViewModel aluno);
        AlunoViewModel AtualizarAluno(AlunoViewModel aluno);
        void DeletarAluno(Guid id);
        AlunoViewModel BuscarAlunoPorId(Guid id);
        PagedViewModel<AlunoViewModel> ObterTodosAlunos(string descricao, int pageSize, int pageNumber);
        void Dispose();
    }
}
