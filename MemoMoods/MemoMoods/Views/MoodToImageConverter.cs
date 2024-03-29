using System;
using System.Globalization;
using Xamarin.Forms;

namespace MemoMoods.Views
{
	public class MoodToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var mood = (int)value;
			return $"Mood{mood}.png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}