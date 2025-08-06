using CommunityToolkit.Maui;
using GloboTicketAdmin.Mobile.Repositories;
using GloboTicketAdmin.Mobile.Services;
using GloboTicketAdmin.Mobile.ViewModels;
using GloboTicketAdmin.Mobile.Views;
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
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://192.168.86.99:5191"
                : "https://localhost:7185/";

            builder.Services.AddTransient<IEventRepository, EventRepository>();

            builder.Services.AddHttpClient("GloboTicketAdminApiClient", client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return builder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IEventService, EventService>();
            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<EventListOverviewViewModel>();
            builder.Services.AddTransient<EventDetailViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<EventOverviewPage>();
            builder.Services.AddTransient<EventDetailPage>();
            return builder;
        }
    }

}
