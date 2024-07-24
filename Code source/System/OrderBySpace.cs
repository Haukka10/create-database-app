using System;
using System.Collections.Generic;
using System.IO;

namespace DATABASE_useing_CSharp.P.Oredrs
{
    internal class OrderBySpace
    {
        public string Name { get; set; }
        /// <summary>
        /// Order by free space in dysk 
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        public string OrderByS(List<DriveInfo> List)
        {

            int index = 1;
            if(List.Count % 2 != 0)
            {
                for (int i = 0; i < List.Count -1; i++)
                {
                    if (List[i].AvailableFreeSpace > List[index].AvailableFreeSpace)
                        Name = List[i].Name;
                    else
                        Name = List[index].Name;
                    index++;
                }
                return Name;
            }

            if (List[0].TotalFreeSpace > List[1].TotalFreeSpace)
                Name = List[0].Name;
            else
                Name = List[1].Name;

            return Name;
        }

    }
}
