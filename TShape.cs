using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TShape : Shape
    {
        public TShape(int n1, int n2, string[,] s) : base(n1, n2, s)
        {
            color = RandomColor(0, 70, 0, 70, 0, 70);
            blocks[1, 0] = color;
            blocks[1, 1] = color;
            blocks[1, 2] = color;
            blocks[0, 1] = color;

            maxX = FindMaxX();
            x = new Random().Next(0, width - maxX);
        }
        public override void rotation0()
        {
            string[,] newBlocks = new string[,]{
            {null, color, null, null},
            {null, color, color, null},
            {null, color, null, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation1()
        {
            string[,] newBlocks = new string[,]{
            {null, null, null, null},
            {color, color, color, null},
            {null, color, null, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation2()
        {
            string[,] newBlocks = new string[,]{
            {null, color, null, null},
            {color, color, null, null},
            {null, color, null, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation3()
        {
            string[,] newBlocks = new string[,]{
            {null, color, null, null},
            {color, color, color, null},
            {null, null, null, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

    }
}
