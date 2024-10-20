namespace LostPropertyOffice.Service.Settings
{
    public static class LostPropertyOfficeSettingsReader
    {
        public static LostPropertyOfficeSettings Read(IConfiguration configuration)
        {
            return new LostPropertyOfficeSettings()
            {
                LostPropertyOfficeDbContextConnectionString = configuration.GetValue<string>("LostPropertyOfficeDbContext")
            };
        }
    }
}