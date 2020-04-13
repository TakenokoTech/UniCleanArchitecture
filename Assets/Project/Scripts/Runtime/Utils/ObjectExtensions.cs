using System.Linq;
using System.Reflection;

namespace Runtime.Utils
{
    public static class ObjectExtensions
    {
        private const string Separator = ",";
        private const string Format = "{0}={1}";

        private static string ToStringFields<T>(this T obj) => string.Join(Separator, obj
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.Public)
            .Select(c => string.Format(Format, c.Name, c.GetValue(obj))));

        private static string ToStringProperties<T>(this T obj) => string.Join(Separator, obj
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(c => c.CanRead)
            .Select(c => string.Format(Format, c.Name, c.GetValue(obj, null))));

        public static string Dump<T>(this T obj)
        {
            var fields = obj.ToStringFields();
            var properties = obj.ToStringProperties();

            if ("".Equals(properties) && "".Equals(fields)) return "{}";
            if ("".Equals(fields)) return "{" + properties + "}";
            if ("".Equals(properties)) return "{" + fields + "}";
            return "{" + string.Join(Separator, fields, properties) + "}";
        }
    }
}