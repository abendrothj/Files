// Copyright (c) Files Community
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Data;
using System;
using Windows.Foundation;

namespace Files.App.Converters
{
	public sealed class SubtractConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is double doubleValue && parameter is string stringParam && double.TryParse(stringParam, out double subtractValue))
			{
				var result = Math.Max(0, doubleValue - subtractValue);
				
				// If target type is Rect, return a Rect with the calculated width
				if (targetType == typeof(Rect))
				{
					return new Rect(0, 0, result, 1000);
				}
				
				return result;
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
