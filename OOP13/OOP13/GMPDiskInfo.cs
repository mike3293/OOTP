using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP13
{
    internal class GMPDiskInfo
    {
        private static DriveInfo[] di;

        static GMPDiskInfo()
        {
            di = DriveInfo.GetDrives();
        }

        public static string GetFreeSpace()
        {
            long space = 0;
            foreach (DriveInfo d in di)
            {
                space += d.AvailableFreeSpace;
            }

            return "Free space\t" + space.ToString();
        }

        public static string GetFileSystem()
        {
            return di[0].DriveFormat;
        }

        public static string GetDiskInfo()
        {
            string res = "";
            foreach (DriveInfo d in di)
            {
                if (d.IsReady)
                {
                    res += "Disk Name " + d.Name + "\n";
                    res += "Disk space " + Math.Floor(d.TotalSize / Math.Pow(1024, 3)) + " GB\n";
                    res += "Disk free space " + Math.Floor(d.TotalFreeSpace / Math.Pow(1024, 3)) + " GB\n";
                    res += "Volume label " + d.RootDirectory.ToString() + "\n\n";
                }
            }
            return res;
        }

    }
}
