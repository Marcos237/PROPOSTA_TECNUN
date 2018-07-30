using System;
using System.Collections.Generic;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Dominio.Intefaces.Repository
{
    public interface IProfessorRepository
    {
        Professor AdicionarProfessor(Professor professor);
        Professor AtualizarProfessor(Professor professor);
        void DeletarProfessor(Guid id);
        Professor ObterCpf(string cpf);
        Professor BuscarProfessorPorId(Guid id);
        Paged<ProfessorDTO> ObterTodosProfessores(string descricao, int pageSize, int pageNumber);
        List<Professor> BuscarTodosProfessores();
        void Dispose();
    }
}
