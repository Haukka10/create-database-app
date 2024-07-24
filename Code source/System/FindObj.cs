using System.IO;
using System.Collections.Generic;
using DATABASE_useing_CSharp.P.ServerData;

namespace DATABASE_useing_CSharp.P.System
{
    internal class FindObj
    {
        /// <summary>
        /// Find by id 
        /// </summary>
        /// <param name="serversDatas"></param>
        /// <param name="TopFinde"></param>
        /// <returns></returns>
        public object FindObjByID(List<ServersData> serversDatas,int TopFinde)
        {
            for (int i = 0; i < serversDatas.Count; i++)
            {
                if (serversDatas[i].ID == TopFinde.ToString())
                    return serversDatas[i];
            }

            return "Any Servers not Find";
        }
        /// <summary>
        /// Find by name tables all files 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="ToFind"></param>
        /// <returns></returns>
        public object FindObjByCon(string Path,string ToFind)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            var dir = directoryInfo.GetFiles();

            for (int o = 0; o < dir.Length; o++)
            {
                var itemPath = dir[o].FullName;
                string[] item = File.ReadAllLines(itemPath.ToString());

                ToFind = "CREATE TABLE " + ToFind;

                for (int i = 0; i < item.Length; i++)
                {
                    string test = item[i];

                    if (test.Length <= 2) continue;

                    test = test.Remove(test.Length - 2);

                    if (test == ToFind)
                        return dir[o].FullName;
                }
                ToFind = string.Empty;
            }

            return "Any Servers not Find";
        }

    }
}
