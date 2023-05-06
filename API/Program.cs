using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);     // ~/API/Extensions/ApplicationServiceExtensions.cs
builder.Services.AddIdentityServices(builder.Configuration);        // ~/API/Extensions/IdentityServiceExtensions.cs

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")); // hear back from Client

app.UseAuthentication();    // ask if user have valid token
app.UseAuthorization();     // got token, then decide what the user can do

app.MapControllers();

using var scope = app.Services.CreateScope();   // give us access to all the Services inside this Program.cs
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}
catch (Exception e)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(e, "An error occurred during migration");
}

app.Run();
