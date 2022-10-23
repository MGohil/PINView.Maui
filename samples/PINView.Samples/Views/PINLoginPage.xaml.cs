using PINView.Maui.Helpers;

namespace PINView.Maui.Samples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PINLoginPage : ContentPage
    {
        public PINLoginPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }

        private void PINView_PINEntryCompleted(System.Object sender, PINCompletedEventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Message", $"PIN Entered {e.PIN}", "OK");
        }
    }
}
