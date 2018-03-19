using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
   public interface IUserInterface
    {
        void SetupConfigData();
        void RunProducerConsumer();
        void DisplayResults();
    }
}
