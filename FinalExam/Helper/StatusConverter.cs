using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using FinalExam.Model;

namespace FinalExam.Helper
{
    class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WorkStatus status = (WorkStatus)value;

            switch(status)
            {
                case WorkStatus.Complete:
                    return new SolidColorBrush(Colors.Blue);
                case WorkStatus.EndPeriod:
                    return new SolidColorBrush(Colors.Red);
                case WorkStatus.NormalProgress:
                    return new SolidColorBrush(Colors.Green);
                case WorkStatus.SlowProgress:
                    return new SolidColorBrush(Colors.Yellow);
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
