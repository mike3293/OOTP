using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP13
{
    class GMPDirInfo
    {
        private const string path = @"C:\\Users\\admin\\Desktop\\OOTP\\OOP5";
        private static DirectoryInfo di;

        static GMPDirInfo() => di = new DirectoryInfo(path);

        public static string GetFilesCount() => "Files " + Directory.GetFiles(path).Count().ToString() + "\n";
        public static string GetCreationTime() => "Dir creation time " + di.CreationTime.ToString() + "\n";
        public static string GetDirCount() => "Dirs " + Directory.GetDirectories(path).Count().ToString() + "\n";
        public static string GetDirList()
        {
            DirectoryInfo directory = di.Parent;
            string res = "Parent dir ";
            while (directory.Name != di.Root.ToString())
            {
                res += directory.Name + '\n';
                directory = directory.Parent;
            }
            res += directory.Name + '\n';
            return res + '\n';
        }
    }
}
