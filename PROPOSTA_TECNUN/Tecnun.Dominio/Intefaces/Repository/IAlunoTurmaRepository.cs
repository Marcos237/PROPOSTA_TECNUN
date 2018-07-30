using System;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Dominio.Intefaces.Repository
{
    public interface IAlunoTurmaRepository
    {
        AlunoTurma AdicionarAlunoTurma(AlunoTurma alunoturma);
        AlunoTurma BuscarAlunoturmaPorIds(Guid alunoid, Guid turmaid);
        Paged<AlunoTurmaDTO> BuscarAlunoTurma(string descricao, int pageSize, int pageNumber);
    }
}
