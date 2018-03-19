using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
   public class ConstituencyDataMeasure
    {
        public int votes;
        public String partyname;

        public ConstituencyDataMeasure(String Partyname, int Votes)
        {
            this.partyname = Partyname;
            this.votes = Votes;
        }

        public override String ToString()
        {
            return String.Format("{0} - Votes: {1}", partyname, votes);
        }
    }
}
