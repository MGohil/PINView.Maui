using PINView.Maui.Helpers;
using System.Diagnostics;

namespace PINView.Maui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PINView : ContentView
    {
        #region Fields

        /// <summary>
        /// A TapGesture Recognizer to invoke when user tap on any PIN box. This will help bring up the soft keyboard
        /// </summary>
        private readonly TapGestureRecognizer boxTapGestureRecognizer;

        /// <summary>
        /// An event which is raised/invoked when PIN entry is completed This will help user to execute any code when
        /// entry completed
        /// </summary>
        public event EventHandler<PINCompletedEventArgs> PINEntryCompleted;

        public string HiddenEntryAutomationId => hiddenTextEntry.AutomationId;


        #endregion Fields

        #region Constructor and Initializations

        public PINView()
        {
            InitializeComponent();

            hiddenTextEntry.TextChanged += PINView_TextChanged;
            hiddenTextEntry.Focused += HiddenTextEntry_Focused;
            hiddenTextEntry.Unfocused += HiddenTextEntry_Unfocused;

            boxTapGestureRecognizer = new TapGestureRecognizer() { Command = new Command(() => { BoxTapCommandExecute(); }) };

            CreateControl();

            AutomationProperties.SetExcludedWithChildren(PINBoxContainer, true);
            AutomationProperties.SetIsInAccessibleTree(PINBoxContainer, false);
        }

        private void HiddenTextEntry_Unfocused(object sender, FocusEventArgs e)
        {
            var pinBoxArray = PINBoxContainer.Children.Select(x => x as BoxTemplate).ToArray();

            for(int i = 0; i < PINLength; i++)
            {
                pinBoxArray[i].UnFocusAnimation();
            }

            Debug.WriteLine($"{nameof(PINView)}: PIN Entry UnFocused");
        }

        private void HiddenTextEntry_Focused(object sender, FocusEventArgs e)
        {
            var length = PINValue?.Length ?? 0;

            // When textbox is focused, Android brings cursor to the start of value, instead of end To fix this issue,
            // added this programmatic cursor movement to the last when focused
            hiddenTextEntry.CursorPosition = length;

            var pinBoxArray = PINBoxContainer.Children.Select(x => x as BoxTemplate).ToArray();

            if(length == PINLength)
            {
                pinBoxArray[length - 1].FocusAnimation();
            }
            else
            {
                for(int i = 0; i < PINLength; i++)
                {
                    if(i == length)
                    {
                        pinBoxArray[i].FocusAnimation();
                    }
                    else
                    {
                        pinBoxArray[i].UnFocusAnimation();
                    }
                }
            }

            Debug.WriteLine($"{nameof(PINView)}: PIN Entry Focused");
        }

        /// <summary>
        /// Calling this, will bring up the soft keyboard, or will help focus the control
        /// </summary>
        public void FocusBox()
        {
            boxTapGestureRecognizer?.Command?.Execute(null);
        }

        #endregion Constructor and Initializations

        #region Methods

        /// <summary>
        /// Initializes the UI for the PINView
        /// </summary>
        public void CreateControl()
        {
            hiddenTextEntry.MaxLength = PINLength;

            SetInputType(PINInputType);

            var count = PINBoxContainer.Children.Count;

            if(count < PINLength)
            {
                int newBoxesToAdd = PINLength - count;
                char[] pinCharsArray = PINValue.ToCharArray();

                for(int i = 1; i <= newBoxesToAdd; i++)
                {
                    BoxTemplate boxTemplate = CreateBox();
                    PINBoxContainer.Children.Add(boxTemplate);

                    // When we assign PINValue in XAML directly, the Boxes outside the default length (4), will not get
                    // any value in it, eventhough we have assigned it in XAML To correct this behavior, we have
                    // programatically assigned value to those Boxes which are added after the Default Length
                    if(PINValue.Length >= PINLength)
                    {
                        boxTemplate.SetValueWithAnimation(pinCharsArray[Constants.DefaultPINLength + i - 1]);
                    }
                }
            }
            else if(count > PINLength)
            {
                int boxesToRemove = count - PINLength;
                for(int i = 1; i <= boxesToRemove; i++)
                {
                    PINBoxContainer.Children.RemoveAt(PINBoxContainer.Children.Count - 1);
                }
            }
        }

        /// <summary>
        /// Creates the instance of one single PIN box UI
        /// </summary>
        /// <returns></returns>
        private BoxTemplate CreateBox(char? charValue = null)
        {
            BoxTemplate boxTemplate = new BoxTemplate();
            boxTemplate.HeightRequest = BoxSize;
            boxTemplate.WidthRequest = BoxSize;

            boxTemplate.BoxBorder.HeightRequest = BoxSize;
            boxTemplate.BoxBorder.WidthRequest = BoxSize;

            // If FontSize is default, but BoxSize is changed, then BoxSize will auto adjust the font size.
            if(FontSize == Constants.DefaultFontSize && BoxSize != Constants.DefaultBoxSize)
            {
                boxTemplate.CharLabel.FontSize = ((double)BoxSize / 2);
            }
            else
            {
                boxTemplate.CharLabel.FontSize = FontSize;
            }

            boxTemplate.Dot.HeightRequest = DotSize;
            boxTemplate.Dot.WidthRequest = DotSize;

            boxTemplate.BoxBorder.BackgroundColor = BoxBackgroundColor;
            boxTemplate.CharLabel.FontFamily = FontFamily;
            boxTemplate.CharLabel.FontAttributes = FontAttributes;
            boxTemplate.CharLabel.FontAutoScalingEnabled = FontAutoScalingEnabled;

            boxTemplate.BoxFocusColor = BoxFocusColor;
            boxTemplate.FocusAnimationType = BoxFocusAnimation;
            boxTemplate.BoxBorder.StrokeThickness = BoxStrokeThickness;
            boxTemplate.BoxBorder.StrokeDashArray = BoxStrokeDashArray;
            boxTemplate.SecureMode(IsPassword);
            boxTemplate.SetColor(Color, BoxBorderColor);
            boxTemplate.SetRadius(BoxShape);
            boxTemplate.ShrinkAnimation();

            if(charValue.HasValue)
            {
                boxTemplate.SetValueWithAnimation(charValue.Value);
            }

            return boxTemplate;
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Invokes when user type the PIN, Assigns value to PINValue property or Text changes in the hidden textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PINView_TextChanged(object sender, TextChangedEventArgs e)
        {
            PINValue = e.NewTextValue;

            // To have some delay so that till the next execution all assigned values to the properties in XAML gets
            // sets and we get the right value at the time after this delay Otherwise due to sequence of calls, some
            // properties gets their actual assigned value after the completion of this event Also To have some delay,
            // before invoking any Action, otherwise, (if) while navigation, it will be quick and you won't see your
            // last entry / or animation.
            await Task.Delay(200);

            if(e.NewTextValue.Length < PINLength)
            {
                return;
            }

            // Dismiss the keyboard, once entry is completed up to the defined length and if AutoDismissKeyboard
            // property is true
            if(AutoDismissKeyboard == true)
            {
                (sender as HiddenPinEntry)?.Unfocus();
                Debug.WriteLine($"{nameof(PINView)}: PIN Entry UnFocused");
            }

            Debug.WriteLine($"{nameof(PINView)}: PIN Entry Completed");

            PINEntryCompleted?.Invoke(this, new PINCompletedEventArgs(PINValue));
            PINEntryCompletedCommand?.Execute(PINValue);
        }

        #endregion Events

        #region Commands and Executes

        /// <summary>
        /// Invokes when user tap on the PINView, this will bring up the soft keyboard
        /// </summary>
        private async void BoxTapCommandExecute()
        {
            Debug.WriteLine($"{nameof(PINView)}: Box Tapped");

            if(DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                // https://xamarin.github.io/bugzilla-archives/55/55245/bug.html
                await Task.Delay(1);
            }

            hiddenTextEntry.Focus();
        }

        #endregion Commands and Executes
    }
}
