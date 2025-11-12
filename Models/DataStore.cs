using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunicipalServicesApp.Forms;

namespace MunicipalServicesApp
{
    public static class DataStore
    {
        public static List<ReportedIssue> Requests { get; set; } = new List<ReportedIssue>();
    }
}
