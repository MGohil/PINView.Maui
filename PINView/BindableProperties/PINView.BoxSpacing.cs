using PINView.Helpers;

namespace PINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Space among the PIN Boxes
        /// </summary>
        public double BoxSpacing
        {
            get => (double)GetValue(BoxSpacingProperty);
            set => SetValue(BoxSpacingProperty, value);
        }

        public static readonly BindableProperty BoxSpacingProperty =
          BindableProperty.Create(
              nameof(BoxSpacing),
              typeof(double),
              typeof(PINView),
              Constants.DefaultBoxSpacing,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxSpacingPropertyChanged);

        private static void BoxSpacingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((double)newValue < 0)
            {
                return;
            }

            var control = ((PINView)bindable);

            control.PINBoxContainer.Spacing = (double)newValue;
        }
    }
}
