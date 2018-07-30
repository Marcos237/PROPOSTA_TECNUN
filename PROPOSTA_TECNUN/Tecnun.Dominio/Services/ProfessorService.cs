using System;
using System.Collections.Generic;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Dominio.Intefaces.Services;
using Tecnun.Dominio.Validations.Professores;

namespace Tecnun.Dominio.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorrepository;

        public ProfessorService(IProfessorRepository professorrepository)
        {
            _professorrepository = professorrepository;
        }

        public Professor AdicionarProfessor(Professor professor)
        {
            if (!professor.IsValid())
            {
                return professor;
            }

            professor.ValidationResult = new ProfessorConsistenteParaCadastroValidation(_professorrepository).Validate(professor);
            if (!professor.ValidationResult.IsValid)
            {
                return professor;
            }

            professor.ValidationResult.Message = "Professor cadastrado com sucesso :)";
            return _professorrepository.AdicionarProfessor(professor);
        }

        public Professor AtualizarProfessor(Professor professor)
        {
            return _professorrepository.AtualizarProfessor(professor);
        }

        public void DeletarProfessor(Guid id)
        {
            _professorrepository.DeletarProfessor(id);
        }

        public Professor BuscarProfessorPorId(Guid id)
        {
            return _professorrepository.BuscarProfessorPorId(id);
        }


        public void Dispose()
        {
            _professorrepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Paged<ProfessorDTO> ObterTodosProfessores(string descicao, int pageSize, int pageNumber)
        {
            return _professorrepository.ObterTodosProfessores(descicao, pageSize, pageNumber);
        }

        public List<Professor> BuscarTodosProfesores()
        {
            return _professorrepository.BuscarTodosProfessores();
        }
    }
}
