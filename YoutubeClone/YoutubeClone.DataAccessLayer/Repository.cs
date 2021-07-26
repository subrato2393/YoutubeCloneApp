using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeClone.DataAccessLayer
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
      where TEntity : class
    {
        public ISession _session { get; private set; }

        public Repository(ISession session)
        {
            _session = session;
        }

        public virtual void Add(TEntity entity)
        {
            _session.Save(entity);
        }

        public virtual IList<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _session.Get<TEntity>(id);
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            _session.Save(entityToUpdate);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            _session.Delete(entityToDelete);
        }
    }
}