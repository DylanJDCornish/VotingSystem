using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public interface IWorkQueue 
    {
        void enqueueItem(Work item);
        Work dequeueItem();
    }
}
