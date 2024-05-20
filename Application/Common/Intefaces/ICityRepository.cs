using Application.Commands;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Intefaces
{
    public interface ICityRepository : IGenericRepository<City> 
    {
        Task<List<CityDto>> GetAllCityAsync(string? name);
        Task<bool> CityIsExist(Guid ProvinceId, string? Name);
    }
}
