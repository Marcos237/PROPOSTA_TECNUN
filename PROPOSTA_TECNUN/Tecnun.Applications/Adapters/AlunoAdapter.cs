using Tecnun.Applications.Model;
using Tecnun.Dominio.Entidades;

namespace Tecnun.Applications.Adapters
{
    public class AlunoAdapter
    {
        public static Aluno ToDomainModel(AlunoViewModel model)
        {
            var aluno = new Aluno(
                model.AlunoId,
                model.Nome,
                model.Data_Nascimento,
                model.CPF,
                model.Telefone,
                model.Email,
                model.Informacoes_Adicionais);

            return aluno;
        }
    }
}
