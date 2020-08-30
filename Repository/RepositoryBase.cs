using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
                RepositoryContext.Set<T>()
                    .AsNoTracking() :
                RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges) =>
            !trackChanges ?
                RepositoryContext.Set<T>()
                    .Where(expression)
                    .AsNoTracking() :
                RepositoryContext.Set<T>()
                    .Where(expression);

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        // Reference

        //#region Gets

        //public virtual IQueryable<T> GetAll()
        //{
        //    return RepositoryContext.Set<T>().AsQueryable();
        //}

        //public virtual T Get(params object[] id)
        //{
        //    return GetById(id);
        //}

        //public virtual T Get(Expression<Func<T, bool>> selector)
        //{
        //    return First(selector);
        //}

        //public virtual T GetById(params object[] id)
        //{
        //    return RepositoryContext.Set<T>().Find(id);
        //}

        //public virtual IQueryable<T> GetByIds(params object[] ids)
        //{
        //    return ids.Select(id => GetById(id))
        //              .Where(x => x != null)
        //              .AsQueryable();
        //}

        //public virtual T First(Expression<Func<T, bool>> predicate = null)
        //{
        //    return predicate == null
        //               ? RepositoryContext.Set<T>().FirstOrDefault()
        //               : RepositoryContext.Set<T>().FirstOrDefault(predicate);
        //}

        //public virtual int Count(Expression<Func<T, bool>> expression = null)
        //{
        //    return expression == null
        //               ? RepositoryContext.Set<T>().Count()
        //               : RepositoryContext.Set<T>().Count(expression);
        //}

        //public virtual IQueryable<T> Fetch(Expression<Func<T, bool>> expression)
        //{
        //    return RepositoryContext.Set<T>().Where(expression);
        //}

        //public virtual bool Any(Expression<Func<T, bool>> expression)
        //{
        //    return RepositoryContext.Set<T>().Any(expression);
        //}

        //public virtual bool All(Expression<Func<T, bool>> expression)
        //{
        //    return RepositoryContext.Set<T>().All(expression);
        //}

        //#endregion Gets

        //#region Insert

        //public virtual void Insert(T entity)
        //{
        //    var entityEntry = RepositoryContext.Entry(entity);

        //    if (entityEntry.State != EntityState.Detached)
        //    {
        //        entityEntry.State = EntityState.Added;
        //    }
        //    else
        //    {
        //        RepositoryContext.Set<T>().Add(entity);
        //    }
        //}

        //#endregion Insert

        //#region Update

        //public virtual void Update(T entity)
        //{
        //    var entityEntry = RepositoryContext.Entry(entity);

        //    if (entityEntry.State == EntityState.Detached)
        //    {
        //        RepositoryContext.Set<T>().Attach(entity);
        //    }

        //    entityEntry.State = EntityState.Modified;
        //}

        //#endregion Update

        //#region Delete

        //public virtual void Delete(T entity)
        //{
        //    try
        //    {
        //        ((dynamic)entity).IsDeleted = true;
        //        Update(entity);
        //    }
        //    catch
        //    {
        //        RepositoryContext.Set<T>().Remove(entity);
        //    }
        //}

        //public void HardDelete(T entity)
        //{
        //    RepositoryContext.Set<T>().Remove(entity);
        //}

        //public void HardDelete(IEnumerable<T> range)
        //{
        //    RepositoryContext.Set<T>().RemoveRange(range);
        //}

        //#endregion Delete
    }
}