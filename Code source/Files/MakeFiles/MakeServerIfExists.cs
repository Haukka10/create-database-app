using System;

namespace DATABASE_useing_CSharp.P
{
    internal class MakeServerExists
    {
        public int openI;

        /// <summary>
        /// New files servers or show files 
        /// </summary>
        public int NewFilesM(string path, CheckNameSever checkFiles )
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Server is exists");
            checkFiles.CheckServerName(path);

            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("You want to return a new file or search files ? (Type 1 search by id. Type 2 serach by tables -1 to make new files)");

            string open = Console.ReadLine();
            int.TryParse(open, out openI);
            return openI;
        }
    }
}
