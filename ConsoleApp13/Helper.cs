using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal static class Helper
    {
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void MenuMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static T TryConvert<T>(this string text, bool isNewLine)
        {
            T number;

            while (true)
            {
                if (isNewLine)
                    Console.WriteLine(text);
                else
                    Console.Write(text);

                try
                {
                    number = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return number;
                }
                catch (Exception)
                {
                    ErrorMessage("Invalid number");
                    continue;
                }
            }
        }

        public static T TryConvert<T>(this string text, bool isNewLine, ConsoleColor color)
        {
            T number;

            while (true)
            {
                Console.ForegroundColor = color;
                if (isNewLine)
                    Console.WriteLine(text);
                else
                    Console.Write(text);

                Console.ResetColor();

                try
                {
                    number = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return number;
                }
                catch (Exception)
                {
                    ErrorMessage("Invalid number");
                    continue;
                }
            }
        }

        public static string TryConvertNullOrWhiteSpaceCheck(this string text, bool isNewLine)
        {
            string value;

            while (true)
            {
                if (isNewLine)
                    Console.WriteLine(text);
                else
                    Console.Write(text);

                value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                    return value;

                ErrorMessage("value cant be empty");
            }
        }

        public static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
