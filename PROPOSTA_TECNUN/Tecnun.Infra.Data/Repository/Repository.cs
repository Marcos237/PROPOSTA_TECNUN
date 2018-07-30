using System;
using System.Data.Entity;
using Tecnun.Dominio.Intefaces.Repository;
using Tecnun.Infra.Data.Context;

namespace Tecnun.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TecnunContext _context;
        protected DbSet<TEntity> DbSet;

        public Repository(TecnunContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }


        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = _context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}