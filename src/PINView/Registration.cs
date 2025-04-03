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
#endif

        return builder;
    }
}