using API.Data;
using API.Services;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // builder.Services.AddDbContext<DataContext>(opt =>
            //     {
            //         opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            //     });
            // builder.Services.AddCors();
            // builder.Services.AddScoped<ITokenService, TokenService>();

            // transform from (above) Program.cs to (below) extension
            services.AddDbContext<DataContext>(opt =>
                {
                    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();

            return services;
        }
    }
}