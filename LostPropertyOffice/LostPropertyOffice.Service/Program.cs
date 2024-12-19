using LostPropertyOffice.Service.IoC;
using LostPropertyOffice.Service.Settings;
using Serilog;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = LostPropertyOfficeSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

DbContextConfigurator.ConfigureServices(builder.Services, settings);
SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
