using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Security.AccessControl;

namespace WinLauncher.src.utils
{
    public class DownloadHelper
    {

        public static void downloadFile(string sourceURL, string destinationPath)
        {
            long fileSize = 0;
            int bufferSize = 1024;
            bufferSize *= 1000;
            long existLen = 0;

            System.IO.FileStream saveFileStream;
            if (System.IO.File.Exists(destinationPath))
            {
                System.IO.FileInfo destinationFileInfo = new System.IO.FileInfo(destinationPath);
                existLen = destinationFileInfo.Length;
            }

            if (existLen > 0)
                saveFileStream = new System.IO.FileStream(destinationPath,
                                                          System.IO.FileMode.Append,
                                                          System.IO.FileAccess.Write,
                                                          System.IO.FileShare.ReadWrite);
            else
                saveFileStream = new System.IO.FileStream(destinationPath,
                                                          System.IO.FileMode.Create,
                                                          System.IO.FileAccess.Write,
                                                          System.IO.FileShare.ReadWrite);

            System.Net.HttpWebRequest httpReq;
            System.Net.HttpWebResponse httpRes;
            httpReq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sourceURL);
            //httpReq.AddRange((int)existLen);
            System.IO.Stream resStream;
            httpRes = (System.Net.HttpWebResponse)httpReq.GetResponse();
            resStream = httpRes.GetResponseStream();

            fileSize = httpRes.ContentLength;

            int byteSize;
            byte[] downBuffer = new byte[bufferSize];

            while ((byteSize = resStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
            {
                saveFileStream.Write(downBuffer, 0, byteSize);
            }
        }

        public static string prepareDownload(App parent)
        {
            if (parent == null)
            {
                return null;
            }

            DirectoryInfo final = null;
            DirectoryInfo dir = Directory.CreateDirectory(parent.launcher.dirChoice.SelectedPath);

            if (dir.Exists)
            {
                try
                {
                    Console.WriteLine("Trying to remove privs...");
                    dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;

                }
                catch (ArgumentException e)
                {
                    parent.SetStatus(true, "Failed to download (No Access, Try running as admin)");
                    Console.WriteLine("ex 1");
                }

                try
                {
                    Console.WriteLine("Trying to create dirs...");
                    final = Directory.CreateDirectory(dir.FullName + "\\" + parent.APP_NAME);
                }
                catch (Exception e)
                {
                    parent.SetStatus(true, "Failed to download (No Access, Try running as admin)");
                    Console.WriteLine("ex 2");
                }
            }

            if (final == null)
            {
                return null;
            }

            return final.FullName;
        }
    }
}
