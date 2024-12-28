using PINView.Maui.Samples.Views;

namespace PINView.Maui.Samples.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Title = "PINView.Maui";

            GoToPINLoginPageCommand = new Command(GoToPINLoginPageCommandExecute);
            GoToCreatePINPageCommand = new Command(GoToCreatePINPageCommandExecute);
            GoToChangePINPageCommand = new Command(GoToChangePINPageCommandExecute);
            GoToPINSamplesPageCommand = new Command(GoToPINSamplesPageCommandExecute);
            GoToPINSampleContainerPageCommand = new Command<string>(GoToPINSampleContainerPageCommandExecute);

        }

        public Command GoToPINLoginPageCommand { get; set; }

        private void GoToPINLoginPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PINLoginPage());
        }

        public Command GoToCreatePINPageCommand { get; set; }

        private void GoToCreatePINPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new CreatePINPage());
        }

        public Command GoToChangePINPageCommand { get; set; }

        private void GoToChangePINPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ChangePINPage());
        }

        public Command GoToPINSamplesPageCommand { get; set; }

        private void GoToPINSamplesPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PINSamplesPage());
        }

        public Command GoToPINSampleContainerPageCommand { get; set; }

        private void GoToPINSampleContainerPageCommandExecute(string containerViewName)
        {

            Application.Current.MainPage.Navigation.PushAsync(new PINSampleContainerPage(containerViewName));
        }
    }
}
