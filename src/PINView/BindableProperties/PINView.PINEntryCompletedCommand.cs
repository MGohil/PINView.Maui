using System.Windows.Input;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// A Command to Bind and invoked when PIN Entry is completed
        /// </summary>
        public ICommand PINEntryCompletedCommand
        {
            get { return (ICommand)GetValue(PINEntryCompletedCommandProperty); }
            set { SetValue(PINEntryCompletedCommandProperty, value); }
        }

        public static readonly BindableProperty PINEntryCompletedCommandProperty =
           BindableProperty.Create(
              nameof(PINEntryCompletedCommand),
              typeof(ICommand),
              typeof(PINView),
              null);
    }
}
