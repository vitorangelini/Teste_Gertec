using Gertec.Application.Interfaces.Repositories;
using Gertec.CrossCutting.DependencyInjection;
using Gertec.Domain.Constants;
using Gertec.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRepositories(configuration);
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Gertec.Api", Version = "v1" });
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddMediator();
builder.Services.AddAutoMapper();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("../swagger/v1/swagger.json", $"{Dominios.Versao}");
});

app.UseHttpsRedirection();
app.UseMeuMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
