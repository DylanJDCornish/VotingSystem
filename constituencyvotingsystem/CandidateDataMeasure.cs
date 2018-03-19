using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class CandidateDataMeasure
    {
        public string forename;
        public string surname;
        public int votes;
        public string partyname;

        public CandidateDataMeasure(string Forename, string Surname, string Partyname, int Votes)
        {
            this.forename = Forename;
            this.surname = Surname;
            this.partyname = Partyname;
            this.votes = Votes;
        }

        public override string ToString()
        {
            return String.Format("{0} - Votes: {1}", partyname, votes);
        }
    }
}
