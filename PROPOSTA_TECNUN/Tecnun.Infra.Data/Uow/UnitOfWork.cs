using System;
using Tecnun.Infra.Data.Context;
using Tecnun.Infra.Data.Interfaces;

namespace Tecnun.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private TecnunContext _context;
        private bool _disposed;


        public UnitOfWork(TecnunContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.GetValidationErrors();
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}