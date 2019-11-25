using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP13
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(GMPDiskInfo.GetDiskInfo());
            GMPLog.Write(GMPDiskInfo.GetDiskInfo());

            Console.WriteLine(GMPFileInfo.GetFileInfo());
            GMPLog.Write(GMPFileInfo.GetFileInfo());

            Console.WriteLine(GMPDirInfo.GetCreationTime());
            GMPLog.Write(GMPDirInfo.GetCreationTime());
            Console.WriteLine(GMPDirInfo.GetDirCount());
            GMPLog.Write(GMPDirInfo.GetDirCount());
            Console.WriteLine(GMPDirInfo.GetFilesCount());
            GMPLog.Write(GMPDirInfo.GetFilesCount());
            Console.WriteLine(GMPDirInfo.GetDirList());
            GMPLog.Write(GMPDirInfo.GetDirList());
            GMPLog.Write("*Session - " + DateTime.Now.Date.ToString() + "*");

            string path = "ToMove";
            GMPFileManager.MoveFiles(path);
            GMPFileManager.MoveDirectoriesByExtension(path, ".docx");
            GMPFileManager.ToZip(path);

            Console.WriteLine($"COUNT: {GMPLog.GetRecordCount()}");
            Console.WriteLine(GMPLog.GetInfoByDay(DateTime.Now.Date));

            GMPLog.Close();
            Console.ReadKey();
        }
    }
}
