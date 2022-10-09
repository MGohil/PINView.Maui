namespace PINViewSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePINPage : ContentPage
    {
        public ChangePINPage()
        {
            InitializeComponent();
            existingPINView.PINEntryCompleted += delegate { newPINView.FocusBox(); };
            newPINView.PINEntryCompleted += delegate { confirmPINView.FocusBox(); };
        }
    }
}
