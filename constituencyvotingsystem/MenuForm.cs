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
    public partial class MenuForm : Form, IUserInterface

    {
        public MenuForm()
        {
            InitializeComponent();
        }
        public IFileReader IOhandler { get; set; }
        private ConfigData configData;
        public ConstitiuencyList constituencylist;

        private String selectedReportType;

        public MenuForm(IFileReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
        }

        private void FormsBasedUI_Load(object sender, EventArgs e)
        {
        }

        public void SetupConfigData()
        {
            configData = new ConfigData();
            configData.configRec.Add(new ConfigRecord("Constituency-01.xml"));
            configData.configRec.Add(new ConfigRecord("Constituency-02.xml"));
            configData.configRec.Add(new ConfigRecord("Constituency-03.xml"));
            configData.configRec.Add(new ConfigRecord("Constituency-04.xml"));
            configData.configRec.Add(new ConfigRecord("Constituency-05.xml"));
        }

        public void RunProducerConsumer()
        {
            constituencylist = new ConstitiuencyList();

            ProgressManager progMan = new ProgressManager(configData.configRec.Count);

            lblProcess.Text = "Creating and starting all producers and consumers";

            var workQueue = new WorkQueue(4);

            Producer[] producers = { new Producer("P1", workQueue, configData, IOhandler),
                                     new Producer("P2", workQueue, configData, IOhandler) };

            Consumer[] consumers = { new Consumer("C1", workQueue, constituencylist, progMan),
                                     new Consumer("C2", workQueue, constituencylist, progMan) };

            while (progMan.ItemsLeft > 0);

            lblProcess.Text = "Shutting down all producers and consumers";

            workQueue.Active = false;

            foreach (var p in producers)
            {
                p.Finished = true;
            }

            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            for (int i = 0; i < (Producer.RunningThreads + Consumer.RunningThreads); i++)
            {
                lock (workQueue)
                {
                    Monitor.Pulse(workQueue);
                    Thread.Sleep(100);
                }
            }

            while ((Producer.RunningThreads > 0) || (Consumer.RunningThreads > 0)); 
            lblProcess.Text = "All producers and consumers shut down";
        }

        public void DisplayResults()
        {
            lstResults.Items.Clear();

            constituencylist.datareports(selectedReportType);

            foreach (var constit in constituencylist.datareports(selectedReportType))
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
            lblProcess.Text = "Obtaining cyclist data. Please wait";
            lblProcess.Refresh();
            RunProducerConsumer();
            btnConCan.Enabled = true;
            btnElecCan.Enabled = true;
            btnLoad.Enabled = false;
            btnPartyVotes.Enabled = true;
            btnCreate.Enabled = false;
            btnElecWin.Enabled = true;
            lblProcess.Text = "Cyclist data loaded";

        }

        private void btnElecWin_Click(object sender, EventArgs e)
        {
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
