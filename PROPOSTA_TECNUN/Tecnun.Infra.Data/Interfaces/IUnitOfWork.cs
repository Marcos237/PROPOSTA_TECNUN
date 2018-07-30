using System;

namespace Tecnun.Infra.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
    }
}
