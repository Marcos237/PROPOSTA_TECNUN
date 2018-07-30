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
    public class AlunoTurmaRepository : Repository<AlunoTurma>, IAlunoTurmaRepository
    {
        private DbConnection cn;

        public AlunoTurmaRepository(TecnunContext context)
            : base(context)
        {
            cn = _context.Database.Connection;
        }

        public AlunoTurma AdicionarAlunoTurma(AlunoTurma alunoturma)
        {
            return Adicionar(alunoturma);
        }

        public Paged<AlunoTurmaDTO> BuscarAlunoTurma(string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT t.TurmaId,  t.PeriodoTurma, a.Nome, at.AlunoturmaId FROM Professor AS p " +
          "INNER JOIN Turma AS t ON p.ProfessorId = t.ProfessorId INNER JOIN AlunoTurma AS at ON t.TurmaId = at.TurmaId " +
          "INNER JOIN Aluno AS a ON  at.AlunoId = a.AlunoId "+
          "WHERE  @Spesquisa IS NULL OR  " +
          "a.Nome LIKE @Spesquisa + '%' OR " +
          "t.PeriodoTurma LIKE @Spesquisa + '%' " +
          "ORDER BY a.Nome ASC " +

          "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
          "FETCH NEXT " + pageSize + " ROWS ONLY " +
           " " +

          "SELECT COUNT(t.TurmaId) FROM Professor AS p " +
          "INNER JOIN Turma AS t ON p.ProfessorId = t.ProfessorId INNER JOIN AlunoTurma AS at ON t.TurmaId = at.TurmaId " +
          "INNER JOIN Aluno AS a ON  at.AlunoId = a.AlunoId " +
          "WHERE  @Spesquisa IS NULL OR  " +
          "a.Nome LIKE @Spesquisa + '%' OR " +
          "t.PeriodoTurma LIKE @Spesquisa + '%' ";

            var multi = cn.QueryMultiple(sql, new { Spesquisa = descricao });
            var alunoturma = multi.Read<AlunoTurmaDTO>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<AlunoTurmaDTO>()
            {
                List = alunoturma,
                Count = total
            };

            return pagedList;
        }

        public AlunoTurma BuscarAlunoturmaPorIds(Guid alunoid, Guid turmaid)
        {
            var sql = @"SELECT AlunoId, TurmaId FROM AlunoTurma WHERE AlunoId = @salunoid AND TurmaId = @sturmaid";
            return cn.Query<AlunoTurma>(sql, new { salunoid = alunoid, sturmaid = turmaid }).FirstOrDefault();
        }
    }
}