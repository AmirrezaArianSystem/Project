using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappeing
{
    public class MappingGenerice
    {
        private IMapper _mapper { get; }

        public MappingGenerice(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TDestination map<TDestination>(object sourse) where TDestination : class
        {
           return _mapper.Map<TDestination>(sourse);
        }

    }
}
