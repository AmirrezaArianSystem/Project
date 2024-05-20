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
public class ProvinceCreateCommandHandler : BaseHandler<IProvinceRepository>,IRequestHandler<ProvinceCreateCommand, ResultObject<Guid>>
{
    private IGenericRepository<BaseEntity> genericRepository { get; }
    public ProvinceCreateCommandHandler(IUnitOfWork unitOfWork, IProvinceRepository repository, MappingGenerice mappingGenerice) : base(unitOfWork, repository, mappingGenerice)
    {
    }

    public async Task<ResultObject<Guid>> Handle(ProvinceCreateCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<Guid>();
        try
        {
            var provinceIsExist = await _repository.ProvinceIsExist(request.Name);
            if (provinceIsExist)
            {
                resultObject.Errors = [string.Format(ErrorMessage.NameExists, request.Name)];
                return resultObject;

            }

            var province = _mappingGenerice.map<Province>(request);
            await _repository.AddAsync(province);
            await _unitOfWork.CommitAsync(cancellationToken);
            resultObject.Data = province.Id;
            return resultObject;
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            resultObject.Errors = [ErrorMessage.HandlError];
            return resultObject;
        }

    }
}
#endregion /Create Province Command Handler

#region Delete Province Command Handler
public class ProvinceDeleteCommandHandler : BaseHandler<IProvinceRepository>, IRequestHandler<ProvinceDeleteCommand, ResultObject<string>>
{
    private ICityRepository _cityRepository { get; }
    public ProvinceDeleteCommandHandler(IUnitOfWork unitOfWork, IProvinceRepository repository, MappingGenerice mappingGenerice, ICityRepository cityRepository) : base(unitOfWork, repository, mappingGenerice)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ResultObject<string>> Handle(ProvinceDeleteCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<string>();
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            var province = await _repository.GetAsync(request.Id);
            if (province == null)
            {
                resultObject.Errors = [string.Format(ErrorMessage.DoesNotExist, request.Id)];
                return resultObject;
            }
            cancellationToken.ThrowIfCancellationRequested();
            var cityIsExist=await _cityRepository.CityIsExist(request.Id,null);
            if (cityIsExist)
            {
                resultObject.Errors = [ErrorMessage.CityExistForDeleteProvince];
                return resultObject;
            }
            await _repository.DeleteAsync(province);
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
public class UpdateProvinceHandler : BaseHandler<IProvinceRepository>, IRequestHandler<ProvinceUpdateCommand, ResultObject<string>>
{
    public UpdateProvinceHandler(IUnitOfWork unitOfWork, IProvinceRepository repository, MappingGenerice mappingGenerice) : base(unitOfWork, repository, mappingGenerice)
    {
    }

    public async Task<ResultObject<string>> Handle(ProvinceUpdateCommand request, CancellationToken cancellationToken)
    {
        var resultObject = new ResultObject<string>();
        try
        {         
            var province = await _repository.GetAsync(request.Id);
            if (province == null)
            {
                resultObject.Errors =[string.Format(ErrorMessage.DoesNotExist, request.Id)];
                return resultObject;

            }
            province.Name = request.Name;
            province.population = request.Population;
            _repository.Uptate(province);
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