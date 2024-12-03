using Hotel.DataAccess;
using Hotel.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace Hotel.WebAPI.IoC
{
    public static class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, HotelSettings settings)
        {
            services.AddDbContextFactory<HotelDbContext>(
                options => { options.UseSqlServer(settings.HotelDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<HotelDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
        }
    }
}
