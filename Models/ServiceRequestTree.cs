using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public class ServiceRequestTree
    {
        private ServiceRequestNode root;

        public void Insert(int key, ReportedIssue data)
        {
            root = InsertRec(root, key, data);
        }

        private ServiceRequestNode InsertRec(ServiceRequestNode node, int key, ReportedIssue data)
        {
            if (node == null)
                return new ServiceRequestNode(key, data);

            if (key < node.Key)
                node.Left = InsertRec(node.Left, key, data);
            else if (key > node.Key)
                node.Right = InsertRec(node.Right, key, data);

            return node;
        }

        public ServiceRequestNode Search(int key)
        {
            return SearchRec(root, key);
        }

        private ServiceRequestNode SearchRec(ServiceRequestNode node, int key)
        {
            if (node == null || node.Key == key)
                return node;

            if (key < node.Key)
                return SearchRec(node.Left, key);
            else
                return SearchRec(node.Right, key);
        }

        public List<string> InOrder()
        {
            var list = new List<string>();
            InOrderRec(root, list);
            return list;
        }

        private void InOrderRec(ServiceRequestNode node, List<string> list)
        {
            if (node == null) return;
            InOrderRec(node.Left, list);
            list.Add(node.Payload?.ToString() ?? $"[{node.Key}] (No Data)");
            InOrderRec(node.Right, list);
        }
    }
}
