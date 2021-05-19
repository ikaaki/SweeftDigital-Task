using Microsoft.EntityFrameworkCore;
using SweeftDigital.Task.Domain.Entities;
using SweeftDigital.Task.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Infrastructure.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SweeftDigitalTaskDbContext _context;

        public Repository(SweeftDigitalTaskDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return entity.Id;
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            foreach (var item in _context.ChangeTracker.Entries<BaseEntity>().Where(item => item.State == EntityState.Added))
            {
                item.Entity.DateCreated = DateTime.UtcNow;
            }

            var result = await _context.SaveChangesAsync();

            return true;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
