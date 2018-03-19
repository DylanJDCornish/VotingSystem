using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class ConfigRecord
    {
        public string filename { get; private set; }

        public ConfigRecord(String Filename)
        {
            this.filename = Filename;
        }

        public override string ToString()
        {
            return string.Format("{0}", filename);
        }
    }
}
