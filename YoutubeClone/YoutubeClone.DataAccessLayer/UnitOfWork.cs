using NHibernate;
using System.Threading.Tasks;

namespace YoutubeClone.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction _transaction;
        public ISession _session { get; private set; }

        public UnitOfWork(ISession session)
        {
            _session = session;
        }
        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Commit();
                }
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Rollback();
                }
            }
        }

        public void Rollback()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }

        public Task BeginTransaction()
        {
            return Task.Run(() =>
            { 
                _transaction = _session.BeginTransaction();
            });
        }
    }
}

