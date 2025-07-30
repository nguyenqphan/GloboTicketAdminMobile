using GloboTicketAdmin.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicketAdmin.Mobile.Converters
{
    public class StatusEnumToTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not EventStatusEnum status)
            {
                return string.Empty;
            }

            return status switch
            {
                EventStatusEnum.Onsale => "On Sale",
                EventStatusEnum.AlmostSoldOut => "Almost Sold Out",
                EventStatusEnum.SalesClosed => "Sales Closed",
                EventStatusEnum.Canceled => "Canceled",
                _ => string.Empty
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
