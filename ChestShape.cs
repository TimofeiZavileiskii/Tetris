using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class ChestShape : Shape
    {
        public ChestShape(int n1, int n2, string[,] s) : base(n1, n2, s)
        {
            color = RandomColor(0, 80, 180, 255, 0, 80);
            blocks[0, 0] = color;
            blocks[0, 1] = color;
            blocks[0, 2] = color;
            blocks[1, 0] = color;
            blocks[2, 0] = color;
            blocks[2, 1] = color;
            blocks[2, 2] = color;
            blocks[1, 2] = color;

            maxX = FindMaxX();
            x = new Random().Next(0, width - maxX);
        }

        void Rotate1()
        {
            string[,] newBlocks = new string[,]{
            {color, color, color, null},
            {color, null, color, null},
            {color, color, color, null},
            {null, null, null, null},
            };

            RotateProcess(newBlocks);
        }
        public override void rotation0()
        {
            Rotate1();
        }

        public override void rotation1()
        {
            Rotate1();
        }

        public override void rotation2()
        {
            Rotate1();
        }

        public override void rotation3()
        {
            Rotate1();
        }
    }
}
