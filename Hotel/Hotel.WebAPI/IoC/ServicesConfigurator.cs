using AutoMapper;
using Hotel.BL.Admin;
using Hotel.BL.Auth;
using Hotel.BL.HotelRooms;
using Hotel.BL.User;
using Hotel.DataAccess;
using Hotel.DataAccess.Entities;
using Hotel.WebAPI.Settings;
using Microsoft.AspNetCore.Identity;

namespace Hotel.WebAPI.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureService(IServiceCollection services, HotelSettings settings)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAdminsProvider>(x =>
                new AdminsProvider(x.GetRequiredService<IRepository<AdminEntity>>(), x.GetRequiredService<IMapper>()));

            services.AddScoped<IAdminsManager, AdminsManager>();

            services.AddScoped<IHotelRoomsProvider>(x =>
            new HotelRoomsProvider(x.GetRequiredService<IRepository<HotelRoomEntity>>(), x.GetRequiredService<IMapper>()));

            services.AddScoped<IHotelRoomsManager, HotelRoomsManager>();

            services.AddScoped<IUsersProvider>(x =>
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(), x.GetRequiredService<IMapper>()));

            services.AddScoped<IUsersManager, UsersManager>();

            services.AddScoped<IAuthProvider>(x =>
            new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));
        }
    }
}
