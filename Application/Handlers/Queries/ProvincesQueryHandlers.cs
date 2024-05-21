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
public class ProvincesGetQueryHandler : BaseHandler, IRequestHandler<ProvincesGetQuery, ResultObject<List<ProvinceDto>>>
{
    public ProvincesGetQueryHandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<List<ProvinceDto>>> Handle(ProvincesGetQuery request, CancellationToken cancellationToken)
    {
        List<ProvinceDto> provincesDto;
        var provinceRepository= IRepository<Province>();
        cancellationToken.ThrowIfCancellationRequested();
        if(request.name != null)
         provincesDto = await provinceRepository.GetAllAsync<ProvinceDto>(predicate: p => p.Name == request.name);
        else
         provincesDto = await provinceRepository.GetAllAsync<ProvinceDto>();

        var resultObject = new ResultObject<List<ProvinceDto>>();
        resultObject.Data = provincesDto;
        return resultObject;
    }
}
#endregion /Get Provinces Query Handler