using System;
using System.Threading.Tasks;

namespace YoutubeClone.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        void Commit();
        void Rollback();
    }
}
