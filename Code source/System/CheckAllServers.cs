using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DATABASE_useing_CSharp.P.ServerData;

namespace DATABASE_useing_CSharp.P.System
{
    internal class CheckAllServers
    {
        public List<ServersData> serversDatas;
        public void CheckDir(string pathFile,string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            int IFiles = dirInfo.GetFiles().Length;

            if (serversDatas is null)
                serversDatas = new List<ServersData>();

            for (int i = 0; i < IFiles; i++)
            {
                string[] ServerContents = File.ReadAllLines(pathFile);
                serversDatas.Add(new ServersData($"{i}", DateTime.Now, ServerContents.ToList()));
            }
        }
    }
}
