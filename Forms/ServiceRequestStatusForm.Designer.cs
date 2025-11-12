namespace MunicipalServicesApp.Forms
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstRequests;
        private System.Windows.Forms.TextBox txtLookupId;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.TextBox txtStartNode;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button btnDFS;
        private System.Windows.Forms.Button btnMST;
        private System.Windows.Forms.ListBox lstGraphOut;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lstRequests = new System.Windows.Forms.ListBox();
            this.txtLookupId = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.txtStartNode = new System.Windows.Forms.TextBox();
            this.btnBFS = new System.Windows.Forms.Button();
            this.btnDFS = new System.Windows.Forms.Button();
            this.btnMST = new System.Windows.Forms.Button();
            this.lstGraphOut = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRequests
            // 
            this.lstRequests.FormattingEnabled = true;
            this.lstRequests.ItemHeight = 16;
            this.lstRequests.Location = new System.Drawing.Point(16, 16);
            this.lstRequests.Name = "lstRequests";
            this.lstRequests.Size = new System.Drawing.Size(420, 196);
            // 
            // txtLookupId
            // 
            this.txtLookupId.Location = new System.Drawing.Point(460, 20);
            this.txtLookupId.Name = "txtLookupId";
            this.txtLookupId.Size = new System.Drawing.Size(120, 22);
            this.txtLookupId.Text = "Request ID";
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(600, 18);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(100, 26);
            this.btnLookup.Text = "Lookup";
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(460, 60);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.Size = new System.Drawing.Size(420, 152);
            // 
            // txtStartNode
            // 
            this.txtStartNode.Location = new System.Drawing.Point(16, 230);
            this.txtStartNode.Name = "txtStartNode";
            this.txtStartNode.Size = new System.Drawing.Size(120, 22);
            this.txtStartNode.Text = "Start Node ID";
            // 
            // btnBFS
            // 
            this.btnBFS.Location = new System.Drawing.Point(150, 228);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(80, 26);
            this.btnBFS.Text = "BFS";
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // btnDFS
            // 
            this.btnDFS.Location = new System.Drawing.Point(240, 228);
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(80, 26);
            this.btnDFS.Text = "DFS";
            this.btnDFS.Click += new System.EventHandler(this.btnDFS_Click);
            // 
            // btnMST
            // 
            this.btnMST.Location = new System.Drawing.Point(340, 228);
            this.btnMST.Name = "btnMST";
            this.btnMST.Size = new System.Drawing.Size(96, 26);
            this.btnMST.Text = "Compute MST";
            this.btnMST.Click += new System.EventHandler(this.btnMST_Click);
            // 
            // lstGraphOut
            // 
            this.lstGraphOut.FormattingEnabled = true;
            this.lstGraphOut.ItemHeight = 16;
            this.lstGraphOut.Location = new System.Drawing.Point(16, 270);
            this.lstGraphOut.Name = "lstGraphOut";
            this.lstGraphOut.Size = new System.Drawing.Size(420, 180);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(720, 430);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 28);
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ServiceRequestStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.lstRequests);
            this.Controls.Add(this.txtLookupId);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.txtStartNode);
            this.Controls.Add(this.btnBFS);
            this.Controls.Add(this.btnDFS);
            this.Controls.Add(this.btnMST);
            this.Controls.Add(this.lstGraphOut);
            this.Controls.Add(this.btnBack);
            this.Text = "Service Request Status";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
