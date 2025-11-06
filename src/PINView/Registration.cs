#if ANDROID
using Android.Content.Res;
#endif

namespace PINView.Maui;

public static class Registration
{
    public static MauiAppBuilder UsePinView(this MauiAppBuilder builder)
    {
#if ANDROID
        builder.ConfigureMauiHandlers(h =>
        {
            h.AddHandler<HiddenPinEntry, Platforms.Android.Handlers.HiddenPinEntryHandler>();
        });


        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(HiddenPinEntry), (handler, view) =>
        {
            if (view is Entry)
            {
                // Remove underline
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);

                // Change placeholder text color
                handler.PlatformView.SetHintTextColor(ColorStateList.ValueOf(Android.Graphics.Color.Transparent));

                handler.PlatformView.SetTextColor(Android.Graphics.Color.Transparent);

                handler.PlatformView.SetCursorVisible(false);
            }
        });

#endif
        return builder;
    }
}