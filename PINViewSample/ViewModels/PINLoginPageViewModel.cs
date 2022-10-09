using PINViewSample.Views;

namespace PINViewSample.ViewModels
{
    public class PINLoginPageViewModel : BaseViewModel
    {
        public PINLoginPageViewModel()
        {
            Title = "PIN Login";
            PINEntryCompletedCommand = new Command<string>(PINEntryCompletedCommandExecute);
        }

        private string pin;

        public string PIN
        {
            get { return pin; }
            set { SetProperty(ref pin, value); }
        }

        public Command<string> PINEntryCompletedCommand { get; set; }

        private async void PINEntryCompletedCommandExecute(string pin)
        {
            // This is a sample to demonstrate how PINView helps taking the user input as PIN, while making a PIN login.
            // In your actual app, you will make validations, and check the entry against the locally saved PIN to match
            // Entry with it. You should navigate to the next page only if the Entry matches the Saved value.

            // As a sample, you can enter any value as a PIN to login.

            // Clear Entry before navigation
            PIN = string.Empty;

            await Application.Current.MainPage.Navigation.PushAsync(new DashboardPage());
        }
    }
}
