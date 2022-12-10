using JwtSolution.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JwtSolution.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter);

        Task<T> GetById(int id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);

        Task Update(T entity);
        Task Add(T entity);
        Task Delete(T entity);
    }
}
