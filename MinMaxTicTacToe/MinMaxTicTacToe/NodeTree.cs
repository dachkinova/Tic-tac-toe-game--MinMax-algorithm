using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxTicTacToe
{
    class NodeTree
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;
        }

        /* Helper function that allocates a new node with the   
        given data and NULL left and right pointers. */
        public static Node newNode(int data)
        {
            Node node = new Node();
            node.data = data;
            node.left = null;
            node.right = null;
            return (node);
        }

        // function to find the level   
        // having maximum number of Nodes   
        public static int maxNodeLevel(Node root)
        {
            if (root == null)
            {
                return -1;
            }

            LinkedList<Node> q = new LinkedList<Node>();
            q.AddLast(root);

            // Current level   
            int level = 0;

            // Maximum Nodes at same level   
            int max = int.MinValue;

            // Level having maximum Nodes   
            int level_no = 0;

            while (true)
            {
                // Count Nodes in a level   
                int NodeCount = q.Count;

                if (NodeCount == 0)
                {
                    break;
                }

                // If it is maximum till now   
                // Update level_no to current level   
                if (NodeCount > max)
                {
                    max = NodeCount;
                    level_no = level;
                }

                // Pop complete current level   
                while (NodeCount > 0)
                {
                    Node Node = q.First.Value;
                    q.RemoveFirst();
                    if (Node.left != null)
                    {
                        q.AddLast(Node.left);
                    }
                    if (Node.right != null)
                    {
                        q.AddLast(Node.right);
                    }
                    NodeCount--;
                }

                // Increment for next level   
                level++;
            }

            return level_no;
        }
    }
}
