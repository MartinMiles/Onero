using System;
using System.Reflection;
using System.Xml;

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

        internal static bool BoolAttribute(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value.GetValue<bool>(bool.TryParse);
            }

            return false;
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
    }
}
