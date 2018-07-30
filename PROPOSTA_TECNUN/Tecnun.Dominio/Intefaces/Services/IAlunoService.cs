using System;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Dominio.Intefaces.Services
{
    public interface IAlunoService
    {
        Aluno AdicionarAluno(Aluno obj);
        Aluno AtualizarAluno(Aluno obj);
        Aluno BuscarAlunoPorId(Guid id);
        Paged<AlunoDTO> ObterTodosAlunos(string descricao, int pageSize, int pageNumber);
        void DeletarAluno(Guid id);
        void Dispose();
    }
}
