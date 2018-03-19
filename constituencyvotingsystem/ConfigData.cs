using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class ConfigData
    {
        public List<ConfigRecord> configRec { get; set; }
        public int nextRec { get; set;}

        public ConfigData()
        {
            this.nextRec = 0;
            configRec = new List<ConfigRecord>();
        }
    }
}
