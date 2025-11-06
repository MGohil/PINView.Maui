using Android.Views.InputMethods;
using AndroidX.AppCompat.Widget;
using static Android.Views.View;

namespace PINView.Maui.Platforms.Android.Handlers
{
    public sealed class HiddenPinEntryHandler : Microsoft.Maui.Handlers.EntryHandler
    {
        protected override void ConnectHandler(AppCompatEditText platformView)
        {
            base.ConnectHandler(platformView);
            platformView.FocusChange += PlatformView_FocusChange;
        }

        protected override void DisconnectHandler(AppCompatEditText platformView)
        {
            base.DisconnectHandler(platformView);
            platformView.FocusChange -= PlatformView_FocusChange;
        }

        private void PlatformView_FocusChange(object sender, FocusChangeEventArgs args)
        {
            if (args.HasFocus)
            {
                var inputMethodManager = (InputMethodManager)global::Android.App.Application.Context.GetSystemService(global::Android.Content.Context.InputMethodService);
                inputMethodManager?.ShowSoftInput(PlatformView, ShowFlags.Forced);
            }
            else
            {
                var inputMethodManager = (InputMethodManager)global::Android.App.Application.Context.GetSystemService(global::Android.Content.Context.InputMethodService);
                inputMethodManager?.HideSoftInputFromWindow(PlatformView.WindowToken, HideSoftInputFlags.None);
            }
        }
    }
}