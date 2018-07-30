using AutoMapper;
using Tecnun.Applications.Model;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Applications.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>()
               .ForMember(d => d.AlunoId, opt => opt.MapFrom(src => src.AlunoId))
               .ForMember(d => d.Data_Nascimento, opt => opt.MapFrom(src => src.DataNascimento))
               .ForMember(d => d.CPF, opt => opt.MapFrom(src => src.CPF.Codigo))
               .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email.Endereco))
               .ForMember(d => d.Telefone, opt => opt.MapFrom(src => src.Telefone.Numero))
               .ForMember(d => d.Informacoes_Adicionais, opt => opt.MapFrom(src => src.InformacoersAdicionais));

            CreateMap<Paged<Aluno>, PagedViewModel<AlunoViewModel>>();

            CreateMap<Professor, ProfessorViewModel>()
               .ForMember(d => d.ProfessorId, opt => opt.MapFrom(src => src.ProfessorId))
               .ForMember(d => d.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
               .ForMember(d => d.CPF, opt => opt.MapFrom(src => src.CPF.Codigo))
               .ForMember(d => d.Telefone, opt => opt.MapFrom(src => src.Telefone.Numero));

            CreateMap<Paged<Professor>, PagedViewModel<ProfessorViewModel>>();

            CreateMap<Turma, TurmaViewModel>()
               .ForMember(d => d.TurmaId, opt => opt.MapFrom(src => src.TurmaId))
               .ForMember(d => d.DataTurma, opt => opt.MapFrom(src => src.DataTurma))
               .ForMember(d => d.PeriodoTurma, opt => opt.MapFrom(src => src.PeriodoTurma))
               .ForMember(d => d.ProfessorId, opt => opt.MapFrom(src => src.ProfessorId));

            CreateMap<TurmaDTO, TurmaViewModel>();
            CreateMap<Paged<TurmaDTO>, PagedViewModel<TurmaViewModel>>();

            CreateMap<AlunoTurmaDTO, AlunoMatriculadoViewModel>();
            CreateMap<Paged<AlunoTurmaDTO>, PagedViewModel<AlunoMatriculadoViewModel>>();


        }
    }
}
