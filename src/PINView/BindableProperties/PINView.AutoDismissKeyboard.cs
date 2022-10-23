namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Set true if you want to dismiss the soft keyboard, when PIN entry is completed
        /// </summary>
        public bool AutoDismissKeyboard
        {
            get => (bool)GetValue(AutoDismissKeyboardProperty);
            set => SetValue(AutoDismissKeyboardProperty, value);
        }

        public static readonly BindableProperty AutoDismissKeyboardProperty =
          BindableProperty.Create(
              nameof(AutoDismissKeyboard),
              typeof(bool),
              typeof(PINView),
              false,
              defaultBindingMode: BindingMode.OneWay);
    }
}
