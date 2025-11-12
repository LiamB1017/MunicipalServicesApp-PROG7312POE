using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public class ServiceRequestNode
    {
        public int Key { get; set; }
        public ReportedIssue Payload { get; set; }
        public ServiceRequestNode Left { get; set; }
        public ServiceRequestNode Right { get; set; }
        public int Height { get; set; }
        public object Location { get; private set; }
        public object CurrentStatus { get; private set; }
        public object CreatedAt { get; private set; }
        public object Category { get; internal set; }
        public object LocationText { get; internal set; }
        public List<string> AttachmentPaths { get; internal set; }

        public ServiceRequestNode(int key, ReportedIssue payload)
        {
            Key = key;
            Payload = payload;
            Left = null;
            Right = null;
            Height = 1;
        }

        public ServiceRequestNode(int key, ServiceRequestTree payload)
        {
            Key = key;
        }

    }
}