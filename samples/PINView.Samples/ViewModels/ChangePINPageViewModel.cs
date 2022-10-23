namespace PINView.Maui.Samples.ViewModels
{
    public class ChangePINPageViewModel : BaseViewModel
    {
        public ChangePINPageViewModel()
        {
            Title = "Change PIN";
            DoneCommand = new Command(DoneCommandExecute);
        }

        private string existingPIN;

        public string ExistingPIN
        {
            get { return existingPIN; }
            set { SetProperty(ref existingPIN, value); }
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

        public Command DoneCommand { get; set; }

        private async void DoneCommandExecute()
        {
            // Validate if both PINs are entered.
            if (string.IsNullOrWhiteSpace(ExistingPIN) ||
                string.IsNullOrWhiteSpace(NewPIN) ||
                string.IsNullOrWhiteSpace(ConfirmPIN))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter all PINs", "OK");
                return;
            }

            // Validate if User enteres full length PIN entry
            if (ExistingPIN.Length != App.PINLength ||
                NewPIN.Length != App.PINLength ||
                ConfirmPIN.Length != App.PINLength)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please complete all PIN entry", "OK");
                return;
            }

            // Validate if Entered Existing PIN matches with locally saved PIN value Here you will fetch saved value
            // from your preferred local storage, where you saved the PIN
            var existingSavedPIN = Preferences.Get("PIN", string.Empty);
            if (ExistingPIN != existingSavedPIN)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter correct Existing PIN", "OK");
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
            Preferences.Default.Set("PIN", NewPIN);

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

            await Application.Current.MainPage.DisplayAlert("Success", "PIN changed Successfully", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
