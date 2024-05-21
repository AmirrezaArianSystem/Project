using Application.Common.Models;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Intefaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    void Uptate(TEntity entity);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> selector = null);
    Task<List<TResult>> GetAllAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true, bool ignoreQueryFilters = false);
    Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                          Expression<Func<TEntity, bool>> predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool disableTracking = true, bool ignoreQueryFilters = false);
}

