using MemoMoods.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;


namespace MemoMoods.Views
{
	internal class MoodToBannerConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var mood = (int)value;
			return $"Banner{mood}.png";

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
