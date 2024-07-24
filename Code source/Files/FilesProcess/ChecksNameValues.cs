using DATABASE_useing_CSharp.P;
using System.IO;
using System;

namespace DATABASE_useing_CSharp.CheckValues
{
    internal class ChecksNameValues
    {
        public string FixVale;
        public string CheckValues(string ValeToCheck)
        {
            if (ValeToCheck == string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name not Set");
                Console.ResetColor();

                FixVale = Console.ReadLine();

                if (FixVale == string.Empty)
                    CheckValues(ValeToCheck);
                return "";
            }
            else
                return ValeToCheck;
        }
        public void DeleteErrorFile(string ErrorFiles,string ErrorPath)
        {
            Console.WriteLine($"You wan delete this file {ErrorFiles}");
            File.Delete(ErrorPath);
        }
    }
}