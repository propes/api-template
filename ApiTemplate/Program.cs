using ApiTemplate.DI;
using ApiTemplate.Endpoints;
using ApiTemplate.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEndpoint, GetProductsEndpoint>();

var app = builder.Build();

app.MapEndpoints();

app.Run();

// Expose the Program class for testing with the asp.net integration testing framework
public partial class Program { }
