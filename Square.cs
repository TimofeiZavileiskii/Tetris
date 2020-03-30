using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Square : Shape
    {
        public Square(int n1, int n2, string[,] s) : base(n1, n2, s)
        {
            string color = RandomColor(0, 80, 0, 80, 180, 255);
            blocks[0, 0] = color;
            blocks[1, 0] = color;
            blocks[0, 1] = color;
            blocks[1, 1] = color;

            maxX = FindMaxX();
            x = new Random().Next(0, width - maxX);
        }

    }
}
