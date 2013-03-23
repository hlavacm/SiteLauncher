using System;
using System.Globalization;
using System.Windows.Data;

namespace Netcorex.SiteLauncher.Converters
{
	public class UriConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			return new Uri(value.ToString(), UriKind.RelativeOrAbsolute);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}