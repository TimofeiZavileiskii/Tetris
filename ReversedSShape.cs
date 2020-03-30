using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class ReversedSShape : Shape
    {
        public ReversedSShape(int n1, int n2, string[,] s) : base(n1, n2, s)
        {
            color = RandomColor(0, 80, 180, 255, 180, 255);
            blocks[0, 1] = color;
            blocks[1, 1] = color;
            blocks[1, 0] = color;
            blocks[2, 0] = color;

            maxX = FindMaxX();
            x = new Random().Next(0, width - maxX);
        }

        private void rotate1()
        {
            string[,] newBlocks = new string[,]{
            {color, color, null, null},
            {null, color, color, null},
            {null, null, null, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        private void rotate2()
        {
            string[,] newBlocks = new string[,]{
            {null, color, null, null},
            {color, color, null, null},
            {color, null, null, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }

        public override void rotation0()
        {
            rotate1();
        }

        public override void rotation1()
        {
            rotate2();
        }

        public override void rotation2()
        {
            rotate1();
        }

        public override void rotation3()
        {
            rotate2();
        }

    }
}
