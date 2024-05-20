using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries;


    public record CitiesGetQuery(string name) : IRequest<ResultObject<List<CityDto>>>;

