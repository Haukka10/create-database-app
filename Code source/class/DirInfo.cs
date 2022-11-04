using DATABASE_useing_CSharp.P.Oredrs;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CounterFiles
{
    internal class HDIRinfo
    {
        public FileInfo[] DirList { get; set; }
        public string DirectoryFilesToSaver { get; set; }
        private OrderBySpace OrderBySpace = new OrderBySpace();

        public void CounterFiles(string path)
        {
            DirectoryInfo _directoryInfo = new DirectoryInfo(path);
            DirList = _directoryInfo.GetFiles();
        }

        public void CheckSpaceToWereSeveF()
        {
            DriveInfo[] _DriveInfo = DriveInfo.GetDrives();

            if (_DriveInfo.Length == 1)
                DirectoryFilesToSaver = _DriveInfo[0].Name;

            OrderBySpace.OrderByS(_DriveInfo.ToList());

            DirectoryFilesToSaver = OrderBySpace.Name;
        }
        
    }
}
