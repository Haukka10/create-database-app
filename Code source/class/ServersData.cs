using System;
using System.Collections.Generic;

namespace DATABASE_useing_CSharp.P.ServerData
{
    internal class ServersData
    {
        public string ID { get; set; }
        public DateTime Date { get; set; }
        public List<string> ServerContents { get; set; }

        public ServersData(string Id, DateTime time,List<string> ServerContent)
        {
            ID = Id;
            Date = time;
            ServerContents = ServerContent;
        }
        
    }
}
