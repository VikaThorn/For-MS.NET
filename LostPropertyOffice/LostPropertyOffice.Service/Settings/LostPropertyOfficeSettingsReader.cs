namespace LostPropertyOffice.Service.Settings
{
    public static class LostPropertyOfficeSettingsReader
    {
        public static LostPropertyOfficeSettings Read(IConfiguration configuration)
        {
            return new LostPropertyOfficeSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
                LostPropertyOfficeDbContextConnectionString = configuration.GetValue<string>("LostPropertyOfficeDbContext")
            };
        }
    }
}