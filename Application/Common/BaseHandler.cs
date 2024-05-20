using Application.Common.Intefaces;
using Application.Common.Mappeing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common;

public abstract class BaseHandler<T> where T : class
{
    protected IUnitOfWork _unitOfWork { get;}
    protected T _repository { get;  }
    protected MappingGenerice _mappingGenerice { get; }

    protected BaseHandler(IUnitOfWork unitOfWork, T repository, MappingGenerice mappingGenerice)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mappingGenerice = mappingGenerice;
    }
}