using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConstituencyVotingSystem
{
    public class Producer
    {
        private static int threadsRunning = 0;
        private static object locker = new object();
        private const int duration = 100;

        private string id;
        public Thread T { get; private set; }
        private bool complete;
        private IWorkQueue workQueue;
        private DataConfig fileConfig;
        private IFileReader IOhandler;

        public static int ThreadsRunning
        {
            get
            {
                return threadsRunning;
            }

            private set
            {
                lock (locker)
                {
                    threadsRunning = value;
                }
            }
        }

        public bool Complete
        {
            get
            {
                return complete;
            }
            set
            {
                lock (this)
                {
                    complete = value;
                }
            }
        }

        public Producer(string id, IWorkQueue WorkQueue, DataConfig configFile, IFileReader IOhandler)
        {
            this.id = id;
            complete = false;
            this.workQueue = WorkQueue;
            this.configFile = configFile;
            this.IOhandler = IOhandler;
            (T = new Thread(run)).Start();
            ThreadsRunning++;
        }

        public void run()
        {
            RecordConfig recordConfig = null;

            while (!Complete)
            {
                lock (fileConfig)
                {
                    if (fileConfig.nextRecord < fileConfig.recConfig.Count)
                    {
                        recordConfig = fileConfig.recConfig[fileConfig.nextRecord++];
                    }
                    else
                    {
                        recordConfig = null;
                    }
                }

                if (recordConfig != null)
                {
                    workQueue.enqueueItem(new Work(recordConfig, IOhandler));
                    Console.WriteLine("Producer:{0} has created and enqueued Work Item:{1}", id, recordConfig.ToString());
                }

                Thread.Sleep(duration);
            }

            ThreadsRunning--;
        }

        public DataConfig configFile { get; set; }
    }
}
