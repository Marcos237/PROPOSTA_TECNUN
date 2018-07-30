using Tecnun.Applications.Model;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Applications.Adapters
{
    public class ProfessorAdapter
    {
        public static Professor ToDomainModel(ProfessorViewModel model)
        {
            var professor = new Professor(
                model.ProfessorId,
                model.Nome,
                model.DataNascimento,
                model.CPF,
                model.Telefone);

            return professor;
        }
    }
}
