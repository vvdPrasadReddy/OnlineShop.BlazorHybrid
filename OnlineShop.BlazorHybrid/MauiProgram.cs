using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System.Reflection;

namespace OnlineShop.BlazorHybrid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("appsettings.json");
            //var config =new ConfigurationBuilder().AddJsonStream(stream).Build();

            //builder.Configuration.AddConfiguration(config);
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI3MjYxMkAzMjM1MmUzMDJlMzBoQ1owRDVpM0pzcGk0Y0FkdUZrTnlHaFZ0bWJ6MHNkOWpIVC9ndWRiVUlZPQ==");

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
