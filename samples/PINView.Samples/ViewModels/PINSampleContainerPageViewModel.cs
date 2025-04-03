namespace PINView.Maui.Samples.ViewModels
{
    public class PINSampleContainerPageViewModel : BaseViewModel
    {
        private Random random = new Random();

        public PINSampleContainerPageViewModel()
        {
            PINEntryCompletedCommand = new Command<string>(PINEntryCompletedCommandExecute);
            InputPINProgramaticallyCommand = new Command(InputPINProgramaticallyCommandExecute);
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
            await Application.Current.MainPage.DisplayAlert("Message", "PINEntryCompletedCommand Invoked", "OK");
        }

        #region Input PIN Programatically

        private string randomPIN = "12345";

        private string pin1;

        public string PIN1
        {
            get { return pin1; }
            set { SetProperty(ref pin1, value); }
        }

        private string pin2;

        public string PIN2
        {
            get { return pin2; }
            set { SetProperty(ref pin2, value); }
        }

        private string inputPINButtonText = "Tap to Input : 12345";

        public string InputPINButtonText
        {
            get { return inputPINButtonText; }
            set { SetProperty(ref inputPINButtonText, value); }
        }

        public Command InputPINProgramaticallyCommand { get; set; }

        private void InputPINProgramaticallyCommandExecute()
        {
            PIN1 = PIN2 = randomPIN;

            randomPIN = random.Next(11111, 99999).ToString();
            InputPINButtonText = $"Tap to Input : {randomPIN}";
        }

        #endregion Input PIN Programatically
    }
}
