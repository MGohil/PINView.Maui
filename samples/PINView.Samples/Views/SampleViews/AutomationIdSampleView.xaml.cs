namespace PINView.Maui.Samples.Views.SampleViews
{
    public partial class AutomationIdSampleView : ContentView
    {
        public AutomationIdSampleView()
        {
            InitializeComponent();

            pinView1Title.Text = $"AutomationId of PINView control is set to : 'PINView1' and AutomationId of hidden Entry is: {pinView1.HiddenEntryAutomationId}";

        }
    }
}
