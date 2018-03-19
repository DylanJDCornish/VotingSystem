using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class Work
    {
        public RecordConfig recordConfig { get; private set; }
        private IFileReader IOHandler;
        public Constituency constituency { get; private set; }

        public Work(RecordConfig recordconfig, IFileReader IOHandler)
        {
            constituency = null;
            this.recordConfig = recordconfig;
            this.IOHandler = IOHandler;
        }

        public Constituency ProcessData()
        {
            return IOHandler.ReadDataFromFile(recordConfig);
        }
    }
}
