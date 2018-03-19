using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class DataConfig
    {
        public List<RecordConfig> recConfig { get; set; }
        public int nextRecord { get; set; }

        public DataConfig()
        {
            this.nextRecord = 0;
            recConfig = new List<RecordConfig>();
        }
    }
}
