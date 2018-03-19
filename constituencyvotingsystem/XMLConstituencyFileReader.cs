using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ConstituencyVotingSystem
{
   public class XMLConstituencyFileReader : IFileReader
    {
        public Constituency ReadDataFromFile(RecordConfig configRecord)
        {
            if (!File.Exists(configRecord.file))
            {
                return null;
            }

            XDocument xmlDoc = XDocument.Load(configRecord.file);
            var constituencyName = (from c in xmlDoc.Descendants("Constituency")
                                    select c.Attribute("name").Value).First();

            Constituency constit = new Constituency(constituencyName);

            constit.ReportPartyWin = new Report("OverallWinner");
            constit.ReportPartyWin.TotalVotesDataMeasure = SelectDataMeasuresConstituency(xmlDoc, constit.ConstituencyName);

            return constit;
        }

        private List<ConstituencyDataMeasure> SelectDataMeasuresConstituency(XDocument xmlDoc, String constitName)
        {
            var measures = from constit in xmlDoc.Root.Descendants("Constituency")
                           from measure in constit.Descendants("Candidate")
                           where constit.Attribute("name").Value == constitName
                           select new ConstituencyDataMeasure(measure.Attribute("party").Value, Convert.ToInt32(measure.Element("Votes").Value));

            return measures.ToList();
        }

        /*
        private List<DataMeasureConstituency> SelectDataMeasuresCandidate(XDocument xmlDoc)
        {
            var measures = from constit in xmlDoc.Root.Descendants("Constituency")
                           from measure in constit.Descendants("Candidate")
                           select new DataMeasureCandidate(measure.Attribute("forename").Value, measure.Attribute("surname").Value, measure.Attribute("party").Value, Convert.ToInt32(measure.Element("Votes").Value));

            return measures.ToList();
        }
        */
    }  
}
