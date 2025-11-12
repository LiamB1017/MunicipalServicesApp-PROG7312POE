using MunicipalServicesApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class ReportedIssue
    {
        private static int counter = 1;

        public int RequestID { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public string Attachment { get; internal set; }

        public ReportedIssue(string location, string category, string description, string filePath)
        {
            RequestID = counter++;
            Location = location;
            Category = category;
            Description = description;
            FilePath = filePath;
            Status = "Pending";
        }

        public override string ToString()
        {
            return $"[{RequestID}] {Category} - {Description} ({Status})";
        }
    }
}
