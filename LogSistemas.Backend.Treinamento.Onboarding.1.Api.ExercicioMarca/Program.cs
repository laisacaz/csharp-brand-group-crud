using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Data;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.MapDb;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Middleware;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using MediatR;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;


try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

    builder.Host.UseSerilog(Log.Logger);

    //Config Mediator
    builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

    // Add services to the container
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/ OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Treinamento Onboarding" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);

        c.AddEnumsWithValuesFixFilters();
        c.ExampleFilters();
    });

    builder.Services.AddFluentValidationRulesToSwagger();
    builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

    Assembly? assembly = AppDomain.CurrentDomain.Load("LogSistemas.Backend.Treinamento.Onboarding.1.Api.ExercicioMarca");
    builder.Services.AddAutoMapper(assembly);

    builder.Services.AddValidatorsFromAssemblyContaining<Program>();

    builder.Services.AddSingleton<BrandDataBase>();
    builder.Services.AddSingleton<GroupDataBase>();

    builder.Services.AddScoped<PostgresConnection>();
    builder.Services.AddScoped<BrandRepository>();
    builder.Services.AddScoped<GroupRepository>();

    FluentMapper.Initialize(config =>
   {
       config.AddMap(new BrandMap());
       config.AddMap(new GroupMap());
       config.ForDommel();
   });
    WebApplication app = builder.Build();
    Log.Information("Aplicação buildada");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        Log.Information("Aplicação configurada com o swagger");
    }

    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
    Log.Information("Aplicação startada");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplicação com erro");
    throw;
}
finally
{
    Log.Information("Finalizando app");
    Log.CloseAndFlush();
}