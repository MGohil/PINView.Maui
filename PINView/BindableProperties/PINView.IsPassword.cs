namespace PINView
{
    public partial class PINView
    {
        /// <summary>
        /// Set true if you dont want to show input value charecters, false otherwise True will show Dots inside box
        /// while typing False will show actual input value
        /// </summary>
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public static readonly BindableProperty IsPasswordProperty =
          BindableProperty.Create(
              nameof(IsPassword),
              typeof(bool),
              typeof(PINView),
              false,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: IsPasswordPropertyChanged);

        private static void IsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;
                boxTemplate.SecureMode((bool)newValue);
            });
        }
    }
}
