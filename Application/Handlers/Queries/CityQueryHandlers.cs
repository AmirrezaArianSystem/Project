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

#region CitiesGetQueryHandler
public class CitiesGetQueryHandler : BaseHandler, IRequestHandler<CitiesGetQuery, ResultObject<List<CityDto>>>
{
    private IConfigurationProvider _configurationProvider { get; }

    public CitiesGetQueryHandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<List<CityDto>>> Handle(CitiesGetQuery request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var cityRepository = _unitOfWork.GetRepository<City>();
        List<CityDto> citiesDto;
        if (request.name == null)       
             citiesDto = await cityRepository.GetAllAsync<CityDto>();    
        else
             citiesDto = await cityRepository.GetAllAsync<CityDto>(predicate:p=>p.Name==request.name);
        var resultObject = new ResultObject<List<CityDto>>();
        resultObject.Data = citiesDto; 
        return resultObject;
    }
}
#endregion /CitiesGetQueryHandler


