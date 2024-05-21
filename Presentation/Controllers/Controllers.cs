using Application.Commands;
using Application.Common.Intefaces;
using Application.Common.Models;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

#region City Controller
[Route("api/City")]
[ApiController]
public class CityController : ControllerBase
{
    #region properties
    private IMediator _mediatR { get; }
    #endregion

    #region Constructor
    public CityController(IMediator mediatR)
    {
        _mediatR = mediatR;
    }
    #endregion /Constructor

    [HttpGet]
    public async Task<ResultObject<List<CityDto>>> GetCities(string? name, CancellationToken cancellationToken)
    {
        var resultObject = await _mediatR.Send(new CitiesGetQuery(name),cancellationToken);
        return resultObject;
    }
    [HttpPost]
    public async Task<ResultObject<Guid>> CreateCity([FromBody] CityCreateCommand cityCreateCommand, CancellationToken cancellationToken)
    {
        var result = await _mediatR.Send(cityCreateCommand, cancellationToken);
        return result;
    }
    [HttpDelete]
    public async Task<ResultObject<string>> DeleteCity([FromBody] CityDeleteCommand cityDeleteCommand, CancellationToken cancellationToken)
    {
        var resultObject = await _mediatR.Send(cityDeleteCommand, cancellationToken);

        return resultObject;
    }

    [HttpPut]
    public async Task<ResultObject<string>> UpdateCity([FromBody] CityUpdateCommand cityUpdateCommand, CancellationToken cancellationToken)
    {
        var resultObject = await _mediatR.Send(cityUpdateCommand, cancellationToken);
        return resultObject;
    }

}



#endregion /City Controller


#region Province Controller
[Route("api/[controller]")]
[ApiController]
public class ProvinceController : ControllerBase
{
    private IMediator _mediator { get; }
    public ProvinceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ResultObject<List<ProvinceDto>>> GetProvinces(string? name,CancellationToken cancellationToken)
    {
        var resultObject = await _mediator.Send(new ProvincesGetQuery(name), cancellationToken);
        //if(cancellationToken.IsCancellationRequested)
        //    Console.WriteLine("in controller");
        return resultObject;
    }
    [HttpPost]
    public async Task<ResultObject<Guid>> CreateProvince([FromBody] ProvinceCreateCommand provinceCreateCommand, CancellationToken cancellationToken)
    {
        var resultObject = await _mediator.Send(provinceCreateCommand,cancellationToken);
        return resultObject;
    }
    [HttpDelete]
    public async Task<ResultObject<string>> DeleteProvince([FromBody] ProvinceDeleteCommand provinceDeleteCommand, CancellationToken cancellationToken)
    {     
       var resultObject= await _mediator.Send(provinceDeleteCommand, cancellationToken);
        return resultObject;
    }
    [HttpPut]
    public async Task<ResultObject<string>> UpdateProvince([FromBody] ProvinceUpdateCommand provinceUpdateCommand, CancellationToken cancellationToken)
    {
        var resultObject = await _mediator.Send(provinceUpdateCommand, cancellationToken);
        return resultObject;
    }

}

#endregion /Province Controller
