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

        public void Insert(int key, ServiceRequestNode payload)
        {
            Root = InsertInternal(Root, key, payload);
        }

        private ServiceRequestNode InsertInternal(ServiceRequestNode root, int key, ServiceRequestNode payload)
        {
            // 1. Perform normal BST insertion
            if (root == null)
                return payload;

            if (key < root.Key)
                root.Left = InsertInternal(root.Left, key, payload);
            else if (key > root.Key)
                root.Right = InsertInternal(root.Right, key, payload);
            else
            {
                // Duplicate key: update payload
                root.Payload = payload.Payload;
                return root;
            }

            // 2. Update height
            root.Height = 1 + Math.Max(Height(root.Left), Height(root.Right));

            // 3. Get balance factor
            int balance = GetBalance(root);

            // 4. Balance the tree
            // Left Left Case
            if (balance > 1 && key < root.Left.Key)
                return RightRotate(root);

            // Right Right Case
            if (balance < -1 && key > root.Right.Key)
                return LeftRotate(root);

            // Left Right Case
            if (balance > 1 && key > root.Left.Key)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            // Right Left Case
            if (balance < -1 && key < root.Right.Key)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }


        private ServiceRequestNode InsertInternal(ServiceRequestNode node, int key, ServiceRequestTree payload)
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

        internal void Insert(int id, ReportedIssue req)
        {
            var node = new ServiceRequestNode(id, req);
            Root = InsertInternal(Root, id, node);
        }

    }
}
