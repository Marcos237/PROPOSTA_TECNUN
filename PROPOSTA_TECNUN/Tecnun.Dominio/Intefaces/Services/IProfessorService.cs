using System;
using System.Collections.Generic;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Dominio.Intefaces.Services
{
    public interface IProfessorService
    {
        Professor AdicionarProfessor(Professor obj);
        Professor AtualizarProfessor(Professor obj);
        Professor BuscarProfessorPorId(Guid id);
        Paged<ProfessorDTO> ObterTodosProfessores(string descricao, int pageSize, int pageNumber);
        void DeletarProfessor(Guid id);
        List<Professor> BuscarTodosProfesores();
        void Dispose();
    }
}
