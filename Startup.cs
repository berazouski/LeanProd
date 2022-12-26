using LeanProd.Data;
using LeanProd.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LeanProd.Services;
namespace LeanProd
{
    internal static class Startup
    {
        public const string ConnectionStringName = "ConnectionString_TireService";

        public static void GatherServices(IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddMvcCore().AddRazorViewEngine();
            services.AddEndpointsApiExplorer();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            ConfigureDBContext(services, config);

            if (config["ASPNETCORE_ENVIRONMENT"] != "Development")
                {
                services.AddTransient<ICommodityService, StubCommodityService>();
            }
            else
            {
                services.AddTransient<ICommodityService, CommodityService>();
            }

            ;
        }

        private static void ConfigureDBContext(IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // var connectionString = config.GetConnectionString(ConnectionStringName);

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString);
            });
        }


        public static void MigrateDB(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

                if (dbContext == null)
                {
                    throw new SystemException("This should never happen, the DbContext couldn't recolve!");
                }

                dbContext.Database.Migrate();
            }
        }
    }
}
