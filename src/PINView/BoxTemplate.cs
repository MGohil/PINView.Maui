using Microsoft.Maui.Controls.Shapes;
using PINView.Maui.Helpers;

namespace PINView.Maui;

internal class BoxTemplate : ContentView
{
    private string _inputChar;
    private Color _color;
    private Color _boxBorderColor;

    private Border boxBorder;
    private Grid valueContainer;
    private Ellipse dot;
    private Label charLabel;


    public FocusAnimationType FocusAnimationType { get; set; }
    public Color BoxFocusColor { get; set; }

    public Border BoxBorder => this.boxBorder;
    public Grid ValueContainer => this.valueContainer;
    public Ellipse Dot => this.dot;
    public Label CharLabel => this.charLabel;

    public BoxTemplate()
    {
        boxBorder = new Border()
        {
            Padding = new Thickness(0),
            BackgroundColor = Constants.DefaultBoxBackgroundColor,
            Stroke = Constants.DefaultColor,
            StrokeThickness = 1,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(Constants.DefaultBoxSize / 2),
            },
            HeightRequest = Constants.DefaultBoxSize,
            WidthRequest = Constants.DefaultBoxSize,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        valueContainer = new Grid()
        {
            // In windows it looks little off from left and top so corrected by this
            Margin = DeviceInfo.Platform == DevicePlatform.WinUI ? new Thickness(0, 0, 1, 1) : new Thickness(0),
        };

        dot = new Ellipse()
        {
            HeightRequest = Constants.DefaultDotSize,
            WidthRequest = Constants.DefaultDotSize,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Fill = Constants.DefaultColor,
        };

        charLabel = new Label()
        {
            Margin = DeviceInfo.Platform == DevicePlatform.WinUI ? new Thickness(0, 0, 0, 2) : new Thickness(0),
            FontAttributes = FontAttributes.Bold,
            TextColor = Constants.DefaultColor,
            //HorizontalOptions = LayoutOptions.Center,
            //VerticalOptions = LayoutOptions.Center,
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalTextAlignment = TextAlignment.Center,
        };

        valueContainer.Children.Add(dot);
        valueContainer.Children.Add(charLabel);

        boxBorder.Content = valueContainer;

        Content = boxBorder;

        // By default Shrink the Dot or Text label to get it hidden
        ShrinkAnimation();
    }

    private void GrowAnimation()
    {
        valueContainer.ScaleTo(1.0, 50);
    }

    public void ShrinkAnimation()
    {
        try
        {
            // TODO: This does not work
            //valueContainer.ScaleTo(0, 100);
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                // This works if we wrap shrink animation in Task and then run on ui thread
                Task.Run(() =>
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        valueContainer.ScaleTo(0, 50);
                    });
                });
            }
            else
            {
                valueContainer.ScaleTo(0, 50);
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    /// <summary>
    /// Sets the Color of Border, Dot, Input CharLabel
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color, Color boxBorderColor)
    {
        _color = color;
        _boxBorderColor = boxBorderColor;

        SetBorderColor();

        Dot.Fill = color;
        CharLabel.TextColor = color;
    }

    /// <summary>
    /// Applies the Corner Radius to the PIN Box based on the ShapeType
    /// </summary>
    /// <param name="shapeType"></param>
    public void SetRadius(BoxShapeType shapeType, double radius = 10)
    {
        if (shapeType == BoxShapeType.Circle)
        {
            BoxBorder.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(BoxBorder.HeightRequest / 2),
            };
        }
        else if (shapeType == BoxShapeType.Square)
        {
            BoxBorder.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(0),
            };
        }
        else if (shapeType == BoxShapeType.RoundCorner)
        {
            BoxBorder.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(radius),
            };
        }
    }

    /// <summary>
    /// Method sets the visibility of Input Characters or Dots. IsPassword =
    /// True : Displays Dots IsPassword = False : Displays Chars
    /// </summary>
    /// <param name="isPassword"></param>
    public void SecureMode(bool isPassword)
    {
        valueContainer.Children.Clear();

        if (isPassword)
        {
            valueContainer.Children.Add(Dot);
        }
        else
        {
            valueContainer.Children.Add(CharLabel);
        }

        if (!string.IsNullOrEmpty(_inputChar))
        {
            GrowAnimation();
        }
        else
        {
            ShrinkAnimation();
        }
    }

    /// <summary>
    /// Clears the input value along with showing the Clear value Animation
    /// </summary>
    /// <returns></returns>
    public void ClearValueWithAnimation()
    {
        _inputChar = null;
        ShrinkAnimation();
    }

    /// <summary>
    /// Sets the input value along with showing the Set value animation
    /// </summary>
    /// <param name="inputChar"></param>
    /// <returns></returns>
    public void SetValueWithAnimation(char inputChar)
    {
        UnFocusAnimation();

        CharLabel.Text = inputChar.ToString();
        _inputChar = inputChar.ToString();
        GrowAnimation();
    }

    // Sets the focus indication color
    public async void FocusAnimation()
    {
        //Box.BorderColor = BoxFocusColor;
        BoxBorder.Stroke = BoxFocusColor;

        if (FocusAnimationType == FocusAnimationType.ZoomInOut)
        {
            await this.ScaleTo(1.2, 100);
            this.ScaleTo(1, 100);
        }
        else if (FocusAnimationType == FocusAnimationType.ScaleUp)
        {
            this.ScaleTo(1.2, 100);
        }
    }

    // Removes the focusindication color and set back to original
    public void UnFocusAnimation()
    {
        SetBorderColor();
        this.ScaleTo(1, 100);
    }

    private void SetBorderColor()
    {
        BoxBorder.Stroke = _boxBorderColor == Colors.Black ? _color : _boxBorderColor;
    }
}
