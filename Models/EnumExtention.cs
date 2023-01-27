using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LingonberryStudio.Models
{
    public static class EnumExtention
    {
        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var fieldInfo = value.GetType().GetField(value.ToString() !);
            var attributes = (DescriptionAttribute[])fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString() !;
        }

        //public static string GetEnumMemberValue<TEnum>(this TEnum value)
        //{
        //    var fieldInfo = value.GetType().GetField(value.ToString());
        //    var attributes = (EnumMemberAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);

        //    return attributes.Length > 0 ? attributes[0].Value : value.ToString();
        //}

        public static SelectList ToSelectList<TEnum>(this Enum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new { Id = e, Name = GetEnumDescription(e) });

            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}
