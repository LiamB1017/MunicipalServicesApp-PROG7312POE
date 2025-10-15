using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    public partial class LocalEventsForm : Form
    {
        private SortedDictionary<DateTime, List<Event>> eventSchedule;
        private Queue<string> recentSearches;
        private HashSet<string> uniqueCategories;

        // Store reference to the main menu
        private MainMenuForm mainMenuForm;

        // Constructor that accepts the main menu
        public LocalEventsForm(MainMenuForm menuForm)
        {
            InitializeComponent();
            mainMenuForm = menuForm;

            eventSchedule = new SortedDictionary<DateTime, List<Event>>();
            recentSearches = new Queue<string>();
            uniqueCategories = new HashSet<string>();

            LoadSampleEvents();
            PopulateEventsList();
        }

        private void LoadSampleEvents()
        {
            var sampleEvents = new List<Event>
            {
                new Event("Community Clean-Up", "Community", new DateTime(2025, 10, 18), "Join us for a neighbourhood clean-up."),
                new Event("Local Soccer Match", "Sports", new DateTime(2025, 10, 21), "Support your local soccer team!"),
                new Event("Cultural Festival", "Culture", new DateTime(2025, 10, 25), "Experience local music and art."),
                new Event("Health Awareness Talk", "Health", new DateTime(2025, 10, 28), "Free medical check-ups and talks."),
                new Event("Coding for Beginners", "Education", new DateTime(2025, 11, 2), "Learn the basics of programming.")
            };

            foreach (var ev in sampleEvents)
            {
                if (!eventSchedule.ContainsKey(ev.Date))
                    eventSchedule[ev.Date] = new List<Event>();

                eventSchedule[ev.Date].Add(ev);
                uniqueCategories.Add(ev.Category);
            }

            // Populate category dropdown
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("");
            foreach (var category in uniqueCategories)
                cmbCategory.Items.Add(category);
        }

        private void PopulateEventsList()
        {
            lstEvents.Items.Clear();

            foreach (var kvp in eventSchedule)
            {
                foreach (var ev in kvp.Value)
                {
                    lstEvents.Items.Add(ev.ToString());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string category = cmbCategory.Text.Trim().ToLower();

            lstEvents.Items.Clear();

            if (!string.IsNullOrEmpty(keyword))
            {
                recentSearches.Enqueue(keyword);
                if (recentSearches.Count > 5) recentSearches.Dequeue();
            }

            var results = eventSchedule
                .SelectMany(kvp => kvp.Value)
                .Where(ev =>
                    (string.IsNullOrEmpty(keyword) ||
                     ev.Title.ToLower().Contains(keyword) ||
                     ev.Description.ToLower().Contains(keyword))
                    && (string.IsNullOrEmpty(category) ||
                        ev.Category.ToLower() == category))
                .ToList();

            if (results.Count == 0)
            {
                lstEvents.Items.Add("No events found.");
            }
            else
            {
                foreach (var ev in results)
                {
                    lstEvents.Items.Add(ev.ToString());
                }
            }
        }


        private void btnRecommend_Click(object sender, EventArgs e)
        {
            lstRecommendations.Items.Clear();

            if (recentSearches.Count == 0)
            {
                lstRecommendations.Items.Add("No recent searches yet.");
                return;
            }

            // Get the most frequent search keyword
            var mostCommonSearch = recentSearches
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .First();

            var recommendations = eventSchedule
                .SelectMany(kvp => kvp.Value)
                .Where(ev => ev.Title.ToLower().Contains(mostCommonSearch) ||
                             ev.Description.ToLower().Contains(mostCommonSearch) ||
                             ev.Category.ToLower().Contains(mostCommonSearch))
                .Take(5)
                .ToList();

            if (recommendations.Count == 0)
            {
                lstRecommendations.Items.Add("No recommendations found for your recent searches.");
            }
            else
            {
                lstRecommendations.Items.Add($"Recommended based on your searches for '{mostCommonSearch}':");
                foreach (var ev in recommendations)
                {
                    lstRecommendations.Items.Add(ev.ToString());
                }
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            // Show the main menu form
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();

            // Close the current form
            this.Close();
        }
    }
}