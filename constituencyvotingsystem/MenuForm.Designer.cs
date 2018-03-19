namespace ConstituencyVotingSystem
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConCan = new System.Windows.Forms.Button();
            this.btnElecCan = new System.Windows.Forms.Button();
            this.btnElecWin = new System.Windows.Forms.Button();
            this.btnPartyVotes = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConCan
            // 
            this.btnConCan.Enabled = false;
            this.btnConCan.Location = new System.Drawing.Point(26, 81);
            this.btnConCan.Name = "btnConCan";
            this.btnConCan.Size = new System.Drawing.Size(121, 94);
            this.btnConCan.TabIndex = 0;
            this.btnConCan.Text = "Constituency Candidates";
            this.btnConCan.UseVisualStyleBackColor = true;
            this.btnConCan.Click += new System.EventHandler(this.btnConCan_Click);
            // 
            // btnElecCan
            // 
            this.btnElecCan.Enabled = false;
            this.btnElecCan.Location = new System.Drawing.Point(177, 81);
            this.btnElecCan.Name = "btnElecCan";
            this.btnElecCan.Size = new System.Drawing.Size(121, 94);
            this.btnElecCan.TabIndex = 1;
            this.btnElecCan.Text = "Elected Candidates";
            this.btnElecCan.UseVisualStyleBackColor = true;
            // 
            // btnElecWin
            // 
            this.btnElecWin.Enabled = false;
            this.btnElecWin.Location = new System.Drawing.Point(177, 202);
            this.btnElecWin.Name = "btnElecWin";
            this.btnElecWin.Size = new System.Drawing.Size(121, 94);
            this.btnElecWin.TabIndex = 3;
            this.btnElecWin.Text = "Total Party Votes";
            this.btnElecWin.UseVisualStyleBackColor = true;
            this.btnElecWin.Click += new System.EventHandler(this.btnElecWin_Click);
            // 
            // btnPartyVotes
            // 
            this.btnPartyVotes.Enabled = false;
            this.btnPartyVotes.Location = new System.Drawing.Point(26, 202);
            this.btnPartyVotes.Name = "btnPartyVotes";
            this.btnPartyVotes.Size = new System.Drawing.Size(121, 94);
            this.btnPartyVotes.TabIndex = 2;
            this.btnPartyVotes.Text = "Election Winner";
            this.btnPartyVotes.UseVisualStyleBackColor = true;
            this.btnPartyVotes.Click += new System.EventHandler(this.btnPartyVotes_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(79, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(174, 37);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Main Menu";
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(496, 81);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(191, 212);
            this.lstResults.TabIndex = 5;
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(496, 27);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(191, 33);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load Cyclist Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(290, 27);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(191, 33);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create Config Data";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(287, 9);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(45, 13);
            this.lblProcess.TabIndex = 8;
            this.lblProcess.Text = "Process";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 325);
            this.Controls.Add(this.btnElecWin);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnPartyVotes);
            this.Controls.Add(this.btnElecCan);
            this.Controls.Add(this.btnConCan);
            this.Name = "MenuForm";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConCan;
        private System.Windows.Forms.Button btnElecCan;
        private System.Windows.Forms.Button btnElecWin;
        private System.Windows.Forms.Button btnPartyVotes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblProcess;
    }
}

