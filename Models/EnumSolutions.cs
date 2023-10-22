using System.ComponentModel;
using System.Reflection;

namespace QuadraticEquation.Models
{
    public enum EnumSolutions
    {
        [Description("Рівняння немає розв'язків")]
        None,
        [Description("Рівняння має один розв'язок")]
        One,
        [Description("Рівняння має два розв'язки")]
        Two,
        [Description("Рівняння має безліч розв'язків")]
        Infinity = 0
    }

    public static class ExstendEnumSolutions
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}