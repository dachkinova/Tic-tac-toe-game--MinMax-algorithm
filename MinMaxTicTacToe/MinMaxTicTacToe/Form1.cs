using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MinMax;

namespace MinMaxTicTacToe
{
    public partial class Form1 : Form
    {

        public static string[,] boardString = new string[3, 3]; 

        public bool isEndGame { get; set; }

        public static Node currentNode { get; set; } 
        
        public int turnCount { get; set; }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryTree bt = new BinaryTree();
            bt.ShowDialog();
        }

        private void button_click(object sender, EventArgs e)
        {
            if (!isEndGame)
            {
                Button b = (Button)sender;

                b.Text = "X";

                b.Enabled = false;
                turnCount++;

                boardString[0, 0] = B1.Text;
                boardString[0, 1] = B2.Text;
                boardString[0, 2] = B3.Text;
                boardString[1, 0] = B4.Text;
                boardString[1, 1] = B5.Text;
                boardString[1, 2] = B6.Text;
                boardString[2, 0] = B7.Text;
                boardString[2, 1] = B8.Text;
                boardString[2, 2] = B9.Text;

               // var root = new Node();

                Node node = new Node();
                int[,] nodeBoard = arrayBoard();
                node.Board = nodeBoard;

                int currentPlayer = MinMax.PLAYER1;

                currentNode = node;
                MinMax.Grow(node, currentPlayer, currentPlayer);

                gameStatus();

                if (!isEndGame)
                {
                    Node minNode = node.Children[0];

                    foreach (var child in node.Children)
                    {
                        if (minNode.Value > child.Value)
                        {
                            minNode = child;
                        }
                    }
                    currentNode = minNode;

                    if (minNode.Location == 0)
                    {
                        B1.Text = "O";
                        B1.Enabled = false;
                        boardString[0, 0] = B1.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 1)
                    {
                        B2.Text = "O";
                        B2.Enabled = false;
                        boardString[0, 1] = B2.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 2)
                    {
                        B3.Text = "O";
                        B3.Enabled = false;
                        boardString[0, 2] = B3.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 3)
                    {
                        B4.Text = "O";
                        B4.Enabled = false;
                        boardString[1, 0] = B4.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 4)
                    {
                        B5.Text = "O";
                        B5.Enabled = false;
                        boardString[1, 1] = B5.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 5)
                    {
                        B6.Text = "O";
                        B6.Enabled = false;
                        boardString[1, 2] = B6.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 6)
                    {
                        B7.Text = "O";
                        B7.Enabled = false;
                        boardString[2, 0] = B7.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 7)
                    {
                        B8.Text = "O";
                        B8.Enabled = false;
                        boardString[2, 1] = B8.Text;
                        turnCount++;
                    }
                    else if (minNode.Location == 8)
                    {
                        B9.Text = "O";
                        B9.Enabled = false;
                        boardString[2, 2] = B9.Text;
                        turnCount++;
                    }
                    gameStatus();
                }
            }
        }

        public static int[,] arrayBoard()
        {
            int[,] board = new int[3, 3];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int k = 0; k < board.GetLength(1); k++)
                {
                    if (boardString[i, k] == "X")
                    {
                        board[i, k] = 1;
                    }
                    else if (boardString[i, k] == "O")
                    {
                        board[i, k] = 2;
                    }
                    else
                    {
                        board[i, k] = 0;
                    }
                }
            }
            return board;
        }

        private void gameStatus()
        {
            
            string winner = "";

            int statusValue = MinMax.Winner(arrayBoard());

            if (statusValue != 0)
            {
                if (statusValue == 1)
                {
                    winner = "X";
                    x_count.Text = (Int32.Parse(x_count.Text) + 1).ToString();
                    isEndGame = true;
                    Color color = Color.Green;
                    highlightWinnerButtons(boardString, statusValue, color);
                }
                else if (statusValue == 2)
                {
                    winner = "O";
                    o_count.Text = (Int32.Parse(o_count.Text) + 1).ToString();
                    isEndGame = true;
                    Color color = Color.Red;
                    highlightWinnerButtons(boardString, statusValue, color);
                }

                MessageBox.Show(winner + " wins!", "Message");
                disableButtons();
            }

            if (turnCount == 9)
            {
                highlightDrawButtons();
                MessageBox.Show("Draw!", "Message");
                draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                isEndGame = true;
                
            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = c as Button;
                    if (b != null)
                    {
                        b.Enabled = false;
                    }
                }
            }
            catch
            {

            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnCount = 0;
            isEndGame = false;

            foreach (Control c in Controls)
            {

                Button b = c as Button;

                if (b != null)
                {
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            for (int i = 0; i < boardString.GetLength(0); i++)
            {
                for (int k = 0; k < boardString.GetLength(1); k++)
                {
                    boardString[i, k] = "";
                }
            }
            B1.BackColor = Color.Transparent;
            B2.BackColor = Color.Transparent;
            B3.BackColor = Color.Transparent;
            B4.BackColor = Color.Transparent;
            B5.BackColor = Color.Transparent;
            B6.BackColor = Color.Transparent;
            B7.BackColor = Color.Transparent;
            B8.BackColor = Color.Transparent;
            B9.BackColor = Color.Transparent;

        }

        private void resetResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                o_count.Text = "0";
                x_count.Text = "0";
                draw_count.Text = "0";
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            groupAction();
        }

        private void binaryTreeButton_Click(object sender, EventArgs e)
        {
            groupAction();
        }

        public void groupAction()
        {
            if (turnCount > 3 && turnCount < 9 && turnCount != 0)
            {
                BinaryTree bt = new BinaryTree();
                bt.ShowDialog();
            }
            else
            {
                MessageBox.Show("The tree can't be shown at that state of the game.");
            }
        }

        public void highlightWinnerButtons(string[,] board, int statusValue, Color color)
        {
            boardString[0, 0] = B1.Text;
            boardString[0, 1] = B2.Text;
            boardString[0, 2] = B3.Text;
            boardString[1, 0] = B4.Text;
            boardString[1, 1] = B5.Text;
            boardString[1, 2] = B6.Text;
            boardString[2, 0] = B7.Text;
            boardString[2, 1] = B8.Text;
            boardString[2, 2] = B9.Text;

            
            if (statusValue == 1 || statusValue == 2)
            {
                if (boardString[0, 0] == boardString[1, 0] &
                boardString[1, 0] == boardString[2, 0] && (!B1.Enabled))
                {
                    B1.BackColor = color;
                    B4.BackColor = color;
                    B7.BackColor = color;
                }
                if (boardString[0, 1] == boardString[1, 1] &
                    boardString[1, 1] == boardString[2, 1] && (!B2.Enabled))
                {
                    B2.BackColor = color;
                    B5.BackColor = color;
                    B8.BackColor = color;
                }
                if (boardString[0, 2] == boardString[1, 2] &
                    boardString[1, 2] == boardString[2, 2] && (!B3.Enabled))
                {
                    B3.BackColor = color;
                    B6.BackColor = color;
                    B9.BackColor = color;
                }
                if (boardString[0, 0] == boardString[0, 1] &
                    boardString[0, 1] == boardString[0, 2] && (!B1.Enabled))
                {
                    B1.BackColor = color;
                    B2.BackColor = color;
                    B3.BackColor = color;
                }
                if (boardString[1, 0] == boardString[1, 1] &
                    boardString[1, 1] == boardString[1, 2] && (!B4.Enabled))
                {
                    B4.BackColor = color;
                    B5.BackColor = color;
                    B6.BackColor = color;
                }
                if (boardString[2, 0] == boardString[2, 1] &
                    boardString[2, 1] == boardString[2, 2] && (!B7.Enabled))
                {
                    B7.BackColor = color;
                    B8.BackColor = color;
                    B9.BackColor = color;
                }
                if (boardString[0, 0] == boardString[0, 1] &
                    boardString[0, 1] == boardString[0, 2] && (!B1.Enabled))
                {
                    B1.BackColor = color;
                    B2.BackColor = color;
                    B3.BackColor = color;
                }
                if (boardString[0, 0] == boardString[1, 1] &
                    boardString[1, 1] == boardString[2, 2] && (!B1.Enabled))
                {
                    B1.BackColor = color;
                    B5.BackColor = color;
                    B9.BackColor = color;
                }
                if (boardString[0, 2] == boardString[1, 1] &
                    boardString[1, 1] == boardString[2, 0] && (!B3.Enabled))
                {
                    B3.BackColor = color;
                    B5.BackColor = color;
                    B7.BackColor = color;
                }
            }
        }

        public void highlightDrawButtons()
        {
            B1.BackColor = Color.SkyBlue;
            B2.BackColor = Color.SkyBlue;
            B3.BackColor = Color.SkyBlue;
            B4.BackColor = Color.SkyBlue;
            B5.BackColor = Color.SkyBlue;
            B6.BackColor = Color.SkyBlue;
            B7.BackColor = Color.SkyBlue;
            B8.BackColor = Color.SkyBlue;
            B9.BackColor = Color.SkyBlue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Angelina Dachkinova, TU-Sofia, ISS", "Info");
        }
    }
}
