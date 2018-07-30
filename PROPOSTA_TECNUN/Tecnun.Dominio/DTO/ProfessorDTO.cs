using System;

namespace Tecnun.Dominio.DTO
{
    public class ProfessorDTO
    {
        public Guid ProfessorId { get;  set; }
        public string Nome { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string CPF { get;  set; }
        public string Telefone { get; set; }
    }
}
