using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Extensions
{
    public static class EnumExtensions
    {
        public static TEnum ToEnum<TEnum>(this int value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
        }

        public static TEnum ToEnum<TEnum>(this string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), string.IsNullOrWhiteSpace(value) ? "0" : value);
        }
    }
}
