using Application.Common;
using Application.Common.Intefaces;
using Application.Common.Mappeing;
using Application.Common.Models;
using Application.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Queries;

#region Get Provinces Query Handler
public class ProvincesGetQueryHandler : BaseHandler<IProvinceRepository>, IRequestHandler<ProvincesGetQuery, ResultObject<List<ProvinceDto>>>
{
    public ProvincesGetQueryHandler(IUnitOfWork unitOfWork, IProvinceRepository repository, MappingGenerice mappingGenerice) : base(unitOfWork, repository, mappingGenerice)
    {
    }

    public async Task<ResultObject<List<ProvinceDto>>> Handle(ProvincesGetQuery request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await _repository.GetAllProvinceAsync(request.name);
        var resultObject = new ResultObject<List<ProvinceDto>>();
        resultObject.Data = result;
        return resultObject;
    }
}
#endregion /Get Provinces Query Handler