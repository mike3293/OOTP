using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP13
{
    internal class GMPFileManager
    {
        public static void MoveFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            string generalPath = path;
            path += "/GMPInspect";
            Directory.CreateDirectory(path);
            path += "/GMPdirinfo.txt";
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                sw.WriteLine("Directories: ");
                foreach (string s in dirs)
                {
                    sw.WriteLine(s);
                }

                sw.WriteLine("Files: ");
                foreach (string s in files)
                {
                    sw.WriteLine(s);
                }
            }
            generalPath += "/newName.txt";
            if (File.Exists(generalPath))
            {
                File.Delete(generalPath);
            }

            File.Copy(path, generalPath);
            File.Delete(path);
        }

        public static void MoveDirectoriesByExtension(string path, string extension)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles().Where(s => s.Extension == extension).ToArray();
            string generalPath = path;
            path += "/GMPFiles";
            Directory.CreateDirectory(path);
            foreach (FileInfo f in files)
            {
                if (File.Exists(path + '/' + f.Name))
                {
                    File.Delete(path + '/' + f.Name);
                }

                File.Move(f.FullName, path + '/' + f.Name);
            }
            generalPath += "/GMPInspect/GMPFiles";
            if (Directory.Exists(generalPath))
            {
                Directory.Delete(generalPath, true);
            }

            Directory.Move(path, generalPath);
        }

        public static void ToZip(string path)
        {
            string generalPath = path + "/GMPInspect/GMPFiles";

            if (File.Exists(path + "/GMPInspect/arch.zip"))
            {
                File.Delete(path + "/GMPInspect/arch.zip");
            }

            ZipFile.CreateFromDirectory(generalPath, path + "/GMPInspect/arch.zip");
            ZipFile.ExtractToDirectory(path + "/GMPInspect/arch.zip", path + "/unzip");
        }
    }
}
