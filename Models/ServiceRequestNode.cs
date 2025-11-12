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
        public ServiceRequestNode Payload { get; set; }
        public ServiceRequestNode Left { get; set; }
        public ServiceRequestNode Right { get; set; }
        public int Height { get; set; }
        public object Location { get; private set; }
        public object CurrentStatus { get; private set; }
        public object CreatedAt { get; private set; }
        public object Category { get; internal set; }
        public object LocationText { get; internal set; }
        public List<string> AttachmentPaths { get; internal set; }

        public ServiceRequestNode(int key, ServiceRequestNode payload)
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

        public ServiceRequestNode(int id, ReportedIssue req)
        {
            Key = id;
            Payload = null; // Leaf nodes do not need a payload reference
            Location = req.Location;
            LocationText = req.Location; // Or use a formatted string if needed
            Category = req.Category;
            CreatedAt = DateTime.Now; // Or use a property from req if available
            CurrentStatus = "Reported"; // Or use a property from req if available
            AttachmentPaths = string.IsNullOrEmpty(req.Attachment) ? new List<string>() : new List<string> { req.Attachment };
            Left = null;
            Right = null;
            Height = 1;
        }

        public override string ToString()
        {
            return $"{Key}: {Payload?.Location} - {Payload?.CurrentStatus} ({Payload?.CreatedAt})";
        }

        public static implicit operator ServiceRequestNode(ServiceRequestTree v)
        {
            throw new NotImplementedException();
        }
    }
}
