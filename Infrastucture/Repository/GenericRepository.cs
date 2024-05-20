using Application.Common.Intefaces;
using Domain;
using Domain.Entities;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastucture.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbSet<T> _dbSet { get; set; }
        private CitiesAndProvincesContext _context { get; }
        public GenericRepository( CitiesAndProvincesContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity )
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            //var entity = await GetAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task<bool> Exists(Guid id)
        {
         
            var entity =  await _dbSet.Where(n=>n.Id==id).AnyAsync();
            return entity ;
        }

        public async Task<T?> GetAsync(Guid id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbSet.FindAsync(id);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public void Uptate(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}




