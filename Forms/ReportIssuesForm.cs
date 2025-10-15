using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm: Form
    {
        public ReportIssuesForm()
        {
            InitializeComponent();
        }
        private MainMenuForm mainMenuForm;

        public ReportIssuesForm(MainMenuForm mainMenuForm)
        {
            InitializeComponent();
            this.mainMenuForm = mainMenuForm;
        }


        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lblAttachment.Text = ofd.FileName;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string location = txtLocation.Text;
            string category = cmbCategory.SelectedItem?.ToString();
            string description = rtbDescription.Text;
            string attachment = lblAttachment.Text;

            if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save to in-memory list (later can go to database)
            IssueStorage.ReportedIssues.Add(new ReportedIssue
            {
                Location = location,
                Category = category,
                Description = description,
                Attachment = attachment
            });

            lblEngagement.Text = "Thank you for reporting! Your input helps us improve services.";
            MessageBox.Show("Issue submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Show the main menu form
            this.Hide();
            mainMenuForm.Show();
        }

        private void labellocation_Click(object sender, EventArgs e)
        {

        }

        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
