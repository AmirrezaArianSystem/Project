using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands;

#region Create Province Command
public class ProvinceCreateCommand : IRequest<ResultObject<Guid>>
{
    [Required(AllowEmptyStrings = false)]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required(AllowEmptyStrings = false)]
    [Range(minimum:500000,maximum:1000000000)]
    public int Population { get; set; }
}
#endregion /Create Province Command

#region Delete Province Command
public class ProvinceDeleteCommand : IRequest<ResultObject<string>>
{
    [Required(AllowEmptyStrings = false)]
    public Guid Id { get; set; }
}
#endregion /Delete Province Command

#region Full Update Province Command
public class ProvinceUpdateCommand : IRequest<ResultObject<string>>
{
    [Required(AllowEmptyStrings = false)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required(AllowEmptyStrings = false)]
    [Range(minimum: 500000, maximum: 1000000000)]
    public int Population { get; set; }

}
#endregion
