namespace PINView.Maui;

public partial class PINView
{
    /// <summary>
    /// Enables or disables the font accessibility scaling for the PIN Box labels.
    /// </summary>
    public bool FontAutoScalingEnabled
    {
        get => (bool)GetValue(FontAutoScalingEnabledProperty);
        set => SetValue(FontAutoScalingEnabledProperty, value);
    }

    public static readonly BindableProperty FontAutoScalingEnabledProperty =
        BindableProperty.Create(
            nameof(FontAutoScalingEnabled),
            typeof(bool),
            typeof(PINView),
            defaultValue: true,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontAccessibilityScalingEnabledPropertyChanged);

    private static void FontAccessibilityScalingEnabledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not PINView pinView)
        {
            return;
        }

        foreach (var box in pinView.PINBoxContainer.Children)
        {
            if (box is BoxTemplate boxTemplate)
            {
                boxTemplate.CharLabel.FontAutoScalingEnabled = (bool)newValue;
            }
        }
    }
}