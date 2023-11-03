using System;
using System.IO;
using CounterFiles;
using System.Collections.Generic;
using DATABASE_useing_CSharp.P.Allfiles;
using DATABASE_useing_CSharp.P.ServerData;
using DATABASE_useing_CSharp.P.System;

namespace DATABASE_useing_CSharp.P
{
    internal class ShowDataBasesTablesAndColumns
    {
        private ShowAllTablesInFiles ShowAllTablesInFiles = new ShowAllTablesInFiles();
        private List<ServersData> serversDatas = new List<ServersData>();
        private List<string> TablesNames = new List<string>();
        private List<string> Tables = new List<string>();

        private static HDIRinfo DirInfo = new HDIRinfo();
        private static FindObj find = new FindObj();

        private string[] Value;
        private int _ammontTables;
        private string PahtF;
        private string path;
        private int IndexFiles = 0;

        public void Strat(List<ServersData> serversD)
        {
            DirInfo.CheckSpaceToWereSeveF();
            path = DirInfo.DirectoryFilesToSaver + @"Server";
            PahtF = DirInfo.DirectoryFilesToSaver + @"Server\";
            serversDatas = serversD;
        }

        public int AmountTables
        {
            get { return _ammontTables; }
            set { _ammontTables = value; }
        }

        public int CounterTables(string filePaht)
        {
            try
            {
                Value = File.ReadAllLines(filePaht);
            }
            catch (Exception)
            {
                return 0;
            }
            
            foreach (var item in Value)
            {
                if(!item.Contains("--"))
                TablesNames.Add(item);

                if (item.Contains("CREATE TABLE "))
                    Tables.Add(item);
            }
            ShowTables(TablesNames, filePaht);
            return AmountTables;
        }

        /// <summary>
        /// Show All tables and where from 
        /// </summary>
        /// <param name="ListNames"></param>
        /// <param name="filePaht"></param>
        private void ShowTables(List<string> ListNames, string filePaht)
        {
            AmountTables = 0;
            TablesNames = new List<string>();

            CheckNextDB();
        }
        /// <summary>
        /// Get new BD to checkz
        /// </summary>
        private void CheckNextDB()
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            var Connet = dir.GetFiles();

            IndexFiles++;
            if (Connet.Length > IndexFiles)
            {
                PahtF = $@"{path}\\{Connet[IndexFiles]}";
                CounterTables(PahtF);
            }
        }
        private int i;
        /// <summary>
        /// Show files content 
        /// </summary>
        /// <param name="Index"></param>
        public void ShowServer(int Index)
        {
            switch (Index)
            {
                case 1:
                    Console.WriteLine("Set id to search");
                    string index = Console.ReadLine();
                    int.TryParse(index, out i);
                    if (serversDatas.Count > i)
                    {
                        ServersData DataServer = (ServersData)find.FindObjByID(serversDatas, i);
                        ShowID(DataServer);

                        ShowAllTablesInFiles.SetUp(Tables);
                        ShowAllTablesInFiles.ShowAllTables(Tables);
                    }
                    break;
                case 2:
                    Console.WriteLine("Type name of tables ");
                    var m = Console.ReadLine();
                    var I = (string)find.FindObjByCon(path, m);
                    ShowC(I);
                    break;
            }
        }
        /// <summary>
        /// Show data server by id
        /// </summary>
        private void ShowID(ServersData DataServer)
        {
            Console.WriteLine("Server id " + DataServer.ID);
            Console.WriteLine("Server make in date " + DataServer.Date);
            Console.WriteLine("Server Content");

            foreach (var item in DataServer.ServerContents)
                Console.WriteLine(item);
        }
        /// <summary>
        /// Show data server by Content
        /// </summary>
        /// <param name="Mess"></param>
        private void ShowC(string Mess) => Console.WriteLine(Mess);
    }
}