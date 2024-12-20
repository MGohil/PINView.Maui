using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Input Type (Keyboard Type) of the PIN Box from InputKeyboardType enum:
        ///
        /// Numeric, AlphaNumeric
        /// </summary>
        public InputKeyboardType PINInputType
        {
            get => (InputKeyboardType)GetValue(PINInputTypeProperty);
            set => SetValue(PINInputTypeProperty, value);
        }

        public static readonly BindableProperty PINInputTypeProperty =
           BindableProperty.Create(
               nameof(PINInputType),
               typeof(InputKeyboardType),
               typeof(PINView),
                InputKeyboardType.Numeric,
               defaultBindingMode: BindingMode.OneWay,
               propertyChanged: PINInputTypePropertyChanged);

        private static void PINInputTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);
            control?.SetInputType((InputKeyboardType)newValue);
        }

        /// <summary>
        /// Sets the Keyboard Type as per the InputKeyboardType Bindable Property
        /// </summary>
        /// <param name="inputKeyboardType"></param>
        public void SetInputType(InputKeyboardType inputKeyboardType)
        {
            hiddenTextEntry.Keyboard = inputKeyboardType switch
            {
                InputKeyboardType.Numeric => Keyboard.Numeric,
                // Keyboard.Create(KeyboardFlags.None): To remove the Hints on top of Keyboard, while typing
                InputKeyboardType.AlphaNumeric => Keyboard.Create(KeyboardFlags.None),
                // Keyboard.Create(KeyboardFlags.None | KeyboardFlags.CapitalizeCharacter): To make the Keyboard uppercase by default
                InputKeyboardType.AlphaNumericUppercase => Keyboard.Create(KeyboardFlags.None | KeyboardFlags.CapitalizeCharacter),
                _ => hiddenTextEntry.Keyboard
            };
        }
    }
}
