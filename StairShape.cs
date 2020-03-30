using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class StairShape : Shape
    {
        public StairShape(int n1, int n2, string[,] s) : base(n1, n2, s)
        {
            color = RandomColor(180, 255, 180, 255, 180, 255);
            blocks[0, 0] = color;
            blocks[1, 0] = color;
            blocks[2, 0] = color;
            blocks[1, 1] = color;
            blocks[2, 1] = color;
            blocks[2, 2] = color;

            maxX = FindMaxX();
            x = new Random().Next(0, width - maxX);
        }
        public override void rotation0()
        {
            string[,] newBlocks = new string[,]{
            {color, color, color, null},
            {color, color, null, null},
            {color, null, null, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation1()
        {
            string[,] newBlocks = new string[,]{
            {color, color, color, null},
            {null, color, color, null},
            {null, null, color, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation2()
        {
            string[,] newBlocks = new string[,]{
            {null, null, color, null},
            {null, color, color, null},
            {color, color, color, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation3()
        {
            string[,] newBlocks = new string[,]{
            {color, null, null, null},
            {color, color, null, null},
            {color, color, color, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }
    }
}
