//using Application.Commands;
//using Application.Common.Intefaces;
//using Application.Common.Mappeing;
//using Application.Common.Models;
//using Application.Queries;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using Domain.Entities;
//using Infrastucture.Persistence;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastucture.Repository;

//public class CityRepository : GenericRepository<City>, ICityRepository
//{

//    private MappingGenerice _mapping { get; }
//    private IConfigurationProvider _configurationProvider { get; }
//    public CityRepository(MappingGenerice mapping, IConfigurationProvider configurationProvider, CitiesAndProvincesContext context) : base(context)
//    {
//        _mapping = mapping;
//        _configurationProvider = configurationProvider;
//    }




//    public async Task<List<CityDto>> GetAllCityAsync(string? name)
//    {
//        var result = new List<CityDto>();
//        if (name == null)
//            result = await _dbSet.ProjectTo<CityDto>(_configurationProvider).AsNoTracking().ToListAsync();
//        else
//            result = await _dbSet.ProjectTo<CityDto>(_configurationProvider).Where(n => n.Name == name.ToLower()).AsNoTracking()
//               .ToListAsync();
//        return result;
//    }

//    public async Task<bool> CityIsExist(Guid ProvinceId, string? Name)
//    {
//        if (Name != null)
//        {
//            var cityIsExist = await _dbSet.Where(n =>
//                n.ProvinceId == ProvinceId &&
//                n.Name == Name.Trim()).AnyAsync();
//            return cityIsExist;
//        }
//        else
//        {
//            var cityIsExist = await _dbSet.Where(n =>
//          n.ProvinceId == ProvinceId).AnyAsync();
//            return cityIsExist;

//        }
//    }





//    //public async Task<ResultObject<string>> UpdateCity(CityUpdateCommand request)
//    //{
//    //    var resultObject = new ResultObject<string>();
//    //    try
//    //    {
//    //        if (!Guid.TryParse(request.ProvinceId, out Guid provinceGuid))
//    //        {
//    //            resultObject.Errors = [$"ProvinceId not valid"];
//    //            return resultObject;
//    //        }
//    //        if (!Guid.TryParse(request.CityId, out Guid cityGuid))
//    //        {
//    //            resultObject.Errors = [$"CityId not valid"];
//    //            return resultObject;
//    //        }
//    //        var city = await GetAsync(cityGuid);
//    //        if (city == null)
//    //        {
//    //            resultObject.Errors = new();
//    //            resultObject.Errors = [$"there is no Id {request.CityId}"];
//    //            return resultObject;
//    //        }
//    //        var provinceExists = await _provinceRepository.Exists(provinceGuid);
//    //        if (!provinceExists)
//    //        {
//    //            resultObject.Errors = [$"there is no Province {request.ProvinceId}"];
//    //            return resultObject;

//    //        }
//    //        city.Name = request.NameNowCity;
//    //        await UptateAsync(city);
//    //        resultObject.Data = $"city {request.CityId} Updateed";
//    //        return resultObject;
//    //    }
//    //    catch
//    //    {
//    //        resultObject.Errors = ["خطای ناخواسته ای رخ داد."];
//    //        return resultObject;
//    //    }

//    //}
//}
