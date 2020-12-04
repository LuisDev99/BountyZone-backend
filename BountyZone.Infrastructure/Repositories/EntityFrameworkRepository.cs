using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BountyZone.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly BountyZoneDbContext _dbContext;

        public EntityFrameworkRepository(BountyZoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public T GetByID(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Attach<T>(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public void Patch<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression)
        {
            _dbContext.Attach(entity);

            _dbContext.Entry(entity).Property(propertyExpression).IsModified = true;

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}

