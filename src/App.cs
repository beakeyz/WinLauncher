using System;
using System.Text;
using System.IO;
using WinLauncher.src.net;
using WinLauncher.src.net.pipeline;
using WinLauncher.src.net.events;
using WinLauncher.src.net.auth;

namespace WinLauncher.src
{
    public class App
    {
        public RequestCrafter reqCrafter;
        public WinLauncher launcher;
        public PipelineMonitor PipelineMonitor;
        public AuthHandler AuthHandler;
        public static EventBus EVENT_BUS;

        //This should be the token the client recieves, after the sever confirms download perms
        public string launcherClientToken = "";

        public string APP_NAME { get; }
        public string DEFAULT_PATH { get; }

        //Initialize
        public App()
        {
            APP_NAME = "test";
            DEFAULT_PATH = "C:\\";
            this.launcher = new WinLauncher(this);
            this.reqCrafter = new RequestCrafter(this);
            this.AuthHandler = new AuthHandler(this);
            this.PipelineMonitor = new PipelineMonitor();
            EVENT_BUS = new EventBus();

            EVENT_BUS.Register(this.PipelineMonitor);

            EVENT_BUS.CallEvent(new Event());


        }

        public void AppShutdown()
        {
            this.PipelineMonitor.ShutdownPipeline();
        }

        public void HandleDownload()
        {
            this.reqCrafter.MakeGetRequest("/556e5e3f-0ab9-4b6c-aa62-c42f6a6cf20c", callback =>
            {
                Console.WriteLine(callback.Content);
                
                return 0;
            });
        }

        public void SetStatus(bool visible, string data)
        {
            this.launcher.statusUpdateLabel.Visible = visible;
            this.launcher.statusUpdateLabel.Text = data;
        }
    }
}
