using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Height / Width of each PIN Box. Please try to give Even number size to get the proper UI.
        /// Please, try to give such size that all PIN boxes fit properly in your device's screen Providing larger size,
        /// can shrink the Boxes if there is no more room to fit them on screen
        /// If FontSize is default, BoxSize is also Default, then not an issue.
        /// FontSize will take precedence if set other than default value, otherwise, if BoxSize is set with default FontSize, then BoxSize will Auto Adjust the Font size which best fit inside the box.
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

                boxTemplate.HeightRequest = (double)newValue;
                boxTemplate.WidthRequest = (double)newValue;

                boxTemplate.BoxBorder.HeightRequest = (double)newValue;
                boxTemplate.BoxBorder.WidthRequest = (double)newValue;
                
                boxTemplate.CharLabel.FontSize = ((double)newValue / 2);
                boxTemplate.SetRadius(control.BoxShape);
            });
        }
    }
}
