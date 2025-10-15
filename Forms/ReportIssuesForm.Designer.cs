namespace MunicipalServicesApp
{
    partial class ReportIssuesForm
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
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.labellocation = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.Category = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblEngagement = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(112, 24);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(301, 20);
            this.txtLocation.TabIndex = 0;
            // 
            // labellocation
            // 
            this.labellocation.AutoSize = true;
            this.labellocation.Location = new System.Drawing.Point(38, 27);
            this.labellocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labellocation.Name = "labellocation";
            this.labellocation.Size = new System.Drawing.Size(54, 15);
            this.labellocation.TabIndex = 1;
            this.labellocation.Text = "Location";
            this.labellocation.Click += new System.EventHandler(this.labellocation_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Sanitation",
            "Roads",
            "Utilities"});
            this.cmbCategory.Location = new System.Drawing.Point(112, 57);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(151, 21);
            this.cmbCategory.TabIndex = 2;
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(38, 59);
            this.Category.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(55, 15);
            this.Category.TabIndex = 3;
            this.Category.Text = "Category";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(38, 98);
            this.Description.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(69, 15);
            this.Description.TabIndex = 4;
            this.Description.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(112, 93);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(301, 98);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Location = new System.Drawing.Point(112, 207);
            this.btnAttachFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(75, 28);
            this.btnAttachFile.TabIndex = 6;
            this.btnAttachFile.Text = "Attach File";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(38, 211);
            this.lblAttachment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(91, 15);
            this.lblAttachment.TabIndex = 7;
            this.lblAttachment.Text = "No file selected";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(112, 252);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 28);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblEngagement
            // 
            this.lblEngagement.AutoSize = true;
            this.lblEngagement.Location = new System.Drawing.Point(110, 293);
            this.lblEngagement.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEngagement.Name = "lblEngagement";
            this.lblEngagement.Size = new System.Drawing.Size(116, 15);
            this.lblEngagement.TabIndex = 9;
            this.lblEngagement.Text = "We value your input!";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(376, 303);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 28);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ReportIssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 341);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblEngagement);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.labellocation);
            this.Controls.Add(this.txtLocation);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReportIssuesForm";
            this.Text = "ReportIssuesForm";
            this.Load += new System.EventHandler(this.ReportIssuesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label labellocation;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblEngagement;
        private System.Windows.Forms.Button btnBack;
    }
}

