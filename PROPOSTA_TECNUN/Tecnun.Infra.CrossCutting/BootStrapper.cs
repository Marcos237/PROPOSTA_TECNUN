using SimpleInjector;
using Tecnun.Applications.Interfaces;
using Tecnun.Applications.Service;
using Tecnun.Dominio.Intefaces;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Dominio.Intefaces.Services;
using Tecnun.Dominio.Services;
using Tecnun.Infra.Data.Context;
using Tecnun.Infra.Data.Interfaces;
using Tecnun.Infra.Data.Repository;
using Tecnun.Infra.Data.Uow;

namespace Tecnun.Infra.CrossCutting.Ioc
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            MyContainer = container;

            //APP
            container.Register<IAlunoAppService, AlunoAppService>(Lifestyle.Scoped);
            container.Register<IProfessorAppService, ProfessorAppService>(Lifestyle.Scoped);
            container.Register<ITurmaAppService, TurmaAppService>(Lifestyle.Scoped);

            //Dominio
            container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);
            container.Register<IProfessorService, ProfessorService>(Lifestyle.Scoped);
            container.Register<ITurmaService, TurmaService>(Lifestyle.Scoped);

            //Infra Dados
            container.Register<TecnunContext>(Lifestyle.Scoped);
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);
            container.Register<IProfessorRepository, ProfessorRepository>(Lifestyle.Scoped);
            container.Register<ITurmaRepository, TurmaRepository>(Lifestyle.Scoped);
            container.Register<IAlunoTurmaRepository, AlunoTurmaRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

        }
    }
}
