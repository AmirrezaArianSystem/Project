//using Application.Commands;
//using Application.Common;
//using Application.Common.Intefaces;
//using Application.Common.Mappeing;
//using Application.Common.Models;
//using Application.Common.Resourses;
//using Domain.Entities;
//using MediatR;


//namespace Application.Handlers.Commands;



//#region Create City Command Handler
//public class CityCreateCommandHandler :BaseHandler<ICityRepository>, IRequestHandler<CityCreateCommand, ResultObject<Guid>>
//{
//    private IProvinceRepository _provinceRepository { get; }
//    public CityCreateCommandHandler(IUnitOfWork unitOfWork, ICityRepository repository, MappingGenerice mappingGenerice, IProvinceRepository provinceRepository) : base(unitOfWork, repository, mappingGenerice)
//    {
//        _provinceRepository = provinceRepository;
//    }



//    public async Task<ResultObject<Guid>> Handle(CityCreateCommand request, CancellationToken cancellationToken)
//    {
//            var resultObject = new ResultObject<Guid>();
//        try
//        {

//            var province = await _provinceRepository.GetAsync(request.ProvinceId);
//            if (province == null)
//            {
//                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.ProvinceId)];
//                return resultObject;
//            }

//            var cityIsExist = await _repository.CityIsExist(request.ProvinceId, request.Name);

//            if (cityIsExist)
//            {
//                resultObject.Errors = [string.Format(ErrorMessage.NameExists,request.Name)];
//                return resultObject;
//            }
//            var city=_mappingGenerice.map<City>(request);
//            city.Province = province;
//            await _repository.AddAsync(city);
//            await _unitOfWork.CommitAsync(cancellationToken);
//            resultObject.Data = city.Id;
//            return resultObject;
//        }

//        catch
//        {
//            resultObject.Errors = [ErrorMessage.HandlError];
//            return resultObject;
//        }
//    }

//}


//#endregion /Create City Command Handler

//#region City delete command handler
//public class Citydeletecommandhandler :BaseHandler<ICityRepository>, IRequestHandler<CityDeleteCommand, ResultObject<string>>
//{
//    public Citydeletecommandhandler(IUnitOfWork unitOfWork, ICityRepository repository, MappingGenerice mappingGenerice) : base(unitOfWork, repository, mappingGenerice)
//    {
//    }

//    public async Task<ResultObject<string>> Handle(CityDeleteCommand request, CancellationToken cancellationToken)
//    {

//        var resultObject = new ResultObject<string>();
//        try
//        {

//            var city = await _repository.GetAsync(request.CityId);
//            if (city == null)
//            {
//                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.CityId)];
//                return resultObject;
//            }
//            if (city.ProvinceId != request.ProvinceId)
//            {
//                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.ProvinceId)];
//                return resultObject;
//            }
//            cancellationToken.ThrowIfCancellationRequested();
//            await _repository.DeleteAsync(city);
//            await _unitOfWork.CommitAsync(cancellationToken);

//            resultObject.Data = string.Format(ErrorMessage.Deleted, request.CityId);
//            return resultObject;
//        }
//        catch
//        {
//            resultObject.Errors = [ErrorMessage.HandlError];
//            return resultObject;
//        }
//    }
//}
//#endregion /city delete command handler

//#region  Update City Command Handler
//public class CityUpdateCommandHandler : BaseHandler<ICityRepository>, IRequestHandler<CityUpdateCommand, ResultObject<string>>
//{
//    public CityUpdateCommandHandler(IUnitOfWork unitOfWork, ICityRepository repository, MappingGenerice mappingGenerice) : base(unitOfWork, repository, mappingGenerice)
//    {
//    }

//    public async Task<ResultObject<string>> Handle(CityUpdateCommand request, CancellationToken cancellationToken)
//    {
//        var resultObject = new ResultObject<string>();
//        try
//        {

//            var city = await _repository.GetAsync(request.CityId);
//            if (city == null)
//            {
//                resultObject.Errors = new();
//                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.CityId)];
//                return resultObject;
//            }
//            var provinceExists = await _repository.Exists(request.ProvinceId);
//            if (!provinceExists)
//            {
//                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.ProvinceId)];
//                return resultObject;

//            }
//            city.Name = request.NameNowCity.Trim();
//            cancellationToken.ThrowIfCancellationRequested();
//            _repository.Uptate(city);
//            await _unitOfWork.CommitAsync(cancellationToken);

//            resultObject.Data = string.Format(ErrorMessage.Updated, request.CityId);
//            return resultObject;
//        }
//        catch
//        {
//            resultObject.Errors = [ErrorMessage.HandlError];
//            return resultObject;
//        }
//    }
//}
//#endregion / Update City CommandHandler



