using System;
using System.IO;
using CounterFiles;
using DATABASE_useing_CSharp.P;
using DATABASE_useing_CSharp.P.System;

namespace DATABASE_useing_CSharp
{
    internal class Program
    {
        private static ShowDataBasesTablesAndColumns ShowDataBasesTablesAndColumns = new ShowDataBasesTablesAndColumns();
        private static MakeServerExists makeServer = new MakeServerExists();
        private static CheckNameSever checkFiles = new CheckNameSever();
        private static CheckAllServers AServers = new CheckAllServers();
        private static HDIRinfo DirInfo = new HDIRinfo();

        public static string filePaht = @"\Server\ServerCfg1.sql";

        private static void Main()
        {
            DirInfo.CheckSpaceToWereSeveF();
            var path = $@"{DirInfo.DirectoryFilesToSaver}\Server";
            filePaht = $@"{DirInfo.DirectoryFilesToSaver}\Server\ServerCfg1.sql";

            //Check if a dir is exists 
            if (Directory.Exists(path))
            {
                 DirInfo.CounterFiles(path);
            }
            else
            {
                Directory.CreateDirectory(path);
            }

            AServers.CheckDir(filePaht,path);

            var Connet = DirInfo.DirList;

            if (Connet is null)
                MakeServerFile(path);

            if(Connet != null)
                switch (Connet.Length)
                {
                    case 0:
                        MakeServerFile(path);
                        break;
                    default:
                        MakeServerIfExists(path,Connet);
                        break;
                }
        }
        private static void addNewFile(int a, FileInfo[] Connets,string TOsave)
        {
            filePaht = $@"{TOsave}\ServerCfg{a}.sql";
            foreach (var item in Connets)
            {
                if (filePaht.Contains(item.Name))
                    filePaht = $@"{TOsave}\ServerCfg{a++}.sql";
            }
        }
        /// <summary>
        /// Make File & Set name
        /// </summary>
        private static void MakeServerFile(string path)
        {
            Console.Clear();
            Console.Write("Enter your name of DataBase (Max 20 letters): ");

            Directory.CreateDirectory(path);

            FileWork fileWork = new FileWork();
            fileWork.EnterName(filePaht);

            if (File.Exists(filePaht))
                return;

        }
        /// <summary>
        /// Make Server and Check other servers files
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Connet"></param>
        public static void MakeServerIfExists(string path, FileInfo[] Connet)
        {
            ShowDataBasesTablesAndColumns.Strat(AServers.serversDatas);
            makeServer.NewFilesM(path,checkFiles);
            int openI = makeServer.openI;

            if (openI == -1)
            {
                addNewFile(Connet.Length + 1, Connet, path);
                MakeServerFile(path);
            }
            else
            {
                Console.Clear();
                ShowDataBasesTablesAndColumns.CounterTables(filePaht);
                ShowDataBasesTablesAndColumns.ShowServer(openI);

                MakeServerIfExists(path, Connet);
            }
        }
    }
}