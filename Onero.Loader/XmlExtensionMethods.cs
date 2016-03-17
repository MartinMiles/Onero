using System;
using System.Xml;

namespace Onero.Loader
{
    public static class XmlExtensionMethods
    {
        internal delegate bool TryParse<T>(string str, out T value);

        internal static T GetValue<T>(this string str, TryParse<T> parseFunc)
        {
            T val;
            parseFunc(str, out val);
            return val;
        }

        public static bool BoolAttribute(this XmlNode node, string attributeName, bool defaultValue = false)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value.GetValue<bool>(bool.TryParse);
            }

            return defaultValue;
        }

        public static T ParseEnum<T>(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return (T)Enum.Parse(typeof(T), node.Attributes[attributeName].Value, true);
            }

            return default(T);
        }

        public static int IntAttribute(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value.GetValue<int>(int.TryParse);
            }

            return 0;
        }

        public static string StringAttribute(this XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value;
            }

            return string.Empty;
        }
    }
}
