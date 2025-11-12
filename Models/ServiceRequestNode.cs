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
        public Request Payload { get; set; }
        public ServiceRequestNode Left { get; set; }
        public ServiceRequestNode Right { get; set; }
        public int Height { get; set; }

        public ServiceRequestNode(int key, Request payload)
        {
            Key = key;
            Payload = payload;
            Left = null;
            Right = null;
            Height = 1; 
        }
        public override string ToString()
        {
            return $"{Key}: {Payload?.Location} - {Payload?.CurrentStatus} ({Payload?.CreatedAt})";
        }
    }
}
