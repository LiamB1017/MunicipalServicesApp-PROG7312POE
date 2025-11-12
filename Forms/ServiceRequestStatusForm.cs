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
            var lines = tree.InOrder();
            foreach (var line in lines) lstRequests.Items.Add(line);
        }
        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLookupId.Text.Trim(), out int id))
            {
                MessageBox.Show("Enter a numeric Request ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var node = tree.Search(id);
            if (node == null)
            {
                MessageBox.Show($"Request ID {id} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtDetails.Clear();
            var req = node.Payload;
            txtDetails.AppendText($"ID: {node.Key}\r\n");
            txtDetails.AppendText($"Location: {req.LocationText}\r\n");
            txtDetails.AppendText($"Category: {req.Category}\r\n");
            txtDetails.AppendText($"Created: {req.CreatedAt}\r\n");
            txtDetails.AppendText($"Status: {req.CurrentStatus}\r\n");
            txtDetails.AppendText($"Attachments: {string.Join(", ", req.AttachmentPaths ?? new List<string>())}\r\n");

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
            mainMenu.Show();
        }

    }
}

