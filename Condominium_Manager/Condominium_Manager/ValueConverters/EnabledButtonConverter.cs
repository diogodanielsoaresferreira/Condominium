using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Condominium_Manager
{
    public class EnabledButtonConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[1].ToString().Length<4)
                return false;
            
            QuotaView qv = (QuotaView)values[0];

            if (string.IsNullOrEmpty(qv.Nome))
                return false;

            int year = int.Parse(values[1].ToString());

            if (qv.Janeiro == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Fevereiro == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Marco == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Abril == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Maio == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Junho == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Julho == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Agosto == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Setembro == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Outubro == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Novembro == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;
            if (qv.Dezembro == false && inBetweenDates(qv.DateCompra, qv.DateVenda, 1, year))
                return false;


            return true;
        }
        

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool inBetweenDates(DateTime compra, DateTime venda, int month, int year)
        {
            DateTime dt = new DateTime(year, month, 1);

            if (dt > compra && dt < venda)
                return true;
            return false;

        }
        
    }
}
