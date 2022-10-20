using PINView.Helpers;

namespace PINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Font family of the PIN characters.
        /// Applicable if IsPassword = False
        /// </summary>
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static readonly BindableProperty FontFamilyProperty =
           BindableProperty.Create(
               nameof(FontFamily),
               typeof(string),
               typeof(PINView),
               defaultBindingMode: BindingMode.OneWay,
               propertyChanged: FontFamilyPropertyChanged);

        private static void FontFamilyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;
                boxTemplate.CharLabel.FontFamily = (string)newValue;
            });
        }
    }
}
