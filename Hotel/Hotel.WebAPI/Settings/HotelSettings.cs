namespace Hotel.WebAPI.Settings
{
    public class HotelSettings
    {
        public string HotelDbContextConnectionString { get; set; }
        public Uri ServiceUri { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
