using AutoMapper;
using System;
using Tecnun.Applications.Adapters;
using Tecnun.Applications.Interfaces;
using Tecnun.Applications.Model;
using Tecnun.Dominio.Helpers;
using Tecnun.Dominio.Intefaces.Services;
using Tecnun.Infra.Data.Interfaces;

namespace Tecnun.Applications.Service
{
    public class AlunoAppService : ApplicationService, IAlunoAppService
    {
        private readonly IAlunoService _alunoservice;

        public AlunoAppService(IAlunoService alunoservice, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _alunoservice = alunoservice;
        }

        public AlunoViewModel AdicionarAluno(AlunoViewModel model)
        {
            var aluno = AlunoAdapter.ToDomainModel(model);
            _alunoservice.AdicionarAluno(aluno);

            model.ValidationResult = aluno.ValidationResult;

            if (!aluno.ValidationResult.IsValid)
            {
                
                return model;
            }

            Commit();

            return model;
        }

        public PagedViewModel<AlunoViewModel> ObterTodosAlunos(string descricao, int pageSize, int pageNumber)
        {
            var descricaoformatada = TextoHelper.RemoverAcentos(descricao);
            return Mapper.Map<PagedViewModel<AlunoViewModel>>(_alunoservice.ObterTodosAlunos(descricaoformatada, pageSize, pageNumber));
        }


        public AlunoViewModel AtualizarAluno(AlunoViewModel model)
        {
            BeginTransaction();
            var aluno = AlunoAdapter.ToDomainModel(model);
            _alunoservice.AtualizarAluno(aluno);
            Commit();
            return model;
        }

        public void DeletarAluno(Guid id)
        {
            _alunoservice.DeletarAluno(id);
            Commit();
        }


        public AlunoViewModel BuscarAlunoPorId(Guid id)
        {
            return Mapper.Map<AlunoViewModel>(_alunoservice.BuscarAlunoPorId(id));
        }

        public void Dispose()
        {
            _alunoservice.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
