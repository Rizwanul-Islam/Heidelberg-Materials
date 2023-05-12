using FastEndpoints.Swagger;
using SpaceXLaunchService.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    _ = builder.Configuration
    .AddJsonFile($"{AppDomain.CurrentDomain.BaseDirectory}/appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"{AppDomain.CurrentDomain.BaseDirectory}/appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
}

// Add services to the container.
_ = builder.Services.AddApplicationServices();
_ = builder.Services.AddApiServices(builder.Configuration);
_ = builder.Services.AddOutputCache(options =>
    {
        options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(3600)));
    });
_ = builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin", builder =>
        {
            builder.AllowAnyOrigin() // Allow all origins
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    });

builder.Services.AddSwaggerDoc(maxEndpointVersion: 1, tagIndex: 0, settings: x =>
{
    x.DocumentName = "Release 1.0";
    x.Title = "SpaceX Launch Service";
    x.Version = "1.0";
});

var app = builder.Build();

_ = app.UseMiddleware<ExceptionHandlingMiddleware>();
_ = app.UseCors("AllowOrigin"); // Enable CORS
_ = app.UseFastEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.Run();