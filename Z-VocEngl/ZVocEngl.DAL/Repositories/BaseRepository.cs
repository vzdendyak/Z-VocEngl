using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Repositories.Interfaces;

namespace ZVocEngl.DAL.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public AppDbContext _dbContext { get; set; }

        protected BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAllAsync()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}