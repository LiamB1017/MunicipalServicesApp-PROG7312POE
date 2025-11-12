using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Forms
{
    public partial class ServiceRequestStatusForm : Form
    {
        private ServiceRequestTree tree;
        private Graph graph;
        private MainMenuForm mainMenuForm;

        public ServiceRequestStatusForm(MainMenuForm menu)
        {
            InitializeComponent();
            mainMenuForm = menu;
            tree = new ServiceRequestTree();
            graph = new Graph();

            LoadRequestsIntoStructures();
            RefreshRequestsView();
        }

        private void LoadRequestsIntoStructures()
        {
            foreach (var req in DataStore.Requests)
            {
                int id = req.RequestID;
                tree.Insert(id, req);

                graph.AddNode(id);
            }

            var ids = DataStore.Requests.Select(r => r.RequestID).OrderBy(x => x).ToList();
            for (int i = 0; i + 1 < ids.Count; i++)
            {
                int a = ids[i], b = ids[i + 1];
                double w = Math.Abs(a - b);
                graph.AddEdge(a, b, w);
            }
        }
        private void RefreshRequestsView()
        {
            lstRequests.Items.Clear();

            if (DataStore.Requests == null || DataStore.Requests.Count == 0)
            {
                lstRequests.Items.Add("No service requests found.");
                return;
            }

            lstRequests.Items.Add("Loaded Service Requests:");
            lstRequests.Items.Add(""); // blank line

            foreach (var req in DataStore.Requests)
            {
                lstRequests.Items.Add($"[{req.RequestID}] {req.Category} - {req.Location} ({req.Status})");
            }
        }
        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLookupId.Text.Trim(), out int id))
            {
                MessageBox.Show("Enter a numeric Request ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var node = tree.Search(id); // Ensure 'node' is declared before usage
            if (node == null)
            {
                MessageBox.Show($"Request ID {id} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var req = node.Payload; // Correctly use 'node' after declaration
            if (req == null)
            {
                MessageBox.Show($"Request ID {id} has no associated data.", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtDetails.Clear();
            txtDetails.AppendText("🧾 SERVICE REQUEST DETAILS\r\n");
            txtDetails.AppendText("----------------------------------------\r\n");
            txtDetails.AppendText($"Request ID: {node.Key}\r\n");
            txtDetails.AppendText($"Location: {req.Location}\r\n");
            txtDetails.AppendText($"Category: {req.Category}\r\n");
            txtDetails.AppendText($"Description: {req.Description}\r\n");
            txtDetails.AppendText($"Status: {req.Status}\r\n");
            txtDetails.AppendText($"Attachment: {(string.IsNullOrEmpty(req.FilePath) ? "None" : req.FilePath)}\r\n");
            txtDetails.AppendText("----------------------------------------\r\n");
            txtDetails.AppendText("✅ Lookup successful!\r\n");

        }
        private void btnMST_Click(object sender, EventArgs e)
        {
            lstGraphOut.Items.Clear();
            var mst = graph.PrimMST();
            if (mst.Count == 0) lstGraphOut.Items.Add("MST: graph too small or no edges.");
            else
            {
                lstGraphOut.Items.Add("MST Edges (from -> to : weight):");
                foreach (var (a, b, w) in mst) lstGraphOut.Items.Add($"{a} -> {b} : {w}");
            }
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            lstGraphOut.Items.Clear();
            if (!int.TryParse(txtStartNode.Text.Trim(), out int start)) { MessageBox.Show("Enter start node id"); return; }
            var order = graph.BFS(start);
            if (order.Count == 0) lstGraphOut.Items.Add("No nodes reachable or start node invalid.");
            else
            {
                lstGraphOut.Items.Add("BFS order:");
                lstGraphOut.Items.Add(string.Join(", ", order));
            }
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            lstGraphOut.Items.Clear();
            if (!int.TryParse(txtStartNode.Text.Trim(), out int start)) { MessageBox.Show("Enter start node id"); return; }
            var order = graph.DFS(start);
            if (order.Count == 0) lstGraphOut.Items.Add("No nodes reachable or start node invalid.");
            else
            {
                lstGraphOut.Items.Add("DFS order:");
                lstGraphOut.Items.Add(string.Join(", ", order));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenuForm.Show(); 
        }

    }
}

