using IdentityServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseIdentityServer();

app.MapGet("/", () => "Hello, I'm identity server 4!");

app.Run();
