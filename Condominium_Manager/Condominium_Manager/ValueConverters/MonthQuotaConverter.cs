using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Condominium_Manager
{
    public class MonthQuotaConverter : BaseValueConverter<MonthQuotaConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CondominoQuotaView cv = (CondominoQuotaView)value;
            if (cv.pay == true)
            {
                return @"/Images/check.png";
            }
            else
            {
                
                if(cv.compra>=new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1))
                    return @"/Images/check.png";
                return @"/Images/wrong.png";
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
