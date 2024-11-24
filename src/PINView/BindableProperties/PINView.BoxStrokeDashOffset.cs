using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the StrokeOffset of each PIN Box. Applicable when BoxStrokeDashArray property is set
        /// </summary>
        public double BoxStrokeDashOffset
        {
            get => (double)GetValue(BoxStrokeDashOffsetProperty);
            set => SetValue(BoxStrokeDashOffsetProperty, value);
        }

        public static readonly BindableProperty BoxStrokeDashOffsetProperty =
          BindableProperty.Create(
              nameof(BoxStrokeDashOffset),
              typeof(double),
              typeof(PINView),
              1.0,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxStrokeDashOffsetPropertyChanged);

        private static void BoxStrokeDashOffsetPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;

                boxTemplate.BoxBorder.StrokeDashOffset = (double)newValue;
            });
        }
    }
}
