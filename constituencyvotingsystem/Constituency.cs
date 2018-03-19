using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class Constituency
    {
        public string ConstituencyName { get; set; }
        public Report ReportPartyWin { get; set; }

        public Constituency(string constituencyID)
        {
            this.ConstituencyName = constituencyID;
            this.ReportPartyWin = null;
        }

        public override string ToString()
        {
            return ConstituencyName;
        }

    }
}
