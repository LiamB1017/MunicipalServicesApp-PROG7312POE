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
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public int RequestID { get; internal set; }
    }

}

public static class IssueStorage
{
    public static List<ReportedIssue> ReportedIssues = new List<ReportedIssue>();
}
