#if ANDROID
using Android.Content.Res;
#endif

namespace PINView.Maui.Samples
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePinView()
                .RegisterProjectHandlers()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Fasthand-Regular.ttf", "FasthandRegular");
                });

            return builder.Build();
        }

        /// <summary>
        /// This is to test if any project has Entry handler defined and it can override what we did in the control to hide the HiddenPinEntry
        /// </summary>
        /// <param name="builder">maui app builder</param>
        /// <returns>MauiAppBuilder</returns>
        public static MauiAppBuilder RegisterProjectHandlers(this MauiAppBuilder builder)
        {
#if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("TestOverride", (handler, view) =>
            {
                // Remove underline
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Red);
                
                // Change placeholder text color
                handler.PlatformView.SetHintTextColor(ColorStateList.ValueOf(Android.Graphics.Color.Transparent));
                handler.PlatformView.SetTextColor(Android.Graphics.Color.Blue);
                handler.PlatformView.SetCursorVisible(false);
            });             
#endif

#if IOS || MACCATALYST
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("TestOverride", (handler, view) =>
            {
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.Line;
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.TextColor = UIKit.UIColor.Black;
                handler.PlatformView.TintColor = UIKit.UIColor.Black;
            });
#endif

#if WINDOWS
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("TestOverride", (handler, view) =>
            {
                handler.PlatformView.Opacity = 1;
            });
#endif

            return builder;
        }
    }
}
