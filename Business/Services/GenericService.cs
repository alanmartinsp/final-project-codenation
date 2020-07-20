using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class GenericService<T> where T : class
    {
        protected IRepository<T> _repository;

        public GenericService(IRepository<T> repo)
        {
            _repository = repo;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(string id)
        {
            return _repository.Get(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Save(T entity)
        {
            _repository.Save(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        /// <summary>
        /// </summary>
        public virtual void Dispose()
        {
            if (_repository != null)
                _repository.Dispose();
        }
    }
}
