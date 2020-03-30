using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class BridgeShape : Shape
    {
        public BridgeShape(int n1, int n2, string[,] s) : base(n1, n2, s)
        {
            color = RandomColor(0, 70, 0, 70, 0, 70);
            blocks[0, 0] = color;
            blocks[0, 1] = color;
            blocks[0, 2] = color;
            blocks[0, 3] = color;
            blocks[1, 0] = color;
            blocks[2, 0] = color;
            blocks[3, 0] = color;
            blocks[3, 3] = color;
            blocks[3, 2] = color;
            blocks[3, 1] = color;
            blocks[3, 0] = color;

            maxX = FindMaxX();
            x = new Random().Next(0, width - maxX);
        }
        public override void rotation0()
        {
            string[,] newBlocks = new string[,]{
            {color, color, color, color},
            {null, null, null, color},
            {null, null, null, color},
            {color, color, color, color},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation1()
        {
            string[,] newBlocks = new string[,]{
            {color, null, null, color},
            {color, null, null, color},
            {color, null, null, color},
            {color, color, color, color},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation2()
        {
            string[,] newBlocks = new string[,]{
            {color, color, color, color},
            {color, null, null, null},
            {color, null, null, null},
            {color, color, color, color},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation3()
        {
            string[,] newBlocks = new string[,]{
            {color, color, color, color},
            {color, null, null, color},
            {color, null, null, color},
            {color, null, null, color},
            };

            RotateProcess(newBlocks);
        }
    }
}
