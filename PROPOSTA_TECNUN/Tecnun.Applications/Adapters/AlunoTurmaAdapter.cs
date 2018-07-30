using System;
using Tecnun.Applications.Model;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Applications.Adapters
{
    public class AlunoTurmaAdapter
    {
        public static AlunoTurma ToDomainModel(AlunoTurmaVieModel model)
        {
            var alunoturma = new AlunoTurma(
              Guid.NewGuid(),
              model.AlunoId,
              model.TurmaId);

            return alunoturma;
        }
    }
}
