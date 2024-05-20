﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Intefaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
        Task Rollback();
    }
}