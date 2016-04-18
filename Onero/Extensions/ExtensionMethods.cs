using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Onero.Collections;

namespace Onero.Extensions
{
    public static class ExtensionMethods
    {
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

        // TODO: Move to checked list Extensions
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
