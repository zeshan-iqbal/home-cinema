using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeCinema.Core.EnumExtensions
{
    public static class EnumExtensions
    {

        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GetStringValue(this Enum value)
        {
            var attribute = value.GetAttribute<StringValueAttribute>();
            return attribute == null ? value.ToString() : attribute.Value;
        }

        public static bool TryParseStringValue<TEnum>(string stringValue, out TEnum parsedValue)
        {
            parsedValue = default(TEnum);

            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                var memberInfo = typeof(TEnum).GetMember(enumValue.ToString());
                var attributes = memberInfo[0].GetCustomAttributes(typeof(StringValueAttribute), false);
                StringValueAttribute attr = (attributes.Length > 0) ? (StringValueAttribute)attributes[0] : default(StringValueAttribute);

                if (attr != null)
                {
                    if (stringValue == attr.Value)
                    {
                        parsedValue = (TEnum)Enum.Parse(typeof(TEnum), memberInfo[0].Name);
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool TryParseDescriptionValue<TEnum>(string descriptionValue, out TEnum parsedValue)
        {
            parsedValue = default(TEnum);

            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                var memberInfo = typeof(TEnum).GetMember(enumValue.ToString());
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                DescriptionAttribute attr = (attributes.Length > 0) ? (DescriptionAttribute)attributes[0] : default(DescriptionAttribute);

                if (attr != null)
                {
                    if (descriptionValue == attr.Description)
                    {
                        parsedValue = (TEnum)Enum.Parse(typeof(TEnum), memberInfo[0].Name);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
