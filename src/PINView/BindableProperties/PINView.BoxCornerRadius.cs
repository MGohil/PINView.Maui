using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Corner radius of each PIN Box. Only applicable when BoxShape is set to RoundCorner
        /// For Square and Circle shapes, this property value will be ignored
        /// </summary>
        public double BoxCornerRadius
        {
            get => (double)GetValue(BoxCornerRadiusProperty);
            set => SetValue(BoxCornerRadiusProperty, value);
        }

        public static readonly BindableProperty BoxCornerRadiusProperty =
          BindableProperty.Create(
              nameof(BoxCornerRadius),
              typeof(double),
              typeof(PINView),
              10.0,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxCornerRadiusPropertyChanged);

        private static void BoxCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((double)newValue < 0)
            {
                return;
            }

            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;

                boxTemplate.SetRadius(control.BoxShape, (double)newValue);
            });
        }
    }
}
