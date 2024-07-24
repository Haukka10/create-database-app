using System;
using System.IO;
using System.Collections.Generic;
using DATABASE_useing_CSharp.inst;

namespace DATABASE_useing_CSharp.P.SQLMen
{
    internal class MakeTable_and_Column : IConsoleSystem
    {
        private int indexColumn = 1;
        private int indexTable = 1;
        public string NameColum;
        public string dataType;
        private int LastColumn;

        /// <summary>
        /// count amount table
        /// </summary>
        
        public int AmountTable()
        {
            Console.WriteLine("Set Ammount tables");
            string Atables = Console.ReadLine();
            
            int.TryParse(Atables, out LastColumn);
            return LastColumn;
        }

        /// <summary>
        /// Make base database
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="selectValueType"></param>
        public void SQLMAKE(StreamWriter sw,SelectValueType selectValueType)
        {
            Console.WriteLine($"Set Name Table {indexTable} ");
            string NameTable = Console.ReadLine();

            ColorConsole("Warning Automatic add column  name of 'ID'", ConsoleColor.Red);

            sw.WriteLine($"CREATE TABLE {NameTable} (");
            sw.WriteLine($"ID int NOT NULL PRIMARY KEY AUTO_INCREMENT,");

            AmountTable();

            for (int i = 0; i < LastColumn; i++)
            {
                Console.WriteLine($"Set name Column {indexColumn}");
                indexColumn++;

                NameColum = Console.ReadLine();

                selectValueType.SelectTypeData();
                dataType = selectValueType.valueType;

                if (i == LastColumn - 1)
                    TablesNull(sw, selectValueType, false);
                else
                    TablesNull(sw, selectValueType, true);
            }

            sw.WriteLine(");");
            ColerConsole();

            sw.WriteLine($"-- Name Table -> {NameTable} Index Table -> {indexTable} When {DateTime.Now.ToString()} --");
            Console.WriteLine("You add other table ?(type yes or no)");
            ShowAllTables(NameTable);

            string Add_New_Table = Console.ReadLine();

            if (Add_New_Table == "yes")
            {
                indexTable++;
                indexColumn = 1;

                selectValueType.ShowType();
                SQLMAKE(sw,selectValueType);
            }
            else
                return;
            
        }
        string end;
        /// <summary>
        /// Add a tables is null 
        /// </summary>
        /// <param name="sw"></param>
        private void TablesNull(StreamWriter sw,SelectValueType selectValueType, bool End_Table)
        {
            Console.WriteLine("Is to null ? (type yes or no)");
            string ISNULL = Console.ReadLine();

            if (End_Table)
                end = ",";
            
            if (ISNULL == "yes")
                sw.WriteLine($"{NameColum} {dataType} NOT NULL{end}");
            else 
                sw.WriteLine($"{NameColum} {dataType}{end}");

            ColerConsole();
            selectValueType.ShowType();
            end = string.Empty;
        }
        private readonly List<string> CTables = new List<string>();
        private string a;
        public void ShowAllTables(string tables)
        {
            CTables.Add(tables);
            a = String.Join(", ", CTables);
            Write($"{a} << All Tables");
        }

       public void ColerConsole()
       {
            Write(null);
            Console.Clear();
       }

       public void Write(string text)
       {
            Console.WriteLine(text); 
       }

        public void ColorConsole(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
