using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class Reports
    {
        public string ReportType { get; set; }
        public List<DataMeasureConstituency> DataMeasureTotalVotes { get; set; }

        public Reports(String reportType)
        {
            this.ReportType = reportType;
            this.DataMeasureTotalVotes = new List<DataMeasureConstituency>();    
        }

        public override string ToString()
        {
            String votes = String.Format("\tVotes: ");

            foreach (var m in DataMeasureTotalVotes)
            {
                votes += String.Format("\n\t\t{0}", m.ToString());
            }

            return String.Format("Constituency Report {0}:\n{1}", ReportType, votes);
        }
    }
}
