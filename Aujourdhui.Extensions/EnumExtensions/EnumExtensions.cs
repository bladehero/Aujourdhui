using Aujourdhui.Extensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#nullable enable

namespace Aujourdhui.Extensions.EnumExtensions
{
    public static class EnumExtensions
    {
        public static string? GetDescription<T>(this T enumValue, string? @default = null)
            where T : struct, Enum
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description ?? @default;
        }
        public static string? GetFileNameSeparator<T>(this T enumValue, string? @default = null)
            where T : struct, Enum
        {
            if (!typeof(T).IsEnum)
                return null;

            var separator = (string?)null;
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(FileNameSeparatorAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    separator = ((FileNameSeparatorAttribute)attrs[0]).Separator;
                }
            }

            return separator ?? @default;
        }
        public static int? GetImageSizeRate<T>(this T enumValue)
            where T : struct, Enum
        {
            if (!typeof(T).IsEnum)
                return null;

            var rate = (int?)null;
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(ImageSizeRateAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    rate = ((ImageSizeRateAttribute)attrs[0]).Rate;
                }
            }

            return rate;
        }

        public static LinkedList<T> ToLinkedList<T>()
            where T : struct, Enum
        {
            var values = Enum.GetValues<T>().AsEnumerable();
            var linkedList = new LinkedList<T>(values ?? Enumerable.Empty<T>());

            return linkedList;
        }
    }
}
