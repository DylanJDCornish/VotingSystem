using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class RecordConfig
    {
        public string file { get; private set; }

        public RecordConfig(String File)
        {
            this.file = File;
        }

        public override string ToString()
        {
            return string.Format("{0}", file);
        }
    }
}
