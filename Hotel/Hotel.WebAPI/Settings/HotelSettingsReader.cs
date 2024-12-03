namespace Hotel.WebAPI.Settings
{
    public static class HotelSettingsReader
    {
        public static HotelSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new HotelSettings()
            {
                HotelDbContextConnectionString = configuration.GetValue<string>("HotelDbContext"),

                ServiceUri = configuration.GetValue<Uri>("Uri"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}
