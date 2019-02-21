using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfobservableCollectionsAndConverters
{
    class PolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int ulaz = value is int a ? a : 0;
            SolidColorBrush izlaz = new SolidColorBrush(Colors.Black);
            if (ulaz == 0)
            {
                izlaz = new SolidColorBrush(Colors.RoyalBlue);
            }
            if (ulaz == 1)
            {
                izlaz = new SolidColorBrush(Colors.LightPink);
            }
            return izlaz;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
