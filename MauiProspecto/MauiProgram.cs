using MauiProspecto.Services;
using Microsoft.Extensions.Logging;

namespace MauiProspecto
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddHttpClient("api", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7168/api"); // Reemplaza con la URL base de tu API
            });

            builder.Services.AddScoped<ApiService>(provider => new ApiService(new HttpClient { BaseAddress = new Uri("https://localhost:7168/api/") }));
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
