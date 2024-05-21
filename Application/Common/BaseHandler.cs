using Application.Common.Intefaces;
using Application.Common.Mappeing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common;

public abstract class BaseHandler  
{
    protected IUnitOfWork _unitOfWork { get;}
    protected MappingGenerice _mappingGenerice { get; }

    protected BaseHandler(IUnitOfWork unitOfWork,  MappingGenerice mappingGenerice)
    {
        _unitOfWork = unitOfWork;
        _mappingGenerice = mappingGenerice;
    }
}