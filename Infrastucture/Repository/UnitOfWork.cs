using Application.Common.Intefaces;
using Infrastucture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private CitiesAndProvincesContext _context { get; }
        public UnitOfWork(CitiesAndProvincesContext context)
        {
            _context = context;
        }
        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
