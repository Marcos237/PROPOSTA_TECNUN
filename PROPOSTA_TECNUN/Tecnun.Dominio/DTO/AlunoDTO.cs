using System;

namespace Tecnun.Dominio.DTO
{
    public class AlunoDTO
    {
        public Guid AlunoId { get;  set; }
        public string Nome { get;  set; }
        public DateTime Data_Nascimento { get;  set; }
        public string CPF { get; private set; }
        public string Telefone { get;  set; }
        public string Email { get;  set; }
        public string Informacoes_Adicionais { get; set; }

    }
}
