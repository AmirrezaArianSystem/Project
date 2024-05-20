
namespace Domain.Entities;

public class Province:BaseEntity
{
    public string? Name { get; set; }

    public int population { get; set; }  

    public virtual  ICollection<City> Citys { get; set; } 
}


