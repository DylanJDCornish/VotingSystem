using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ConstituencyVotingSystem
{
    public partial class MainMenu : Form, IUserInterface

    {
        public MainMenu()
        {
            InitializeComponent();
        }
        public IFileReader IOhandler { get; set; }
        private DataConfig dataConfig;
        public ConstituencyList constituencylist;

        private String selectedReportType;

        public MainMenu(IFileReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
        }

        private void FormsBasedUI_Load(object sender, EventArgs e)
        {
        }

        public void SetupConfigData()
        {
            dataConfig = new DataConfig();
            dataConfig.recConfig.Add(new RecordConfig("Constituency-01.xml"));
            dataConfig.recConfig.Add(new RecordConfig("Constituency-02.xml"));
            dataConfig.recConfig.Add(new RecordConfig("Constituency-03.xml"));
            dataConfig.recConfig.Add(new RecordConfig("Constituency-04.xml"));
            dataConfig.recConfig.Add(new RecordConfig("Constituency-05.xml"));
        }

        public void RunProducerConsumer()
        {
            constituencylist = new ConstituencyList();

            ProgManager progMan = new ProgManager(dataConfig.recConfig.Count);

            lblProcess.Text = "Creating and starting all producers and consumers";

            var workQueue = new WorkQueue(4);

            Producer[] producers = { new Producer("P1", workQueue, dataConfig, IOhandler),
                                     new Producer("P2", workQueue, dataConfig, IOhandler) };

            Consumer[] consumers = { new Consumer("C1", workQueue, constituencylist, progMan),
                                     new Consumer("C2", workQueue, constituencylist, progMan) };

            while (progMan.ItemsLeft > 0) ;

            lblProcess.Text = "Shutting down all producers and consumers";

            workQueue.Active = false;

            foreach (var p in producers)
            {
                p.Complete = true;
            }

            foreach (var c in consumers)
            {
                c.Complete = true;
            }

            for (int i = 0; i < (Producer.ThreadsRunning + Consumer.ThreadsRunning); i++)
            {
                lock (workQueue)
                {
                    Monitor.Pulse(workQueue);
                    Thread.Sleep(100);
                }
            }

            while ((Producer.ThreadsRunning > 0) || (Consumer.ThreadsRunning > 0)) ;
            lblProcess.Text = "All producers and consumers shut down";
        }

        public void DisplayResults()
        {
            lstResults.Items.Clear();

            constituencylist.datarep(selectedReportType);

            foreach (var constit in constituencylist.datarep(selectedReportType))
            {
                lstResults.Items.Add(constit);
            }

            lblProcess.Text = String.Format("({0} Report)", selectedReportType);
        }

        private void btnConCan_Click(object sender, EventArgs e)
        {

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            SetupConfigData();
            btnLoad.Enabled = true;
            btnCreate.Enabled = false;
            lblProcess.Text = "Config data loaded. Waiting for user to press load";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            lblProcess.Text = "Obtaining Constituency data. Please wait";
            lblProcess.Refresh();
            RunProducerConsumer();
            btnConCan.Enabled = true;
            btnElecCan.Enabled = true;
            btnLoad.Enabled = false;
            btnPartyVotes.Enabled = true;
            btnCreate.Enabled = false;
            btnElecWin.Enabled = true;
            lblProcess.Text = "Constituency data loaded";

        }

        private void btnElecWin_Click(object sender, EventArgs e)
        {
            ElectionWinner ew = new ElectionWinner();
            ew.ShowDialog(); // Shows electionwinner form
            selectedReportType = "TotalResults";
            DisplayResults();
        }

        private void btnPartyVotes_Click(object sender, EventArgs e)
        {
            selectedReportType = "OverallWinner";
            DisplayResults();
        }
    }
}
