using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Onero.Collections;

namespace Onero.Extensions
{
    public static class ExtensionMethods
    {
        internal delegate bool TryParse<T>(string str, out T value);

        internal static T GetValue<T>(this string str, TryParse<T> parseFunc)
        {
            T val;
            parseFunc(str, out val);
            return val;
        }

        internal static bool BoolAttribute(this XmlNode node, string attributeName, bool defaultValue = false)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value.GetValue<bool>(bool.TryParse);
            }

            return defaultValue;
        }

        internal static T ParseEnum<T>(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return (T)Enum.Parse(typeof(T), node.Attributes[attributeName].Value, true);
            }

            return default(T);
        }

        internal static int IntAttribute(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value.GetValue<int>(int.TryParse);
            }

            return 0;
        }
        
        internal static string StringAttribute(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value;
            }

            return string.Empty;
        }

        public static T Parse<T>(this string input, T defaultValue)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return defaultValue;
            }

            Type type = typeof(T);
            MethodInfo parseMethod = type.GetMethod("Parse", new [] { typeof(string) });

            try
            {
                if (parseMethod != null)
                {
                    var value = parseMethod.Invoke(null, new[] {input});
                    return (value is T ? (T) value : defaultValue);
                }
            }
            catch
            {
            }

            return defaultValue;
        }

        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();

        }

        public static void EnableProfile(this BindingList<Profile> profiles, Profile profileToEnable)
        {
            foreach (var profile in profiles)
            {
                profile.Enabled = false;
            }

            profileToEnable.Enabled = true;            
        }

        public static Profile EnabledOrDefault(this BindingList<Profile> profiles)
        {
            return Profiles.EnabledOrDefault(profiles);
        }

        public static string GetSelectedString(this CheckedListBox checkedListBox)
        {
            if (checkedListBox.SelectedItem == null)
            {
                return string.Empty;
            }

            return checkedListBox.SelectedItem as string;
        }
    }
}
