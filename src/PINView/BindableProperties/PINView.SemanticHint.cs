namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the SemanticProperties.Hint property of the entry field for accessibility.
        /// </summary>
        public string SemanticHint
        {
            get => (string)GetValue(SemanticHintProperty);
            set => SetValue(SemanticHintProperty, value);
        }

        public static readonly BindableProperty SemanticHintProperty =
          BindableProperty.Create(
              nameof(SemanticHint),
              typeof(string),
              typeof(PINView),
              string.Empty,
              defaultBindingMode: BindingMode.OneTime);
    }
}
