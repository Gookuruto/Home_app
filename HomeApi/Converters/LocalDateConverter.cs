using NodaTime.Text;
using System.ComponentModel;
using System.Globalization;

namespace HomeApi.Converters
{
    public class LocalDateTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(string));
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return LocalDatePattern.Iso.Parse(value.ToString()).Value;
        }
    }
}
