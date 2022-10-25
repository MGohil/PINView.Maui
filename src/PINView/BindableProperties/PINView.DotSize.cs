using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Height / Width of Dot in Box. Please try to give Even number size to get the proper UI.
        /// </summary>
        public double DotSize
        {
            get => (double)GetValue(DotSizeProperty);
            set => SetValue(DotSizeProperty, value);
        }

        public static readonly BindableProperty DotSizeProperty =
          BindableProperty.Create(
              nameof(DotSize),
              typeof(double),
              typeof(PINView),
              Constants.DefaultDotSize,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: DotSizePropertyChanged);

        private static void DotSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((double)newValue < 0)
            {
                return;
            }

            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;

                boxTemplate.Dot.HeightRequest = (double)newValue;
                boxTemplate.Dot.WidthRequest = (double)newValue;
            });
        }
    }
}
