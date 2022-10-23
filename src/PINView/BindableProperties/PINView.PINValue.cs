using System.Diagnostics;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the PIN value.
        /// </summary>
        public string PINValue
        {
            get => (string)GetValue(PINValueProperty);
            set => SetValue(PINValueProperty, value);
        }

        public static readonly BindableProperty PINValueProperty =
           BindableProperty.Create(
               nameof(PINValue),
               typeof(string),
               typeof(PINView),
               string.Empty,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: PINValuePropertyChanged);

        private static async void PINValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (PINView)bindable;

                string newPIN = Convert.ToString(newValue);
                string oldPIN = Convert.ToString(oldValue);

                int newPINLength = newPIN.Length;
                int oldPINLength = oldPIN.Length;

                // If no any chars entered, return from here
                if (newPINLength == 0 && oldPINLength == 0)
                {
                    //_ = Task.Run(async () =>
                    //{
                    //    //await Task.Delay(1000);

                    //    MainThread.BeginInvokeOnMainThread(() =>
                    //    {
                    //        var pinBoxArray1 = control.PINBoxContainer.Children.Select(x => x as BoxTemplate).ToList();
                    //        pinBoxArray1.ForEach(x =>
                    //        {
                    //            x.ShrinkAnimation();
                    //        });
                    //    });
                    //});

                    return;
                }

                char[] newPINChars = newPIN.ToCharArray();

                control.hiddenTextEntry.Text = newPIN;
                var pinBoxArray = control.PINBoxContainer.Children.Select(x => x as BoxTemplate).ToArray();

                bool isFullLengthPINGivenProgramatically = 
                    (oldPINLength == 0 && newPINLength == control.PINLength) || 
                    newPINLength == oldPINLength;

                if (isFullLengthPINGivenProgramatically)
                {
                    //Clear all Previous Entries, and then enter new one, to show proper Entry sequence animation
                    for (int i = 0; i < control.PINLength; i++)
                    {
                        pinBoxArray[i].ClearValueWithAnimation();
                    }
                }

                for (int i = 0; i < control.PINLength; i++)
                {
                    if (i < newPINLength)
                    {
                        // If user sets PIN value programatically show a bit of Entry sequence animation
                        if (isFullLengthPINGivenProgramatically)
                        {
                            await Task.Delay(50);
                        }

                        pinBoxArray[i].SetValueWithAnimation(newPINChars[i]);
                    }
                    else
                    {
                        if (pinBoxArray.Length >= control.PINLength)
                        {
                            pinBoxArray[i].ClearValueWithAnimation();
                            pinBoxArray[i].UnFocusAnimation();
                        }
                    }
                }

                // Set or move Current Focus
                if (control.hiddenTextEntry.IsFocused)
                {
                    if (newPINLength < control.PINLength)
                    {
                        pinBoxArray[newPINLength].FocusAnimation();
                    }
                    // When while typing, if you reach to the last charecter, keep focus there (on last character Box),
                    // If PIN entry is focused
                    else if (newPINLength == control.PINLength)
                    {
                        pinBoxArray[newPINLength - 1].FocusAnimation();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
