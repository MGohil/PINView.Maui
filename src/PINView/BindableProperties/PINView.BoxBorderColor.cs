namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Border color of the PIN Box. If you do not set this Property, By default it will use the
        /// "Color" property for BoxBorderColor
        /// </summary>
        public Color BoxBorderColor
        {
            get => (Color)GetValue(BoxBorderColorProperty);
            set => SetValue(BoxBorderColorProperty, value);
        }

        public static readonly BindableProperty BoxBorderColorProperty =
          BindableProperty.Create(
              nameof(BoxBorderColor),
              typeof(Color),
              typeof(PINView),
              Colors.Black,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BoxBorderColorPropertyChanged);

        private static void BoxBorderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PINView)bindable;

            // Apply the BoxBorderColor only if it is different then the value in "Color" Property
            if (control.Color != (Color)newValue)
            {
                control.PINBoxContainer.Children.ToList().ForEach(x =>
                {
                    var boxTemplate = (BoxTemplate)x;
                    boxTemplate.SetColor(color: control.Color, boxBorderColor: (Color)newValue);
                });
            }
        }
    }
}
