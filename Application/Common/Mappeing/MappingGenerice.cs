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
        public IMapper _mapper { get; }

        public MappingGenerice(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TDestination map<TDestination>(object sourse) 
        {
            return _mapper.Map<TDestination>(sourse);
        }

    }
}
