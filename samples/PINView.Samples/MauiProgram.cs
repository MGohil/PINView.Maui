namespace PINView.Maui.Samples
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
#if ANDROID
            .ConfigureMauiHandlers(handlers => handlers.AddHandler<Microsoft.Maui.Controls.Entry, Platforms.Android.Handlers.EntryHandler>())
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Fasthand-Regular.ttf", "FasthandRegular");
                });

            return builder.Build();
        }
    }
}
