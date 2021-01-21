using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinMaxTicTacToe
{
    class DrawNodeTree
    {
        private Panel outputPanel = null;
        private bool sizeToFit = true;

        private BinaryTree tree = new BinaryTree();

        public Node Left { get; set; }
        public Node Right { get; set; }

        //public void Add(int value)
        //{
        //    Node node = new Node();

        //    if (value < node.Value)// add to left
        //    {
        //        if (Left == null)
        //            Left = new Node(value);
        //        else
        //            Left.Add(value, node);
        //        IsChanged = true;
        //    }
        //    else if (value > nodeValue) // add to right
        //    {
        //        IsChanged = true;
        //        if (Right == null)
        //            Right = new Node(value);
        //        else
        //            Right.Add(value);
        //    }
        //}

        public void DrawTree(int[,] board, int width, int height)
        {

        }

    }

}
