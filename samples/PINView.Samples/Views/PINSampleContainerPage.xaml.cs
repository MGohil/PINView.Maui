using PINView.Maui.Helpers;

namespace PINView.Maui.Samples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PINSampleContainerPage : ContentPage
    {
        public PINSampleContainerPage(string view)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            var viewType = Type.GetType("PINView.Maui.Samples.Views.SampleViews." + view);
            var viewInstance = (View)Activator.CreateInstance(viewType);
            stackLayout.Add(viewInstance);
        }

    }
}
