using PINView.Helpers;

namespace PINView
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Height / Width of each PIN Box. Please try to give Even number size to get the proper UI.
        /// Please, try to give such size that all PIN boxes fit properly in your device's screen Providing larger size,
        /// can shrink the Boxes if there is no more room to fit them on screen
        /// </summary>
        public double BoxSize
        {
            get => (double)GetValue(BoxSizeProperty);
            set => SetValue(BoxSizeProperty, value);
        }

        public static readonly BindableProperty BoxSizeProperty =
          BindableProperty.Create(
              nameof(BoxSize),
              typeof(double),
              typeof(PINView),
              Constants.DefaultBoxSize,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxSizePropertyChanged);

        private static void BoxSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((double)newValue < 0)
            {
                return;
            }

            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;
                boxTemplate.Box.HeightRequest = (double)newValue;
                boxTemplate.Box.WidthRequest = (double)newValue;
                boxTemplate.CharLabel.FontSize = ((double)newValue / 2);
                boxTemplate.SetRadius(control.BoxShape);
            });
        }
    }
}
