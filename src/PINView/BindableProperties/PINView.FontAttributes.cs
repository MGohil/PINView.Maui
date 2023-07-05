using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Font attributes of the PIN characters.
        /// Applicable if IsPassword = False
        /// </summary>
        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public static readonly BindableProperty FontAttributesProperty =
           BindableProperty.Create(
               nameof(FontAttributes),
               typeof(FontAttributes),
               typeof(PINView),
               FontAttributes.None,
               defaultBindingMode: BindingMode.OneWay,
               propertyChanged: FontAttributesPropertyChanged);

        private static void FontAttributesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);
            
            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;
                boxTemplate.CharLabel.FontAttributes = (FontAttributes)newValue;
            });
        }
    }
}
