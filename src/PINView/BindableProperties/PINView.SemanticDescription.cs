namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the SemanticProperties.Description property of the entry field for accessibility.
        /// </summary>
        public string SemanticDescription
        {
            get => (string)GetValue(SemanticDescriptionProperty);
            set => SetValue(SemanticDescriptionProperty, value);
        }

        public static readonly BindableProperty SemanticDescriptionProperty =
          BindableProperty.Create(
              nameof(SemanticDescription),
              typeof(string),
              typeof(PINView),
              string.Empty,
              defaultBindingMode: BindingMode.OneTime);
    }
}
