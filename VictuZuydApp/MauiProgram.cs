using Microsoft.Extensions.Logging;

namespace VictuZuydApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            string dbPath = Constants.DatabasePath;

            // Register services
            builder.Services.AddSingleton(new DatabaseService(dbPath));
            builder.Services.AddSingleton<Repos.IBaseRepository<Models.Event>, Repos.BaseRepository<Models.Event>>();
            builder.Services.AddSingleton<Repos.IBaseRepository<Models.Activity>, Repos.BaseRepository<Models.Activity>>();
            builder.Services.AddSingleton<Repos.IBaseRepository<Models.User>, Repos.BaseRepository<Models.User>>();
            builder.Services.AddSingleton<ViewModels.MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }

}
