using System;
using System.Collections.Generic;
using Tecnun.Applications.Model;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Applications.Interfaces
{
    public interface IProfessorAppService
    {
        ProfessorViewModel AdicionarProfessor(ProfessorViewModel profesor);
        ProfessorViewModel AtualizarProfessor(ProfessorViewModel professor);
        void DeletarProfessor(Guid id);
        ProfessorViewModel BuscarProfessorPorId(Guid id);
        PagedViewModel<ProfessorViewModel> ObterTodosProfessores(string descricao, int pageSize, int pageNumber);
        List<Professor> BuscarTodosProfessores();
        void Dispose();
    }
}
