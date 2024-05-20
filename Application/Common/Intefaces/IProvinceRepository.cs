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
    public interface IProvinceRepository:IGenericRepository<Province>
    {
         Task<List<ProvinceDto>> GetAllProvinceAsync(string? name );
        Task<bool> ProvinceIsExist(string name);
        
    }
}
