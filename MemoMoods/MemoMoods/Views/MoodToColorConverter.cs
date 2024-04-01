using System;
using System.Globalization;
using Xamarin.Forms;

namespace MemoMoods.Views
{
	public class MoodToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color = "";
			if ((int)value == 0)
			{
				color = "#fff2f2";
			}
			else if ((int)value == 1)
			{
				color = "#fff5eb";
			}
			else if((int)value == 2)
			{
				color = "#fffae9";
			}
			else if((int)value == 3)
			{
				color = "#f1fbee";
			}
			else if((int)value == 4)
			{
				color = "#e9eef7";
			}
			if ((int)value == 5)
			{
				color = "#f7f5fc";
			}

			return $"{color}";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}