using JwtSolution.DataAccess.Abstract;
using JwtSolution.DataAccess.Concrete.EfCore.Context;
using JwtSolution.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JwtSolution.DataAccess.Concrete.EfCore.Repositories
{
    public class EfCoreGenericRepository<T> : IGenericDal<T> where T : class, IEntity, new()
    {
        public async Task AddAsync(T entity)
        {
            using DatabaseContext context = new();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            using DatabaseContext context = new();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            using DatabaseContext context = new();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using DatabaseContext context = new();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using DatabaseContext context = new();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using DatabaseContext context = new();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            using DatabaseContext context = new();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
