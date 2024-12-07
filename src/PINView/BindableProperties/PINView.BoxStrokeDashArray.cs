using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Corner radius of each PIN Box. Only applicable when BoxShape is set to RoundCorner
        /// For Square and Circle shapes, this property value will be ignored
        /// </summary>
        public DoubleCollection BoxStrokeDashArray
        {
            get => (DoubleCollection)GetValue(BoxStrokeDashArrayProperty);
            set => SetValue(BoxStrokeDashArrayProperty, value);
        }

        public static readonly BindableProperty BoxStrokeDashArrayProperty =
          BindableProperty.Create(
              nameof(BoxStrokeDashArray),
              typeof(DoubleCollection),
              typeof(PINView),
              null,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxStrokeDashArrayPropertyChanged);

        private static void BoxStrokeDashArrayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;

                boxTemplate.BoxBorder.StrokeDashArray = (DoubleCollection)newValue;
            });
        }
    }
}
