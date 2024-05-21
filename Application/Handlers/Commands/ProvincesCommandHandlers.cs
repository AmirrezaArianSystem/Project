using Application.Commands;
using Application.Common;
using Application.Common.Intefaces;
using Application.Common.Mappeing;
using Application.Common.Models;
using Application.Common.Resourses;
using Domain;
using Domain.Entities;
using MediatR;


namespace Application.Handlers.Commands;

#region Create Province Command Handler
public class ProvinceCreateCommandHandler : BaseHandler, IRequestHandler<ProvinceCreateCommand, ResultObject<Guid>>
{
    public ProvinceCreateCommandHandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<Guid>> Handle(ProvinceCreateCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<Guid>();
        try
        {
            var provinceRepository = _unitOfWork.GetRepository<Province>();

            var provinceIsExist = await provinceRepository.ExistsAsync(province=>province.Name== request.Name.Trim());
            if (provinceIsExist)
            {
                resultObject.Errors = [string.Format(ErrorMessage.NameExists, request.Name)];
                return resultObject;

            }

            var province = _mappingGenerice.map<Province>(request);
            await provinceRepository.AddAsync(province);
            await _unitOfWork.CommitAsync(cancellationToken);
            resultObject.Data = province.Id;
            return resultObject;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            resultObject.Errors = [ErrorMessage.HandlError];
            return resultObject;
        }

    }
}
#endregion /Create Province Command Handler

#region Delete Province Command Handler
public class ProvinceDeleteCommandHandler : BaseHandler, IRequestHandler<ProvinceDeleteCommand, ResultObject<string>>
{
    public ProvinceDeleteCommandHandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<string>> Handle(ProvinceDeleteCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<string>();
        try
        {
            var provinceRepository = _unitOfWork.GetRepository<Province>();
            cancellationToken.ThrowIfCancellationRequested();
            var province = await provinceRepository.GetAsync(request.Id);
            if (province == null)
            {
                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.Id)];
                return resultObject;
            }
            var cityRepository = _unitOfWork.GetRepository<City>();
            var cityIsExist = await cityRepository.ExistsAsync(selector:s=>s.ProvinceId==province.Id);
            if (cityIsExist)
            {
                resultObject.Errors = [ErrorMessage.CityExistForDeleteProvince];
                return resultObject;
            }
            await provinceRepository.DeleteAsync(province);
            await _unitOfWork.CommitAsync(cancellationToken);
            resultObject.Data = string.Format(ErrorMessage.Deleted, request.Id);
            return resultObject;
        }
        catch
        {
            resultObject.Errors = [ErrorMessage.HandlError];
            return resultObject;
        }
    }
}
#endregion /Delete Province Command Handler

#region  Update Province Handler
public class UpdateProvinceHandler : BaseHandler, IRequestHandler<ProvinceUpdateCommand, ResultObject<string>>
{
    public UpdateProvinceHandler(IUnitOfWork unitOfWork, MappingGenerice mappingGenerice) : base(unitOfWork, mappingGenerice)
    {
    }

    public async Task<ResultObject<string>> Handle(ProvinceUpdateCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<string>();
        try
        {
            var provinceRepository = _unitOfWork.GetRepository<Province>();

            var province = await provinceRepository.GetAsync(request.Id);
            if (province == null)
            {
                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.Id)];
                return resultObject;

            }
           _mappingGenerice._mapper.Map(request,province,typeof(ProvinceUpdateCommand),typeof(Province));
         
            provinceRepository.Uptate(province);
            await _unitOfWork.CommitAsync(cancellationToken);
            resultObject.Data = string.Format(ErrorMessage.Updated, request.Id);
            return resultObject;
        }
        catch
        {
            resultObject.Errors = [ErrorMessage.HandlError];
            return resultObject;
        }
    }
}
#endregion  Update Province Handler