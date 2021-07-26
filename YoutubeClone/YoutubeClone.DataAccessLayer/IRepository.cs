using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeClone.DataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IList<TEntity> GetAll();
        TEntity GetById(Guid id); 
        void Edit(TEntity entityToUpdate);
        void Remove(TEntity entityToDelete);
    }
}