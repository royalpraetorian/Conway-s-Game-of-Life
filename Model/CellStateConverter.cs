using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Conway_s_Game_of_Life.Model
{
	public class CellStateConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
				return new SolidColorBrush(new Color() { R=116,G=175,B=95,A=255});
			else
				return new SolidColorBrush(new Color() {R=118, G=137, B=178, A=255 });
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
