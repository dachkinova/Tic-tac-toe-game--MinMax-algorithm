using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxTicTacToe
{
    class MinMax
    {
        public const int PLAYER1 = 1;
        public const int PLAYER2 = 2;


        public static Int32 Winner(Int32[,] board)
        {
            var c1 = board[0, 0] & board[1, 0] & board[2, 0];
            var c2 = board[0, 1] & board[1, 1] & board[2, 1];
            var c3 = board[0, 2] & board[1, 2] & board[2, 2];
            var l1 = board[0, 0] & board[0, 1] & board[0, 2];
            var l2 = board[1, 0] & board[1, 1] & board[1, 2];
            var l3 = board[2, 0] & board[2, 1] & board[2, 2];
            var d1 = board[0, 0] & board[1, 1] & board[2, 2];
            var d2 = board[0, 2] & board[1, 1] & board[2, 0];

            return
                c1 == 1 ||
                c2 == 1 ||
                c3 == 1 ||
                l1 == 1 ||
                l2 == 1 ||
                l3 == 1 ||
                d1 == 1 ||
                d2 == 1 ? 1 :
                c1 == 2 ||
                c2 == 2 ||
                c3 == 2 ||
                l1 == 2 ||
                l2 == 2 ||
                l3 == 2 ||
                d1 == 2 ||
                d2 == 2 ? 2 :
                0;
        }

        public static void Grow(
            Node node,
            int player, 
            int maximazer) 
        {
            var winner = Winner(node.Board); 
            
            if (winner != 0)    
            {
                node.Value = winner == maximazer  
                    ? 1                           
                    : -1;
                return;
            }

            for (int i = 0; i < node.Board.GetLength(0); i++)
            {
                for (int k = 0; k < node.Board.GetLength(1); k++)
                {
                    if (node.Board[i, k] == 0) 
                    {
                        var newChild = new Node();
                        newChild.Location = i * 3 + k;
                        Array.Copy(node.Board, newChild.Board, node.Board.Length);

                        int newPlayer = player == PLAYER1 ? PLAYER2 : PLAYER1;

                        newChild.Board[i, k] = newPlayer;             
                        node.Children.Add(newChild);            

                        Grow(                                
                            newChild,
                            newPlayer,
                            maximazer);

                        if (node.Value == null ||                                      
                            (newPlayer == maximazer && node.Value < newChild.Value) ||    
                            (newPlayer != maximazer && node.Value > newChild.Value))
                        {
                            node.Value = newChild.Value;
                        }
                    }
                }
            }
            if (node.Value == null)
            {
                node.Value = 0; 
            }
        }
    }
}
