using Application;
using Application.Common.Intefaces;
using Application.Common.Mappeing;
using Application.Common.Models;
using Domain;
using Humanizer;
using Infrastucture;
using Infrastucture.Persistence;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Controllers;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().
    ConfigureApiBehaviorOptions(setup =>
    setup.InvalidModelStateResponseFactory = context =>
    {
        var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
        var validationProblemDetails = problemDetailsFactory.CreateValidationProblemDetails(
            context.HttpContext,
            context.ModelState);
        validationProblemDetails.Detail = "see the errors fild details.";
        validationProblemDetails.Instance =
        context.HttpContext.Request.Path;

        validationProblemDetails.Type =
        "https://courselibrary.com/modelvalidationproblem";
        validationProblemDetails.Title =
        "One or more validtion errors occurred.";

        return new OkObjectResult(
            validationProblemDetails)
        {
            ContentTypes = { "application/problem+json" }
        };
    }
    //setup.SuppressModelStateInvalidFilter=true

    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapper).Assembly);
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssemblies(typeof(Mapper).Assembly);
});
builder.Services.AddDbContext<CitiesAndProvincesContext>(opt => opt.UseInMemoryDatabase("MyDatabase"));

builder.Services.AddScoped<ResultObject<object>>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICityRepository,CityRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<MappingGenerice>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
