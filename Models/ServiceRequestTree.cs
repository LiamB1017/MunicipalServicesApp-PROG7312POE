using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public class ServiceRequestTree
    {
        public ServiceRequestNode Root { get; set; }

        private int Height(ServiceRequestNode node) => node?.Height ?? 0;

        private ServiceRequestNode RightRotate(ServiceRequestNode y)
        {
            var x = y.Left;
            var T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private ServiceRequestNode LeftRotate(ServiceRequestNode x)
        {
            var y = x.Right;
            var T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }
        private int GetBalance(ServiceRequestNode node) => node == null ? 0 : Height(node.Left) - Height(node.Right);

        public void Insert(int key, Request payload)
        {
            Root = InsertInternal(Root, key, payload);
        }
        private ServiceRequestNode InsertInternal(ServiceRequestNode node, int key, Request payload)
        {
            if (node == null)
                return new ServiceRequestNode(key, payload);

            if (key < node.Key)
                node.Left = InsertInternal(node.Left, key, payload);
            else if (key > node.Key)
                node.Right = InsertInternal(node.Right, key, payload);
            else
            {
                // duplicate keys — update payload
                node.Payload = payload;
                return node;
            }

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = GetBalance(node);

            // Left Left
            if (balance > 1 && key < node.Left.Key)
                return RightRotate(node);

            // Right Right
            if (balance < -1 && key > node.Right.Key)
                return LeftRotate(node);

            // Left Right
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        // Search by key
        public ServiceRequestNode Search(int key)
        {
            var cur = Root;
            while (cur != null)
            {
                if (key == cur.Key) return cur;
                cur = key < cur.Key ? cur.Left : cur.Right;
            }
            return null;
        }

        // In-order traversal (sorted by key) - returns lines for display
        public List<string> InOrder()
        {
            var list = new List<string>();
            InOrderInternal(Root, list);
            return list;
        }

        private void InOrderInternal(ServiceRequestNode node, List<string> acc)
        {
            if (node == null) return;
            InOrderInternal(node.Left, acc);
            acc.Add(node.ToString());
            InOrderInternal(node.Right, acc);
        }

        // Preorder and Postorder available if needed
        public List<string> PreOrder()
        {
            var list = new List<string>();
            PreOrderInternal(Root, list);
            return list;
        }
        private void PreOrderInternal(ServiceRequestNode node, List<string> acc)
        {
            if (node == null) return;
            acc.Add(node.ToString());
            PreOrderInternal(node.Left, acc);
            PreOrderInternal(node.Right, acc);
        }
    }
}
