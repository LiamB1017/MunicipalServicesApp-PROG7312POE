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
            string location = txtLocation.Text.Trim();
            string category = cmbCategory.Text.Trim();
            string description = rtbDescription.Text.Trim();
            string filePath = btnAttachFile.Text.Trim();

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            ReportedIssue issue = new ReportedIssue(location, category, description, filePath);
            DataStore.Requests.Add(issue);

            MessageBox.Show($"Issue submitted successfully!\nYour Request ID is: {issue.RequestID}");
            
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
