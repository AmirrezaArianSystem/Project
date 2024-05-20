using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistence;

public class CitiesAndProvincesContext : DbContext
{
    public CitiesAndProvincesContext(
        DbContextOptions<CitiesAndProvincesContext> options) : base(options)

    {
        Database.EnsureCreated();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(new City()
        {
            Id = Guid.NewGuid(),
            Name = "tehran",
            ProvinceId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
        },
            new City()
            {
                Id = Guid.NewGuid(),
                Name = "pardis",
                ProvinceId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
            },
            new City()
            {
                Id = Guid.NewGuid(),
                Name = "hamedan",
                ProvinceId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
            },
            new City()
            {
                Id = Guid.NewGuid(),
                Name = "malayer",
                ProvinceId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
            });
        modelBuilder.Entity<Province>().HasData(
            new Province()
            {
                Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                Name = "tehran",
                population = 100000000

            },

           new Province()
           {
               Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
               Name = "hamedan",
               population = 200000000
           });
        modelBuilder.ApplyConfiguration<Province>(new ProvinceConfiguration());
    }


    public DbSet<City> Cities { get; set; }
    public DbSet<Province> Provinces { get; set; }

}
