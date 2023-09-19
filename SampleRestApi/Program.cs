using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleRestApi.Configurations;
using SampleRestApi.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentação Web API",
        Description = "Esta API é uma versão .Net Core da API desenvolvida por Venilton Falvo Jr.\nA versão original se encontra no repositório GitHub do DIO https://github.com/digitalinnovationone/santander-dev-week-2023-api/tree/main",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Karl Anderson",
            Email = "cantareamantisest@gmail.com",
            Url = new Uri("https://github.com/cantareamantisest")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SampleRestApi.xml"));
});

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    await DataHelper.ManageDataAsync(scope.ServiceProvider);
}

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