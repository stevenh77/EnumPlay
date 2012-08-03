using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EnumPlay
{
    enum Position
    {
        [Description("Last line of defence, always crazy")]
        Goalie = 0,

        [Description("Big fast and love getting stuck in")]
        Defender,

        [Description("Play makers and tough tacklers")]
        Midfielder,

        [Description("Goalscorer for the team")]
        Forward
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OutputValues();
            OutputNames();
            OutputDescriptions();
        }

        private static void OutputValues()
        {
            Console.WriteLine("Values");

            var values = Enum.GetValues(typeof(Position));

            foreach (int value in values) 
            {
                Console.WriteLine("\t{0}", value);
            }

            Console.WriteLine();
        }

        private static void OutputNames()
        {
            Console.WriteLine("Names");

            var names = Enum.GetNames(typeof(Position));

            foreach (string name in names)
            {
                Console.WriteLine("\t{0}", name);
            }

            Console.WriteLine();
        }


        private static void OutputDescriptions()
        {
            Console.WriteLine("Descriptions");

            var enums = Enum.GetValues(typeof(Position)).Cast<Position>(); ;

            foreach (Position item in enums)
            {
                var description = item.GetDescription();
                Console.WriteLine("\t{0}", description);
            }

            Console.WriteLine();
        }
    }
}
