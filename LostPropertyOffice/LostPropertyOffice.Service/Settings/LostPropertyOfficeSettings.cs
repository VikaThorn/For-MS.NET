namespace LostPropertyOffice.Service.Settings
{
    public class LostPropertyOfficeSettings
    {
        public Uri ServiceUri { get; set; }
        
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string LostPropertyOfficeDbContextConnectionString { get; set; }
    }
}