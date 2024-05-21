using Application.Commands;
using Application.Common;
using Application.Common.Intefaces;
using Application.Common.Mappeing;
using Application.Common.Models;
using Application.Common.Resourses;
using Domain.Entities;
using MediatR;


namespace Application.Handlers.Commands;



#region Create City Command Handler
public class CityCreateCommandHandler : BaseHandler, IRequestHandler<CityCreateCommand, ResultObject<Guid>>
{
    public CityCreateCommandHandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<Guid>> Handle(CityCreateCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<Guid>();
        try
        { 
            var cityRepository = _unitOfWork.GetRepository<City>();
            var cityIsExist = await cityRepository.ExistsAsync(city=>city.ProvinceId==request.ProvinceId&&city.Name==request.Name.Trim());

            if (cityIsExist)
            {
                resultObject.Errors = [string.Format(ErrorMessage.NameExists, request.Name)];
                return resultObject;
            }
            var city = _mappingGenerice.map<City>(request);
            await cityRepository.AddAsync(city);
            await _unitOfWork.CommitAsync(cancellationToken);
            resultObject.Data = city.Id;
            return resultObject;
        }

        catch
        {
            resultObject.Errors = [ErrorMessage.HandlError];
            return resultObject;
        }
    }

}


#endregion /Create City Command Handler

#region City delete command handler
public class Citydeletecommandhandler : BaseHandler, IRequestHandler<CityDeleteCommand, ResultObject<string>>
{
    public Citydeletecommandhandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<string>> Handle(CityDeleteCommand request, CancellationToken cancellationToken)
    {

        var resultObject = new ResultObject<string>();
        try
        {
            var cityRepository = _unitOfWork.GetRepository<City>();
            var city = await cityRepository.GetAsync(request.CityId);
            if (city == null)
            {
                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.CityId)];
                return resultObject;
            }
            if (city.ProvinceId != request.ProvinceId)
            {
                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.ProvinceId)];
                return resultObject;
            }
            cancellationToken.ThrowIfCancellationRequested();
            await cityRepository.DeleteAsync(city);
            await _unitOfWork.CommitAsync(cancellationToken);

            resultObject.Data = string.Format(ErrorMessage.Deleted, request.CityId);
            return resultObject;
        }
        catch
        {
            resultObject.Errors = [ErrorMessage.HandlError];
            return resultObject;
        }
    }
}
#endregion /city delete command handler

#region  Update City Command Handler
public class CityUpdateCommandHandler : BaseHandler, IRequestHandler<CityUpdateCommand, ResultObject<string>>
{
    public CityUpdateCommandHandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<string>> Handle(CityUpdateCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<string>();
        try
        {
            var cityRepository = _unitOfWork.GetRepository<City>();
            var city = await cityRepository.GetAsync(request.CityId);
            if (city == null)
            {
                resultObject.Errors = new();
                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.CityId)];
                return resultObject;
            }
            if (city.ProvinceId!=request.ProvinceId)
            {
                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.ProvinceId)];
                return resultObject;

            }
            city.Name = request.NameNowCity.Trim();
            cancellationToken.ThrowIfCancellationRequested();
            cityRepository.Uptate(city);
            await _unitOfWork.CommitAsync(cancellationToken);

            resultObject.Data = string.Format(ErrorMessage.Updated, request.CityId);
            return resultObject;
        }
        catch
        {
            resultObject.Errors = [ErrorMessage.HandlError];
            return resultObject;
        }
    }
}
#endregion / Update City CommandHandler



