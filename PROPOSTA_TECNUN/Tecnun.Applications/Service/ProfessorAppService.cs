using AutoMapper;
using System;
using System.Collections.Generic;
using Tecnun.Applications.Adapters;
using Tecnun.Applications.Interfaces;
using Tecnun.Applications.Model;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Helpers;
using Tecnun.Dominio.Intefaces.Services;
using Tecnun.Infra.Data.Interfaces;

namespace Tecnun.Applications.Service
{
    public class ProfessorAppService : ApplicationService, IProfessorAppService
    {
        private readonly IProfessorService _professorservice;

        public ProfessorAppService(IProfessorService professorservice, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _professorservice = professorservice;
        }

        public ProfessorViewModel AdicionarProfessor(ProfessorViewModel model)
        {
            var professor = ProfessorAdapter.ToDomainModel(model);
            _professorservice.AdicionarProfessor(professor);

            model.ValidationResult = professor.ValidationResult;

            if (!professor.ValidationResult.IsValid)
            {

                return model;
            }

            Commit();

            return model;
        }

        public PagedViewModel<ProfessorViewModel> ObterTodosProfessores(string descricao, int pageSize, int pageNumber)
        {
            var descricaoformatada = TextoHelper.RemoverAcentos(descricao);
            return Mapper.Map<PagedViewModel<ProfessorViewModel>>(_professorservice.ObterTodosProfessores(descricaoformatada, pageSize, pageNumber));
        }


        public ProfessorViewModel AtualizarProfessor(ProfessorViewModel model)
        {
            BeginTransaction();
            var professor = ProfessorAdapter.ToDomainModel(model);
            _professorservice.AtualizarProfessor(professor);
            Commit();
            return model;
        }

        public void DeletarProfessor(Guid id)
        {
            _professorservice.DeletarProfessor(id);
            Commit();
        }


        public ProfessorViewModel BuscarProfessorPorId(Guid id)
        {
            return Mapper.Map<ProfessorViewModel>(_professorservice.BuscarProfessorPorId(id));
        }

        public void Dispose()
        {
            _professorservice.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Professor> BuscarTodosProfessores()
        {
            return _professorservice.BuscarTodosProfesores();
        }
    }
}
