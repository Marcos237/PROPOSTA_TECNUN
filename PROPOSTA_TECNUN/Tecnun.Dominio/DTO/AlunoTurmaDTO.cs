using System;

namespace Tecnun.Dominio.DTO
{
    public class AlunoTurmaDTO
    {
        public Guid AlunoTurmaId  { get; set; }

        public Guid TurmaId { get; set; }

        public string Nome { get; set; }

        public string PeriodoTurma { get; set; }


    }
}
