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
public class CitiesGetQueryHandler :BaseHandler<ICityRepository>, IRequestHandler<CitiesGetQuery, ResultObject<List<CityDto>>>
{
    public CitiesGetQueryHandler(IUnitOfWork unitOfWork, ICityRepository repository, MappingGenerice mappingGenerice) : base(unitOfWork, repository, mappingGenerice)
    {
    }

    public async Task<ResultObject<List<CityDto>>> Handle(CitiesGetQuery request, CancellationToken cancellationToken)
    {    
        cancellationToken.ThrowIfCancellationRequested();
        var result = await _repository.GetAllCityAsync(request.name);
        var resultObject= new ResultObject<List<CityDto>>();
        resultObject.Data = result;
        return resultObject;
    }
}
#endregion /CitiesGetQueryHandler


