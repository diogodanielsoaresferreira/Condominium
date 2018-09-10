using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Condominium_Manager
{
    public class ColorValueConverter : BaseValueConverter<ColorValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value < 0)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
                return new SolidColorBrush(Colors.Green);
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
