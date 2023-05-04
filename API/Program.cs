using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);     // ~/API/Extensions/ApplicationServiceExtensions.cs
builder.Services.AddIdentityServices(builder.Configuration);        // ~/API/Extensions/IdentityServiceExtensions.cs

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")); // hear back from Client

app.UseAuthentication();    // ask if user have valid token
app.UseAuthorization();     // got token, then decide what the user can do

app.MapControllers();

app.Run();
