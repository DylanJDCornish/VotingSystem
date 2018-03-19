using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class ConstitiuencyList
    {
        public List<Constituency> constituencyList { get; set; }

        public ConstitiuencyList()
        {
            constituencyList = new List<Constituency>();
        }

        public List<DataMeasureConstituency> datareports(String reportType)
        {

            List<DataMeasureConstituency> asymMeasures = new List<DataMeasureConstituency>();

            switch (reportType)
            {
                case "TotalResults":
                    var asymList = from constituency in constituencyList
                                   from measures in constituency.PartyWinnerReport.DataMeasureTotalVotes
                                   group measures by measures.partyname into measure
                                   select measure;

                    foreach (var measure in asymList)
                    {
                        asymMeasures.Add(new DataMeasureConstituency(measure.Key, (from m in measure select m.votes).Sum()));
                    }

                    return asymMeasures;

                case "OverallWinner":
                    List<DataMeasureConstituency> allConstituencies = new List<DataMeasureConstituency>();
                    List<DataMeasureConstituency> winner = new List<DataMeasureConstituency>();

                    var allConstits = from constituency in constituencyList
                                   from measures in constituency.PartyWinnerReport.DataMeasureTotalVotes
                                   group measures by measures.partyname into measure
                                   select measure;

                    foreach (var measure in allConstits)
                    {
                        allConstituencies.Add(new DataMeasureConstituency(measure.Key, (from m in measure select m.votes).Sum()));
                    }

                    foreach(var consit in allConstituencies)
                    {
                        if (!winner.Any())
                        {
                            winner.Add(consit);
                        }

                        if (consit.votes > winner[0].votes)
                        {
                            winner.Clear();
                            winner.Add(consit);
                        }
                    }

                    return winner;

                default:
                    return null;
          }
       }
    }
}
