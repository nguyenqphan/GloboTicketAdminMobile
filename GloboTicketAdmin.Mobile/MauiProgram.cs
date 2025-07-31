using CommunityToolkit.Maui;
using GloboTicketAdmin.Mobile.Repositories;
using GloboTicketAdmin.Mobile.Services;
using Microsoft.Extensions.Logging;

namespace GloboTicketAdmin.Mobile
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
                })
                .RegisterRepositories()
                .RegisterServices();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IEventRepository, EventRepository>();

            builder.Services.AddHttpClient("GloboTicketAdminApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return builder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IEventService, EventService>();
            return builder;
        }
    }

}
