namespace PINView.Maui.Helpers
{
    public class PINCompletedEventArgs : EventArgs
    {
        public string PIN { get; set; }

        public PINCompletedEventArgs(string pin)
        {
            this.PIN = pin;
        }
    }
}
