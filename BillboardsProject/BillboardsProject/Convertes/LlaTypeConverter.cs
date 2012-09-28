using System;
using System.ComponentModel;
using Billboards.Common.Models;

namespace BillboardsProject.Convertes
{
    public class LLATypeConverter : TypeConverter
    {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                return LLA.TryParse((string)value);
            }

            return base.ConvertFrom(context, culture, value);
        }

    }
}