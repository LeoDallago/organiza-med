using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using OrganizaMed.WebApi;
using OrganizaMed.WebApi.Config.Mapping;
using OrganizaMed.WebApi.Filters;
using OrganizaMed.WebApi.Identity;

const string politicaCors = "politicaCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors(politicaCors);
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureAutoMapper();

builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<ResponseWrapperFilter>();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter());
        
        
    });

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.SwaggerConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(politicaCors);

app.UseAuthorization();

app.MapControllers();

app.Run();