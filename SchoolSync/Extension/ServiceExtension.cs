using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Repositories.Interfaces;
using SchoolSync.DAL.Repositories.Queries;

namespace SchoolSync.Extension 
{
	public static class ServiceExtension
	{
		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)	
        {
            services.AddDbContext<SchoolSyncDbContext>(
                opts => opts.UseMySql(configuration.GetConnectionString("connString"), new MySqlServerVersion(new Version()),
                optss => optss.EnableRetryOnFailure()
            ));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void ConfigureServices(this IServiceCollection services){
            services.AddScoped<IDivision,QDivision>();
            services.AddScoped<IPosition,QPosition>();
        }

	}

}