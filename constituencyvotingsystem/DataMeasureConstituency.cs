using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class DataMeasureConstituency 
    {
        public int votes;
        public string partyname;

        public DataMeasureConstituency(string Partyname, int Votes)
        {
            this.partyname = Partyname;
            this.votes = Votes;
        }

        public override string ToString()
        {
            return String.Format("{0} - Votes: {1}", partyname, votes);
        }
    }
}
