using Dapper;
using System;
using System.Data.Common;
using System.Linq;
using Tecnun.Dominio.DTO;
using Tecnun.Dominio.Entidades;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Infra.Data.Context;

namespace Tecnun.Infra.Data.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        private DbConnection cn;

        public TurmaRepository(TecnunContext context)
            : base(context)
        {
            cn = _context.Database.Connection;
        }


        public Turma AdicionarTurma(Turma turma)
        {
            return Adicionar(turma);
        }

        public Turma AtualizarTurma(Turma turma)
        {
            return Atualizar(turma);
        }

        public Turma BuscarTurmaPorId(Guid id)
        {
            var sql = @"SELECT *  FROM Turma AS t WHERE TurmaId = @sid";
            return cn.Query<Turma>(sql, new { sid = id }).FirstOrDefault();
        }

        public Paged<TurmaDTO> ObterTodasTurmas(string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT t.TurmaId, p.Nome, t.PeriodoTurma, t.DataTurma FROM Turma AS t " +
                      "INNER JOIN Professor AS p ON t.ProfessorId = p.ProfessorId " +
                      "WHERE  @Spesquisa IS NULL OR  " +
                      "p.Nome LIKE @Spesquisa + '%' OR " +
                      "t.PeriodoTurma LIKE @Spesquisa + '%' OR " +
                      "p.Nome LIKE @Spesquisa + '%' " +
                      "ORDER BY t.PeriodoTurma DESC " +

                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                       " " +

                      "SELECT COUNT(t.TurmaId) FROM Turma AS t " +
                      "INNER JOIN Professor AS p ON t.ProfessorId = p.ProfessorId " +
                      "WHERE  @Spesquisa IS NULL OR  " +
                      "t.PeriodoTurma LIKE @Spesquisa + '%' OR " +
                      "p.Nome LIKE @Spesquisa + '%'  ";

            var multi = cn.QueryMultiple(sql, new { Spesquisa = descricao });
            var aluno = multi.Read<TurmaDTO>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<TurmaDTO>()
            {
                List = aluno,
                Count = total
            };

            return pagedList;
        }
    }
}
