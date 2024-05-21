using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands;


#region Create City Command
public class CityCreateCommand : IRequest<ResultObject<Guid>>
{
    [Required(AllowEmptyStrings =false)]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required(AllowEmptyStrings = false)] 
    public Guid ProvinceId { get; set; }

}

#endregion /Create City Command

#region Delete City Command
public class CityDeleteCommand : IRequest<ResultObject<string>>
{
    [Required(AllowEmptyStrings = false)]
    public Guid CityId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public Guid ProvinceId { get; set; }
}
#endregion /Delete City Command

#region Full Update City Command
public class CityUpdateCommand : IRequest<ResultObject<string>>
{
    [Required(AllowEmptyStrings = false)]
    public Guid CityId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public Guid ProvinceId { get; set; }
    [Required(AllowEmptyStrings = false)]
    [MaxLength(100)]
    public string NameNowCity { get; set; }

}
#endregion /Full Update City Command

