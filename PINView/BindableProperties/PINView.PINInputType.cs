using PINView.Helpers;

namespace PINView
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
            control.SetInputType((InputKeyboardType)newValue);
        }

        /// <summary>
        /// Sets the Keyboard Type as per the InputKeyboardType Bindable Property
        /// </summary>
        /// <param name="inputKeyboardType"></param>
        public void SetInputType(InputKeyboardType inputKeyboardType)
        {
            if (inputKeyboardType == InputKeyboardType.Numeric)
            {
                hiddenTextEntry.Keyboard = Keyboard.Numeric;
            }
            else if (inputKeyboardType == InputKeyboardType.AlphaNumeric)
            {
                // Keyboard.Create(0); : To remove the Hints on top of Keyboard, while typing
                hiddenTextEntry.Keyboard = Keyboard.Create(0);
            }
        }
    }
}
