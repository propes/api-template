var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

// Expose the Program class for testing with the asp.net integration testing framework
public partial class Program { }
