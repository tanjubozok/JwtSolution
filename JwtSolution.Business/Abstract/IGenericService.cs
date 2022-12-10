using JwtSolution.Entities.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JwtSolution.Business.Abstract
{
    public interface IGenericService<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
