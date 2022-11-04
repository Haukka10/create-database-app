using System;
using System.Collections.Generic;

namespace DATABASE_useing_CSharp.P.Allfiles
{
    internal class ShowAllTablesInFiles
    {
        private string[] Names;
        /// <summary>
        /// Show all tables and show their names
        /// </summary>
        /// <param name="Tables"></param>
        public string[] SetUp(List<string> Tables)
        {
            if (Names is null)
                Names = new string[Tables.Count];
            return Names;
        }

        public void ShowAllTables(List<string> Tables)
        {
            SetUp(Tables);

            for (int i = 0; i < Tables.Count; i++)
            {
                string name = Tables[i];
                string fixname = name.Remove(name.Length - 2);
                Names.SetValue(fixname, i);
            }

            string AllName = string.Join(" ", Names);
            Console.WriteLine(AllName);
            Tables.Clear();
        }
    }
}
