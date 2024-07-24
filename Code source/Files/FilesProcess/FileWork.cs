using DATABASE_useing_CSharp.CheckValues;
using DATABASE_useing_CSharp.P.SQLMen;
using DATABASE_useing_CSharp.inst;
using System.IO;
using System;
using System.Text;

namespace DATABASE_useing_CSharp.P
{
    internal class FileWork : IConsoleSystem
    {
        public string nameDataBase;
        private ChecksNameValues Class1 = new ChecksNameValues();
        /// <summary>
        /// Set name database and check length 
        /// </summary>
        /// <param name="filePaht"></param>
        public void EnterName(string filePaht)
        {
            nameDataBase = Console.ReadLine();

            if (nameDataBase.Length >= 25)
            {
                Console.WriteLine("Error to long name");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Enter your name of DataBase  (Max 25 letters & min 2 letters) : \n");

                EnterName(filePaht);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your name Data Base");

                ColorConsole(nameDataBase, ConsoleColor.DarkBlue);

                if (nameDataBase.Length <= 1)
                    Class1.CheckValues(nameDataBase);

                Class1.FixVale = nameDataBase;
                Console.ResetColor();
                OptionsValue(filePaht);
            }
        }
        /// <summary>
        /// Select how make database
        /// </summary>
        /// <param name="filePaht"></param>
        public void OptionsValue(string filePaht)
        {
            using (FileStream fs = File.Create(filePaht))
                fs.Close();

            using (StreamWriter sw = new StreamWriter(filePaht))
            {
                sw.WriteLine("CREATE DATABASE " + nameDataBase + ";");
                sw.WriteLine("USE " + nameDataBase + ";");

                SelectValueType selectValueType = new SelectValueType();
                selectValueType.ShowType();

                MakeTable_and_Column class2 = new MakeTable_and_Column();
                class2.SQLMAKE(sw, selectValueType);
                sw.Close();
            }
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