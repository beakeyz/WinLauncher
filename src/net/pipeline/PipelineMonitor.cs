using System;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading;
using WinLauncher.src.net.events.impl;
using WinLauncher.src.net.events.data;
using WinLauncher.src.net.events;

namespace WinLauncher.src.net.pipeline
{
    public class PipelineMonitor
    {
        public static PipelineMonitor instance;
        public readonly RestClient Client;
        public Thread requestPipelineThread;
        public Queue<Tuple<RestResponse, Func<RestResponse, int>>> incommingQueue;
        public Queue<Tuple<RestRequest, Func<RestResponse, int>>> outgoingQueue;

        public int unresolvedOutgoing;

        public PipelineMonitor()
        {
            if (instance != null)
            {
                throw new ApplicationException("There was already a pipeline instance");
            }
            instance = this;
            incommingQueue = new Queue<Tuple<RestResponse, Func<RestResponse, int>>>();
            outgoingQueue = new Queue<Tuple<RestRequest, Func<RestResponse, int>>>();

            this.Client = new RestClient(Settings.SERVER_ADR);
            this.unresolvedOutgoing = 0;

            this.requestPipelineThread = new Thread(new ThreadStart(this.RunPipelineCheck));
            this.requestPipelineThread.Start();
        }

        ~PipelineMonitor()
        {
            instance = null;
        }

        public async void RunPipelineCheck()
        {
            //main pipeline thread loop
            while (true)
            {
                Console.WriteLine("Running pipeline ...");

                if (outgoingQueue.Count != 0 || unresolvedOutgoing != 0)
                {
                    var construct = outgoingQueue.Dequeue();
                    var webRequest = construct.Item1;
                    webRequest.AddHeader("client-token", App.launcherClientToken);
                    webRequest.AddHeader("user-agent", "WinInstaller");
                    unresolvedOutgoing++;

                    RestResponse response = null;
                    switch (webRequest.Method)
                    {
                        case Method.Get:
                            response = await Client.ExecuteAsync(webRequest);
                            break;
                        case Method.Post:
                            response = await Client.PostAsync(webRequest);
                            break;
                    }

                    
                    if (response != null)
                    {
                        this.AddIncomming(response, construct.Item2);
                        unresolvedOutgoing--;
                        Console.WriteLine(unresolvedOutgoing + "");
                    }
                }

                if (incommingQueue.Count != 0)
                {
                    var construct = incommingQueue.Dequeue();
                    var response = construct.Item1;
                    Func<RestResponse, int> callback = construct.Item2;

                    callback(response);
                }

                //Delay of 1000 miliseconds (might need more)
                Thread.Sleep(1000);
                if (instance == null)
                {
                    break;
                }
            }
        }

        [EventTarget]
        public bool PostRequest(Event e)
        {
            //do thing yay
            Console.WriteLine("Post shit;");
            return false;
        }

        [EventTarget]
        public bool GetRequest(Event e)
        {
            //do thing yay
            Console.WriteLine("Get shit;");
            return false;
        }

        public void ShutdownPipeline()
        {
            try
            {
                instance = null;
                this.requestPipelineThread.Abort();
            }catch(ThreadStateException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void AddIncomming(RestResponse response, Func<RestResponse, int> callback) {
            this.incommingQueue.Enqueue(Tuple.Create(response, callback));
        }

        public void AddOutgoing(RestRequest restRequest, Func<RestResponse, int> callback)
        {
            this.outgoingQueue.Enqueue(Tuple.Create(restRequest, callback));
        }
    }
}
