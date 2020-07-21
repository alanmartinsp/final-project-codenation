using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public interface IRepository<TModel> : IDisposable where TModel : class
    {

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel Get(int id);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        void Save(TModel entity);

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        void Update(TModel entity);

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TModel entity);

    }
}
