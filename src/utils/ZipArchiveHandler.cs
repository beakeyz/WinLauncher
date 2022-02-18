using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLauncher.src.utils
{
    public static class ZipArchiveHandler
    {
        public static void UnzipArchive(string pathToFile, string path)
        {
            if (File.Exists(pathToFile))
            {
                if (pathToFile.EndsWith(".zip"))
                {
                    try
                    {
                        ZipFile.ExtractToDirectory(pathToFile, path);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
