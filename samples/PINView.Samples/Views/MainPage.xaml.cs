using System.ComponentModel;

namespace PINView.Maui.Samples.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer by visiting
    // https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }
    }
}
