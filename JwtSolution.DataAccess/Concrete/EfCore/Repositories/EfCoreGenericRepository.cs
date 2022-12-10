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
        public async Task Add(T entity)
        {
            using DatabaseContext context = new();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            using DatabaseContext context = new();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            using DatabaseContext context = new();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            using DatabaseContext context = new();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using DatabaseContext context = new();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetById(int id)
        {
            using DatabaseContext context = new();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            using DatabaseContext context = new();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
