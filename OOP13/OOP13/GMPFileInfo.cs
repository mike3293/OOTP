using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP13
{
    internal class GMPFileInfo
    {
        private const string path = @"C:/Users/admin/Desktop/evm_2.docx";
        private static FileInfo fi;

        static GMPFileInfo()
        {
            fi = new FileInfo(path);
        }

        public static string GetPath()
        {
            return "Dir name " + fi.DirectoryName + "\n";
        }

        public static string GetTimeCreation()
        {
            return "Time creation " + fi.CreationTime.ToString() + "\n\n";
        }

        public static string GetFileInfo()
        {
            string res = "";
            res += GetPath();
            res += "Space " + fi.Length / 1024 + " KB\n";
            res += "Extension " + fi.Extension + "\n";
            res += "Name " + fi.Name + "\n";
            res += GetTimeCreation();
            return res;
        }
    }
}
