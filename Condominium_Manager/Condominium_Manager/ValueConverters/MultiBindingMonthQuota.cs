using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Condominium_Manager
{
    public class MultiBindingMonthQuota : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(string.IsNullOrEmpty(values[3].ToString()))
                return new BitmapImage(new Uri("/Images/noimage.png", UriKind.Relative));
            
            int year = int.Parse(values[3].ToString());

            DateTime compra = (DateTime)values[1];
            DateTime venda = (DateTime)values[2];
            int month = (int)values[4];

            if (compra == DateTime.MinValue || year < compra.Year || (year == compra.Year && month < compra.Month))
            {
                return new BitmapImage(new Uri("/Images/noimage.png", UriKind.Relative));
            }

            if(venda.Year < month || (venda.Year==year && venda.Month<= month))
                return new BitmapImage(new Uri("/Images/noimage.png", UriKind.Relative));

            if ((bool)values[0] == true)
            {
                return new BitmapImage(new Uri("/Images/check.png", UriKind.Relative));
            }
            else
            {
                return new BitmapImage(new Uri("/Images/wrong.png", UriKind.Relative));
            }
            
            
            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
