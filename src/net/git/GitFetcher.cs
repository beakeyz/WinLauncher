using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLauncher.src.utils;

namespace WinLauncher.src.net.git
{
    public class GitFetcher
    {
        public App parent;
        public string token;
        public string url;
        public string path;

        public bool hasData;

        public GitFetcher(string token, string url, string path, App parent)
        {
            this.parent = parent;
            this.token = token;
            this.url = url;
            this.path = path;
            this.hasData = token != null && url != null && path != null;
        }

        public string FetchGitRepo()
        {
            if (hasData)
            {
                string target = DownloadHelper.prepareDownload(this.parent);

                if (target == null)
                {
                    return null;
                }

                if (!this.url.Contains("github"))
                {
                    Console.WriteLine("That's not github :frowning:");
                    this.clearData();
                    return "fuck you dingo";
                }

                using (var client = new System.Net.Http.HttpClient())
                {
                    var credentials = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}:", token);
                    credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
                    var contents = client.GetByteArrayAsync(url).Result;
                    System.IO.File.WriteAllBytes(target + "test.zip", contents);
                    return target;
                }
            }

            return path;
        }

        public void clearData()
        {
            this.token = null;
            this.url = null;
            this.path = null;
            this.hasData = false;
        }

        public void reInit(string token, string url, string path)
        {
            this.token = token;
            this.url = url;
            this.path = path;
            this.hasData = token != null && url != null && path != null;
        }
    }
}
