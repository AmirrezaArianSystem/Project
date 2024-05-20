using Application.Common.Models;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Intefaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(Guid id);
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    void Uptate(T entity);
    Task<bool> Exists(Guid id);
}
