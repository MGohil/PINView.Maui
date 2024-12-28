namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Set AutomationId for this control and it will set AutomationId for hidden entry too.
        /// If you set AutomationId of control as "ConfirmPIN" then AutomationId of hidden Entry will be "ConfirmPIN_PINView_Entry".
        /// NOTE: You must set this property of the control, if you want to work with Automation, 
        /// otherwise you will not be able to get the AutomationId of hiden Entry.
        /// You can get the hidden Entry's AutomationId using HiddenEntryAutomationId get only property.
        /// </summary>
        public string AutomationId
        {
            get => (string)GetValue(AutomationIdProperty);
            set => SetValue(AutomationIdProperty, value);
        }

        public static readonly BindableProperty AutomationIdProperty =
          BindableProperty.Create(
              nameof(AutomationId),
              typeof(string),
              typeof(PINView),
              null,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: AutomationIdPropertyChanged);

        private static void AutomationIdPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
            {
                return;
            }

            var control = ((PINView)bindable);

            var automationId = (string)newValue;

            // Set Hidden Entry's AutomationId based on control's AutomationId by appending the "PINView_Entry" to it.
            control.hiddenTextEntry.AutomationId = $"{control.AutomationId}_PINView_Entry";
        }
    }
}
