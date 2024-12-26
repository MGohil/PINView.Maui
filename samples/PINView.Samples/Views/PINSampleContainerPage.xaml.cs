using PINView.Maui.Helpers;

namespace PINView.Maui.Samples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PINSampleContainerPage : ContentPage
    {
        public PINSampleContainerPage(View view)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            stackLayout.Add(view);
        }

    }
}
