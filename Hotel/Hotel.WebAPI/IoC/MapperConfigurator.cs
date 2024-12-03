using Hotel.BL.Mapper;
using Hotel.WebAPI.Mapper;

namespace Hotel.WebAPI.IoC
{
    public static class MapperConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<AdminBLProfile>();
                config.AddProfile<HotelRoomBLProfile>();
                config.AddProfile<UserBLProfile>();
                config.AddProfile<AdminsServiceProfile>();
                config.AddProfile<HotelRoomsServiceProfile>();
                config.AddProfile<UsersServiceProfile>();
            });
        }
    }
}
