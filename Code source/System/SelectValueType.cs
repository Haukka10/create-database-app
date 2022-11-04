using DATABASE_useing_CSharp.inst;
using System.Collections.Generic;
using System;

namespace DATABASE_useing_CSharp.P
{
    internal class SelectValueType : IConsoleSystem
    {
        private string _valueType;
        private static int C;
        public string valueType
        {
            get { return _valueType; }
            set { _valueType = value; }
        }

        public List<string> type = new List<string>() { "INT", "BIGINT", "FLOAT", "DOUBLE", "BIT", "BOOLEAN", "VARCHAR", "TEXT", "DATETIME", "DATE", "CHAR" };
        /// <summary>
        /// Select data value to set in files 
        /// </summary>
        /// <returns></returns>
        public string SelectTypeData()
        {
            Console.WriteLine(" select the type of data ");
            string ans = Console.ReadLine();

            int.TryParse(ans, out C);

            try
            {
                valueType = type[C];
                CHValue();
                return valueType;
            }
            catch (Exception)
            {
                ColorConsole("Can't find this number then set 'int' ", ConsoleColor.Red);
                return valueType = type[0];
            }
        }

        string Smax;
        string Smin;
        /// <summary>
        /// Check Values if is float or double 
        /// </summary>
        private string CHValue()
        {
            if (valueType == "BOOLEAN")
                return "BOOLEAN";

            int size;
            Write("Want to add a range value? (type number)");

            Smax = Console.ReadLine();
            int.TryParse(Smax, out size);
            
            if (size == 0)
                size = int.MaxValue - 2000;

            if (valueType != "FLOAT" && valueType != "DOUBLE")
            {
                return valueType = $"{valueType}({size})";
            }
            else
            {
                int decimal_point;
                ColorConsole("You choosing float or double please type max decimal point",ConsoleColor.Red);
                Smin = Console.ReadLine();

                int.TryParse(Smin, out decimal_point);
                Smax = string.Empty;
                Smin = string.Empty;

                return valueType = $"{valueType}({size},{decimal_point})";
            }
        }
        string CheckToAddValues;
        /// <summary>
        /// Show all type of date to add 
        /// </summary>
        public void ShowType()
        {
            int? a = 0;

            foreach (var item in type)
            {
                ColorConsole(a + " " + item, ConsoleColor.Yellow);
                a++;
            }

            a = null;
            if (CheckToAddValues == "yes" || CheckToAddValues == "no")
                return;
            Console.ResetColor();

            Write("Add new value ? (type yes or no)");
            CheckToAddValues = Console.ReadLine();

            if (CheckToAddValues == "yes")
                AddValues();
        }

        /// <summary>
        /// Add to pool value 
        /// </summary>
        public void AddValues()
        {
            string NewValue;

            Console.WriteLine("Eneter value");
            NewValue = Console.ReadLine();

            type.Add(NewValue);
            ShowType();
        }

        public void Write(string text) => Console.WriteLine(text);

        public void ColerConsole()
        {
            Write(null);
            Console.Clear();
        }

        public void ColorConsole(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
