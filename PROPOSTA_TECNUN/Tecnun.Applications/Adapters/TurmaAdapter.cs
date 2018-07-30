using Tecnun.Applications.Model;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Applications.Adapters
{
    public class TurmaAdapter
    {
        public static Turma ToDomainModel(TurmaViewModel model)
        {
            var turma = new Turma(
                model.TurmaId,
                model.DataTurma,
                model.PeriodoTurma,
                model.HorarioTurma,
                model.ProfessorId);

            return turma;
        }
    }
}
