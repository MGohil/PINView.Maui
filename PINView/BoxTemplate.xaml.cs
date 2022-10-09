using PINView.Helpers;

namespace PINView;

public partial class BoxTemplate : ContentView
{
    private string _inputChar;
    private Color _color;
    private Color _boxBorderColor;

    public FocusAnimationType FocusAnimationType { get; set; }
    public Color BoxFocusColor { get; set; }

    public Frame Box => this.box;
    public Grid ValueContainer => this.valueContainer;
    public Frame Dot => this.dot;
    public Label CharLabel => this.charLabel;

    public BoxTemplate()
    {
        InitializeComponent();

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

            // This works if we wrap shrink animation in Task and then run on ui thread
            Task.Run(() =>
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await valueContainer.ScaleTo(0, 50);
                });
            });
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

        Dot.BackgroundColor = color;
        CharLabel.TextColor = color;
    }

    /// <summary>
    /// Applies the Corner Radius to the PIN Box based on the ShapeType
    /// </summary>
    /// <param name="boxTemplate"></param>
    /// <param name="shapeType"></param>
    public void SetRadius(BoxShapeType shapeType)
    {
        if (shapeType == BoxShapeType.Circle)
        {
            Box.CornerRadius = (float)HeightRequest / 2;
        }
        else if (shapeType == BoxShapeType.Squere)
        {
            Box.CornerRadius = 0;
        }
        else if (shapeType == BoxShapeType.RoundCorner)
        {
            Box.CornerRadius = 10;
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
        Box.BorderColor = BoxFocusColor;

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
        Box.BorderColor = _boxBorderColor == Colors.Black ? _color : _boxBorderColor;
    }
}
