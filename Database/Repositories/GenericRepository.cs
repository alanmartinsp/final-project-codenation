using Business.Models;
using Business.Repositories;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Repositories
{
    public class GenericRepository<T> : IRepository<T>, IDisposable where T : Model
    {

        protected readonly LocalContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(LocalContext context)
        {
            _context = context;
        }

        protected bool BeginTransaction()
        {
            if (_context.Database.CurrentTransaction == null)
            {
                _context.Database.BeginTransaction();
                return true;
            }

            return false;
        }

        protected void RollbackTransaction()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }

        protected void CommitTransaction()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Save(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity null");

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity null");

            _context.Update(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity null");

            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
                _context.Set<T>().Attach(entity);

            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}