namespace PINView.Maui.Samples.ViewModels
{
    public class CreatePINPageViewModel : BaseViewModel
    {
        public CreatePINPageViewModel()
        {
            Title = "Create PIN";
            SavePINCommand = new Command(SavePINCommandExecute);
        }

        private string newPIN;

        public string NewPIN
        {
            get { return newPIN; }
            set { SetProperty(ref newPIN, value); }
        }

        private string confirmPIN;

        public string ConfirmPIN
        {
            get { return confirmPIN; }
            set { SetProperty(ref confirmPIN, value); }
        }

        public Command SavePINCommand { get; set; }

        private async void SavePINCommandExecute()
        {
            // Validate if both PINs are entered.
            if (string.IsNullOrWhiteSpace(NewPIN) || string.IsNullOrWhiteSpace(ConfirmPIN))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter both PINs", "OK");
                return;
            }

            // Validate if User enteres full length PIN entry
            if (NewPIN.Length != App.PINLength || ConfirmPIN.Length != App.PINLength)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please complete the PIN entry", "OK");
                return;
            }

            // Validate if both entered PINs match with each other
            if (NewPIN != ConfirmPIN)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Entered PINs do not match with each other", "OK");
                return;
            }

            // Save the PIN into your Preferred Local Storage

            // Ex - 1. Xam.Plugins.Settings
            Preferences.Set("PIN", NewPIN);

            // Ex - 2. Secure Storage (Xamarin.Essentials) If this fails, visit :
            // https://forums.xamarin.com/discussion/146923/securestorage-fails-on-ios
            // https://github.com/xamarin/Essentials/pull/247
            /*try
            {
                await SecureStorage.SetAsync("PIN", NewPIN);
            }
            catch
            {
                // Possible that device doesn't support secure storage on device.
            }*/

            // Ex - 3. Xamarin.Forms default provided
            /* Application.Current.Properties["PIN"] = NewPIN; */

            await Application.Current.MainPage.DisplayAlert("Success", "PIN Created Successfully", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
