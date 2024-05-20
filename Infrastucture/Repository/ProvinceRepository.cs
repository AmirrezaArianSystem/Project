using Application.Commands;
using Application.Common.Intefaces;
using Application.Common.Mappeing;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repository
{
    public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository
    {

        private MappingGenerice _mapping { get; }
        private AutoMapper.IConfigurationProvider _configurationProvider { get; }

        public ProvinceRepository( MappingGenerice mapping, IConfigurationProvider configurationProvider ,CitiesAndProvincesContext context):base(context) 
        {
            _mapping = mapping;
            _configurationProvider = configurationProvider;
        }



        public async Task<List<ProvinceDto>> GetAllProvinceAsync(string? name )
        {
            var result = new List<ProvinceDto>();
            if (name == null)
                result = await _dbSet.ProjectTo<ProvinceDto>(_configurationProvider).AsNoTracking().ToListAsync();
            else
                result = await _dbSet.ProjectTo<ProvinceDto>(_configurationProvider).Where(n => n.Name.ToLower() == name.ToLower())
                    .AsNoTracking().ToListAsync();            
            return result;
        }

      

        public async Task<bool> ProvinceIsExist(string name)
        {
            return await _dbSet.Where(n => n.Name == name).AnyAsync();
        }
    }
}
