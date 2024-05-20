using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries;

#region Get Provinces Query
public record ProvincesGetQuery(string? name) : IRequest<ResultObject<List<ProvinceDto>>>;
#endregion /Get Provinces Query

