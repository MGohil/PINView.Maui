using System;
using System.Globalization;

namespace PINView.Converters
{
    public class SizeToCornerRadiusConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            if (value is int)
            {
                return (float)(System.Convert.ToInt32(value) / 2);
            }

            if (value is double)
            {
                return (float)(System.Convert.ToDouble(value) / 2);
            }

            if (value is float)
            {
                return (float)((float)(value) / 2);
            }

            return value;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

}