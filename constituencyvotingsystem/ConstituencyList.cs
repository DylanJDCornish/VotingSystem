using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstituencyVotingSystem
{
    public class ConstituencyList
    {
        public List<Constituency> constituencyList { get; set; }

        public ConstituencyList()
        {
            constituencyList = new List<Constituency>();
        }

        public List<ConstituencyDataMeasure> datarep(String repType)
        {

            List<ConstituencyDataMeasure> conMeasures = new List<ConstituencyDataMeasure>();

          switch (repType)
            {
                case "TotalResults":
                    var conList = from constituency in constituencyList
                                   from measures in constituency.ReportPartyWin.TotalVotesDataMeasure
                                   group measures by measures.partyname into measure
                                   select measure;

                    foreach (var measure in conList)
                    {
                        conMeasures.Add(new ConstituencyDataMeasure(measure.Key, (from m in measure select m.votes).Sum()));
                    }

                    return conMeasures;

                case "OverallWinner":
                    List<ConstituencyDataMeasure> allConstituencies = new List<ConstituencyDataMeasure>();
                    List<ConstituencyDataMeasure> winner = new List<ConstituencyDataMeasure>();

                    var allConstits = from constituency in constituencyList
                                      from measures in constituency.ReportPartyWin.TotalVotesDataMeasure
                                      group measures by measures.partyname into measure
                                      select measure;

                    foreach (var measure in allConstits)
                    {
                        allConstituencies.Add(new ConstituencyDataMeasure(measure.Key, (from m in measure select m.votes).Sum()));
                    }

                    foreach (var consit in allConstituencies)
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
