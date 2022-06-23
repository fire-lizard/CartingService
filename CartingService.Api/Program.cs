using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    
    config.ApiVersionReader = ApiVersionReader.Combine(
        // The Default versioning mechanism which reads the API version from the "api-version" Query String paramater.
        new QueryStringApiVersionReader("api-version"),
        // Use the following, if you would like to specify the version as a custom HTTP Header.
        new HeaderApiVersionReader("Accept-Version"),
        // Use the following, if you would like to specify the version as a Media Type Header.
        new MediaTypeApiVersionReader("api-version")
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiVersioning();

app.MapControllers();

app.Run();