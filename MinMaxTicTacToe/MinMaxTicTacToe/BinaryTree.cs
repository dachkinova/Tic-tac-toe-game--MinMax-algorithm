using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinMaxTicTacToe
{
    public partial class BinaryTree : Form
    {
        public BinaryTree()
        {
            InitializeComponent();
        }

        private void BinaryTree_Load(object sender, EventArgs e)
        {
             
        }

        private void BinaryTree_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
        
        private void BinaryTreePanel_Paint(object sender, PaintEventArgs e)
        {
            int formHeight = 600;
            int formWidth = 800;
           
            //int[,] nodeBoard = Form1.arrayBoard();
            //node.Board = nodeBoard;
            //MinMax.Grow(Form1.currentNode, MinMax.PLAYER1, MinMax.PLAYER1);
            DrawTree drawTree = new DrawTree();

            drawTree.DrawGameTree(Form1.currentNode, formWidth, formHeight, e);
        }
    }
}
