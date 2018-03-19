using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConstituencyVotingSystem
{
    public class Consumer
    {
        private static int threadsRunning = 0;
        private static object locker = new object();
        private const int duration = 100;
        private string id;
        public Thread T { get; private set; }
        private bool complete;
        private IWorkQueue workQueue;
        private ConstituencyList constitlist;

        private ProgManager progMan;

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
        public Consumer(string id, IWorkQueue WorkQueue, ConstituencyList constitlist, ProgManager progManager)
        {
            this.id = id;
            complete = false;
            this.workQueue = WorkQueue;
            this.constitlist = constitlist;
            this.progMan = progManager;
            (T = new Thread(run)).Start();
            ThreadsRunning++;
        }

        public void run()
        {
            while (!Complete)
            {
                var item = workQueue.dequeueItem();

                if (!ReferenceEquals(null, item))
                {
                    Constituency constituency = item.ProcessData();
                    if (!ReferenceEquals(null, constituency))
                    {
                        lock (constitlist)
                        {
                            constitlist.constituencyList.Add(constituency);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Consumer:{0} has rejected Work Item:{1}", id, item.recordConfig.ToString());
                    }
                    Thread.Sleep(duration);
                    progMan.ItemsLeft--;
                }
            }
            ThreadsRunning--;
        }
    }
}