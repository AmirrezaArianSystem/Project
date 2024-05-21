using Application.Common.Intefaces;
using AutoMapper;
using Domain;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastucture.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private  CitiesAndProvincesContext _context { get; }
        private bool disposed = false;
        private Dictionary<Type, object> repositories;
        private bool disposedValue;
        private TransactionScope transaction;

        private IConfigurationProvider _configurationProvider { get; }


        public UnitOfWork(CitiesAndProvincesContext context, IConfigurationProvider configurationProvider)
        {
            _context = context;
            _configurationProvider = configurationProvider;
        }
        public void StartTransaction()
        {
            this.transaction = new TransactionScope();
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }



            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new GenericRepository<TEntity>(_context, _configurationProvider);
            }
            return (IGenericRepository<TEntity>)repositories[type];
        }
        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public  void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
