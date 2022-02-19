using System;
using System.Text;
using System.IO;
using System.Threading;
using WinLauncher.src.utils;
using WinLauncher.src.net;
using WinLauncher.src.net.pipeline;
using WinLauncher.src.net.events;
using WinLauncher.src.net.auth;

namespace WinLauncher.src
{
    public class App
    {
        public static App instance;
        public RequestCrafter reqCrafter;
        public WinLauncher launcher;
        public PipelineMonitor PipelineMonitor;
        public AuthHandler AuthHandler;
        public static EventBus EVENT_BUS;

        //This should be the token the client recieves, after the sever confirms download perms
        public static string launcherClientToken = "";

        public string APP_NAME { get; }
        public string DEFAULT_PATH { get; }

        //Initialize
        public App()
        {
            instance = this;
            APP_NAME = "Gygabyte_Driver_test";
            DEFAULT_PATH = "C:\\";
            this.launcher = new WinLauncher(instance);
            this.reqCrafter = new RequestCrafter(instance);
            this.AuthHandler = new AuthHandler(instance);
            this.PipelineMonitor = new PipelineMonitor();
            //EVENT_BUS = new EventBus();

            //EVENT_BUS.Register(this.PipelineMonitor);
            //EVENT_BUS.CallEvent(new Event());
        }

        public void AppShutdown()
        {
            this.PipelineMonitor.ShutdownPipeline();
        }

        //TODO: clean up
        public void HandleDownload()
        {
            //this.SetStatus(true, "Trying to download...");

            this.reqCrafter.MakeGetRequest("/", callback =>
            {
                try
                {
                    DirectoryInfo dir = Directory.CreateDirectory(this.launcher.dirChoice.SelectedPath + "\\" + this.APP_NAME);
                    if (dir.Exists)
                    {
                        //Write download
                        File.WriteAllBytes($"{this.launcher.dirChoice.SelectedPath}\\{this.APP_NAME}\\{this.APP_NAME}.zip", callback.RawBytes);
                    }

                    //App.instance.SetStatus(true, "Download finished");

                    //Thread.Sleep(3000);

                    //App.instance.SetStatus(true, "Trying to unzip ...");

                    //Unzip the archive
                    ZipArchiveHandler.UnzipArchive($"{dir.FullName}\\{this.APP_NAME}.zip", $"{dir.FullName}");
                    File.Delete($"{dir.FullName}\\{this.APP_NAME}.zip");

                    //App.instance.SetStatus(true, "Unzipped archive!");

                    //Thread.Sleep(1000);

                    //Create shortcut
                    if (this.launcher.shortcutCheckbox.Checked)
                    {
                        //App.instance.SetStatus(true, "Creating shortcut ...");

                        foreach (var FileInfo in dir.GetFiles())
                        {
                            if (FileInfo.FullName.Contains($"{this.APP_NAME}.exe"))
                            {
                                ShortcutHandler.CreateShortcut(FileInfo.FullName, this.APP_NAME, this.APP_NAME + " - " + FileInfo.FullName);
                                break;
                            }

                            if (FileInfo.FullName.EndsWith(".exe") && !FileInfo.FullName.Contains("uninstall") && !FileInfo.FullName.Contains("repair"))
                            {
                                ShortcutHandler.CreateShortcut(FileInfo.FullName, this.APP_NAME, this.APP_NAME + " - " + FileInfo.FullName);
                                break;
                            }
                        }

                        if (ShortcutHandler.CurrentShortcutHandle == null)
                        {
                            //App.instance.SetStatus(true, "Could not create shortcut!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return -1;
                }
                return 0;
            });



        }

        public void SetStatus(bool visible, string data)
        {
            this.launcher.statusUpdateLabel.Visible = visible;
            this.launcher.statusUpdateLabel.Text = data;
        }

        public void SetProgressBar(int value)
        {
            this.launcher.InstallationProgressBar.Value = value;
        }
    }
}
