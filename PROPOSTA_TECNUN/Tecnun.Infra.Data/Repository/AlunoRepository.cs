using Dapper;
using System;
using System.Data.Common;
using System.Linq;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces;
using Tecnun.Infra.Data.Context;

namespace Tecnun.Infra.Data.Repository
{
    public class AlunoRepository :  Repository<Aluno>, IAlunoRepository
    {
        private DbConnection cn;

        public AlunoRepository(TecnunContext context)
            : base(context)
        {
            cn = _context.Database.Connection;
        }

        public Aluno AdicionarAluno(Aluno aluno)
        {
            return Adicionar(aluno);
        }

        public Aluno AtualizarAluno(Aluno aluno)
        {
            return Atualizar(aluno);
        }

        public Aluno BuscarAlunoPorId(Guid id)
        {
            var sql = @"SELECT a.AlunoId, a.Nome, a.Data_Nascimento, a.CPF, a.Telefone, a.Email, a.Informacoes_Adicionais  FROM Aluno AS a WHERE AlunoId = @sid";
            var result = cn.Query<Aluno, AlunoDTO, Aluno>(sql, (a, ad) =>
            {
                a = new Aluno(a.AlunoId, a.Nome, ad.Data_Nascimento , ad.CPF, ad.Telefone, ad.Email, ad.Informacoes_Adicionais);
                return a;
            }, new { sid = id }, splitOn: "AlunoId, Data_Nascimento").FirstOrDefault();

            return result;
        }

        public Aluno ObterCpf(string cpf)
        {
            var sql = @"SELECT * FROM Aluno WHERE cpf = @scpf";
            var result = cn.Query<Aluno, AlunoDTO, Aluno>(sql, (a, ad) =>
            {
                a = new Aluno(a.AlunoId, a.Nome, ad.Data_Nascimento, ad.CPF, ad.Telefone, ad.Email, a.InformacoersAdicionais );
                return a;
            }, new { scpf = cpf }, splitOn: "AlunoId, CPF").FirstOrDefault();

            return result;
        }

        public Paged<AlunoDTO> ObterTodosAlunos(string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT a.AlunoId, a.Nome, a.Data_Nascimento, a.CPF, a.Telefone, a.Email, a.Informacoes_Adicionais  FROM Aluno AS a " +
                      "WHERE  a.Nome LIKE @Spesquisa + '%' " +
                      "ORDER BY Nome ASC " +

                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                       " " +

                       "SELECT COUNT(a.AlunoId) FROM Aluno AS a " +
                       "WHERE  a.Nome LIKE @Spesquisa + '%' ";

            var multi = cn.QueryMultiple(sql, new {Spesquisa = descricao });
            var aluno = multi.Read<AlunoDTO>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<AlunoDTO>()
            {
                List = aluno,
                Count = total
            };

            return pagedList;
        }

        public void DeletarAluno(Guid id)
        {
            Remover(id);
        }
    }
}
