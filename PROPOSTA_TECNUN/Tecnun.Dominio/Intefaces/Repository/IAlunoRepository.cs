using System;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;

namespace Tecnun.Dominio.Intefaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Aluno AdicionarAluno(Aluno aluno);
        Aluno AtualizarAluno(Aluno aluno);
        void DeletarAluno(Guid id);
        Aluno ObterCpf(string cpf);
        Aluno BuscarAlunoPorId(Guid id);
        Paged<AlunoDTO> ObterTodosAlunos(string descricao, int pageSize, int pageNumber);
    }
}
