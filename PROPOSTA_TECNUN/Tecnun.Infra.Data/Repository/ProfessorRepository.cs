using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Infra.Data.Context;

namespace Tecnun.Infra.Data.Repository
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        private DbConnection cn;

        public ProfessorRepository(TecnunContext context)
            : base(context)
        {
            cn = _context.Database.Connection;
        }

        public Professor AdicionarProfessor(Professor professor)
        {
            return Adicionar(professor);
        }

        public Professor AtualizarProfessor(Professor professor)
        {
            return Atualizar(professor);
        }

        public Professor BuscarProfessorPorId(Guid id)
        {
            var sql = @"SELECT *  FROM Professor AS a WHERE ProfessorId = @sid";
            var result = cn.Query<Professor, ProfessorDTO, Professor>(sql, (a, ad) =>
            {
                a = new Professor(a.ProfessorId, a.Nome, ad.DataNascimento, ad.CPF, ad.Telefone);
                return a;
            }, new { sid = id }, splitOn: "ProfessorId, DataNascimento").FirstOrDefault();

            return result;
        }

        public Professor ObterCpf(string cpf)
        {
            var sql = @"SELECT * FROM Aluno WHERE cpf = @scpf";
            var result = cn.Query<Professor, ProfessorDTO, Professor>(sql, (a, ad) =>
            {
                a = new Professor(a.ProfessorId, a.Nome, ad.DataNascimento, ad.CPF, ad.Telefone);
                return a;
            }, new { scpf = cpf }, splitOn: "AlunoId, CPF").FirstOrDefault();

            return result;
        }

        public Paged<ProfessorDTO> ObterTodosProfessores(string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT p.ProfessorId, p.Nome, p.DataNascimento, p.CPF, p.Telefone FROM Professor AS p " +
                      "WHERE  p.Nome LIKE @Spesquisa + '%' " +
                      "ORDER BY Nome ASC " +

                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                       " " +

                       "SELECT COUNT(p.ProfessorId) FROM Professor AS p " +
                       "WHERE  p.Nome LIKE @Spesquisa + '%' ";

            var multi = cn.QueryMultiple(sql, new { Spesquisa = descricao });
            var professor = multi.Read<ProfessorDTO>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<ProfessorDTO>()
            {
                List = professor,
                Count = total
            };

            return pagedList;
        }

        public void DeletarProfessor(Guid id)
        {
            Remover(id);
        }

        public List<Professor> BuscarTodosProfessores()
        {
            var sql = @"SELECT p.ProfessorId, p.Nome  FROM Professor AS p ";
            return cn.Query<Professor>(sql, new { }).ToList();
        }
    }
}
