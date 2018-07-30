using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tecnun.Applications.Adapters;
using Tecnun.Applications.Interfaces;
using Tecnun.Applications.Model;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades.ValueObjects;
using Tecnun.Dominio.Helpers;
using Tecnun.Dominio.Intefaces.Services;
using Tecnun.Infra.Data.Interfaces;

namespace Tecnun.Applications.Service
{
    public class TurmaAppService : ApplicationService, ITurmaAppService
    {
        private readonly ITurmaService _turmaservice;

        public TurmaAppService(ITurmaService turmaservice, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _turmaservice = turmaservice;
        }

        public TurmaViewModel AdicionarTurma(TurmaViewModel model)
        {
            var turma = TurmaAdapter.ToDomainModel(model);
            _turmaservice.AdicionarTurma(turma);

            model.ValidationResult = turma.ValidationResult;

            if (!turma.ValidationResult.IsValid)
            {

                return model;
            }

            Commit();

            return model;
        }

        public PagedViewModel<TurmaViewModel> ObterTodasTurmas(string descricao, int pageSize, int pageNumber)
        {
            var descricaoformatada = TextoHelper.RemoverAcentos(descricao);
            return Mapper.Map<PagedViewModel<TurmaViewModel>>(_turmaservice.ObterTodasTurmas(descricaoformatada, pageSize, pageNumber));
        }


        public TurmaViewModel AtualizarTurma(TurmaViewModel model)
        {
            BeginTransaction();
            var turma = TurmaAdapter.ToDomainModel(model);
            _turmaservice.AtualizarTurma(turma);
            Commit();
            return model;
        }

        public TurmaViewModel BuscarTurmaPorId(Guid id)
        {
            return Mapper.Map<TurmaViewModel>(_turmaservice.BuscarTurmaPorId(id));
        }

        public void Dispose()
        {
            _turmaservice.Dispose();
            GC.SuppressFinalize(this);
        }

        public string[] BuscarPeridoTurma()
        {
            var result = Enum.GetNames(typeof(PeriodoTurma)).ToArray();

            return result;
        }

        public AlunoTurmaVieModel AdicionarAlunoTurma(AlunoTurmaVieModel model)
        {
            var alunoturma = AlunoTurmaAdapter.ToDomainModel(model);
            _turmaservice.AdicionarAlunoTurma(alunoturma);
            model.ValidationResult = alunoturma.ValidationResult;
            Commit();
            return model;
        }

        public PagedViewModel<AlunoMatriculadoViewModel> BuscarAlunoTurma(string descricao, int pageSize, int pageNumber)
        {
            var descricaoformatada = TextoHelper.RemoverAcentos(descricao);
            return Mapper.Map<PagedViewModel<AlunoMatriculadoViewModel>>(_turmaservice.BuscarAlunoTurma(descricaoformatada, pageSize, pageNumber));
        }
    }
}
