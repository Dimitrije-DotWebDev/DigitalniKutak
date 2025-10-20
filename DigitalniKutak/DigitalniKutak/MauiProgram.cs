using CommunityToolkit.Maui;
using DigitalniKutak.Services;
using DigitalniKutak.ViewModel;
using Microsoft.Extensions.Logging;

namespace DigitalniKutak
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<NovostService>();
            builder.Services.AddSingleton<SekcijaServis>();

            builder.Services.AddSingleton<GlavniViewModel>();

            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
