using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Security.AccessControl;
using WinLauncher.src.utils;
using WinLauncher.src.net.events.data;
using WinLauncher.src.net.events;

namespace WinLauncher.src.net
{
    public class RequestCrafter
    {
        public App parent;

        public RequestCrafter(App parent)
        {
            this.parent = parent;
        }

        public void MakePostRequest(string endpoint, Func<RestResponse, int> callback)
        {
            var request = new RestRequest(endpoint, Method.Post);
            this.parent.PipelineMonitor.AddOutgoing(request, callback);
        }

        public void MakeGetRequest(string endpoint, Func<RestResponse, int> callback)
        {
            var request = new RestRequest(endpoint, Method.Get);
            this.parent.PipelineMonitor.AddOutgoing(request, callback);
        }


        [EventTarget]
        public void EventTest(Event e)
        {
            Console.WriteLine("Events work!!!");
        }
    }
}
