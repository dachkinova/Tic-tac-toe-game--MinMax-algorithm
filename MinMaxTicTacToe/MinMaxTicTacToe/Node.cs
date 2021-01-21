using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxTicTacToe
{
    public class Node
    {
        public List<Node> Children { get; set; } = new List<Node>();


        public int[,] Board { get; set; } = new int[3, 3];


        public int? Value { get; set; }


        public int? Location { get; set; }
    }
}
