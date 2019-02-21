using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfobservableCollectionsAndConverters
{
    class PozicijaConverter : IValueConverter
    {
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int ulaz = value is int a ? a : 0;
            string izlaz = "";
            switch (ulaz)
            {
                case 1:
                    izlaz = "Direktor";
                    break;
                case 2:
                    izlaz = "Menadzer";
                    break;
                case 3:
                    izlaz = "Programer";
                    break;
                case 4:
                    izlaz = "Radnik";
                    break;
                default:
                    izlaz = "Greska";
                    break;
            }

            return izlaz;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ulaz = value?.ToString()?.ToLower() ?? "greska";
            int izlaz = 0;
            switch (ulaz)
            {
                case "direktor":
                    izlaz = 1;
                    break;
                case "menadzer":
                    izlaz = 2;
                    break;
                case "programer":
                    izlaz = 3;
                    break;
                case "radnik":
                    izlaz = 4;
                    break;
                default:
                    izlaz = 0;
                    break;
            }
            return izlaz;
        }
    }
}
