using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinMaxTicTacToe
{
    class DrawTree
    {
        public void DrawGameTree(Node node, int Width, int Height, PaintEventArgs e)
        {
            List<Node> currentNodes = new List<Node>();
            List<List<Node>> listChildrenLayers = new List<List<Node>>();

            currentNodes.Add(node);
            listChildrenLayers.Add(currentNodes);
            int level = 0;
            int maxLevel = node.Children.Count;

            nodeTree(currentNodes, 0, listChildrenLayers, maxLevel);

            //get sectors by height
            int maxSectorsY = 0;
            for (int i = 0; i < listChildrenLayers.Count; i++)
            {
                if (listChildrenLayers[i].Count > maxSectorsY)
                {
                    maxSectorsY = listChildrenLayers[i].Count;
                }
            }

            int sizeOfNode = Height / maxSectorsY / 2;

            //get sectors by width
            int sectorsX = 1;
            //count every empty space in board
            for (int i = 0; i < node.Board.GetLength(0); i++)
            {
                for (int k = 0; k < node.Board.GetLength(1); k++)
                {
                    if (node.Board[i, k] == 0)
                        sectorsX++;
                }
            }

            //Draw tree//

            int pointX;
            int pointY;

            for (int i = 0; i < sectorsX; i++)
            {

                int sectorsY = listChildrenLayers[i].Count;
                List<Node> forPainting = new List<Node>();
                forPainting = listChildrenLayers.ElementAt(i);

                //calculate point x
                pointX = (i * Width / sectorsX) + ((Width / sectorsX - sizeOfNode) / 2);

                for (int k = 0; k < sectorsY; k++)
                {
                    Node nodeP = new Node();
                    nodeP = forPainting.ElementAt(k);

                    pointY = (k * Height / sectorsY) + ((Height / sectorsY - sizeOfNode) / 2);


                    Pen mainPen = new Pen(Color.Black, 2);
                    Pen winPen = new Pen(Color.Green, 2);
                    Pen losePen = new Pen(Color.Red, 2);

                    
                    //draw node values//
                    String nodeValue = nodeP.Value.ToString();
                    

                    Font drawFont = new Font("Arial", 14);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    StringFormat drawFormat = new StringFormat();

                    e.Graphics.DrawString(nodeValue, drawFont, drawBrush, pointX + sizeOfNode / 3, pointY + sizeOfNode / 3, drawFormat);
                    
                    nodeBranches(e, nodeP, listChildrenLayers, Width, Height, sizeOfNode);

                    //paint nodes//
                    if (nodeP.Value == 1 && nodeP.Children.Count == 0)
                    {
                        e.Graphics.DrawEllipse(winPen, pointX, pointY, sizeOfNode, sizeOfNode);
                    }
                    else if (nodeP.Value == -1 && nodeP.Children.Count == 0)
                    {
                        e.Graphics.DrawEllipse(losePen, pointX, pointY, sizeOfNode, sizeOfNode);
                    }
                    else 
                    { 
                        e.Graphics.DrawEllipse(mainPen, pointX, pointY, sizeOfNode, sizeOfNode);
                    }
                }
            }
        }

        public void nodeBranches(PaintEventArgs e, Node node, 
            List<List<Node>> listChildrenLayers, int Width, int Height, int size)
        {
            Pen p = new Pen(Color.Black, 2);
            p.EndCap = LineCap.ArrowAnchor;

            for (int i = 0; i < listChildrenLayers.Count; i++)
            {
                List<Node> currentNodes = new List<Node>();
                currentNodes = listChildrenLayers.ElementAt(i);

                List<Node> childrenNodes = new List<Node>();
                if (i + 1 < listChildrenLayers.Count)
                {
                    childrenNodes = listChildrenLayers.ElementAt(i + 1);
                }

                int startPointX;
                int startPointY;

                for (int m = 0; m < currentNodes.Count; m++)
                {
                    startPointX = (i * Width / listChildrenLayers.Count) + 
                        ((Width / listChildrenLayers.Count + size) / 2);

                    startPointY = (m * Height / currentNodes.Count) +
                        ((Height / currentNodes.Count) / 2);

                    for (int n = 0; n < childrenNodes.Count; n++)
                    {
                        int endPointX = ((i+1) * Width / listChildrenLayers.Count) +
                        ((Width / listChildrenLayers.Count - size) / 2);

                        int endPointY = (n * Height / childrenNodes.Count) +
                        ((Height / childrenNodes.Count) / 2);


                        if (currentNodes.ElementAt(m).Children.Contains(childrenNodes.ElementAt(n)))
                        {
                            e.Graphics.DrawLine(p, startPointX, startPointY, endPointX, endPointY);
                        }
                    }
                }
            }
            
            p.Dispose();
        }


        public void nodeTree(List<Node> childNode, int level, List<List<Node>> listChildrenLayers, int max)
        {
            List<Node> currentChildrens = new List<Node>();
           
            while (level < max) { 

                for (int i = 0; i < childNode.Count; i++)
                {
                    for (int k = 0; k < childNode[i].Children.Count; k++)
                    {
                        currentChildrens.Add(childNode[i].Children[k]);
                    }
                }
                listChildrenLayers.Add(currentChildrens);

                nodeTree(currentChildrens, level + 1, listChildrenLayers, max);
                
                level = max;
            }
            
        }

       




    }
}
