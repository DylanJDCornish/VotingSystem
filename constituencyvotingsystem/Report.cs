using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class Report
    {
         public string RepType { get; set; }
         public List<ConstituencyDataMeasure> TotalVotesDataMeasure { get; set; }

        public Report(String repType)
        {
            this.RepType = repType;
            this.TotalVotesDataMeasure = new List<ConstituencyDataMeasure>();    
        }

        public override String ToString()
        {
            String votes = String.Format("\tVotes: ");

            foreach (var m in TotalVotesDataMeasure)
            {
                votes += String.Format("\n\t\t{0}", m.ToString());
            }

            return String.Format("Constituency Report {0}:\n{1}", RepType, votes);
        }
    }
}
