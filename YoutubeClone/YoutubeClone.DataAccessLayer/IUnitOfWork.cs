using System;
using System.Threading.Tasks;

namespace YoutubeClone.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
