using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Shape
    {
        public string[,] blocks;

        protected string[,] screen;
        protected int height;
        protected int width;
        protected string color;
        protected int rotation;
        public int x;
        public int y;
        public int maxX;

        public Shape(int height, int width, string[,] board)
        {
            blocks = new string[4, 4];
            rotation = 0;
            y = height - 1;
            screen = board;
            this.height = height;
            this.width = width;
        }

        protected string RandomColor(int minRed, int maxRed, int minGreen, int maxGreen, int minBlue, int maxBlue)
        {
            Random rn = new Random();
            int red = rn.Next(minRed, maxRed);
            int green = rn.Next(minGreen, maxGreen);
            int blue = rn.Next(minBlue, maxBlue);

            string redStr = red.ToString();
            redStr = new string('0',3 - redStr.Length) + red;
            string greenStr = green.ToString();
            greenStr = new string('0', 3 - greenStr.Length) + greenStr;
            string blueStr = blue.ToString();
            blueStr = new string('0', 3 - blueStr.Length) + blueStr;


            return redStr + greenStr + blueStr;
        }

        protected void RotateProcess(string[,] newBlocks)
        {
            //check that the shape will be in bounds
            bool inBounds = true;
            
            for(int i = 0; i < 4; i++)
            {
                for(int ii = 0; ii < 4; ii++)
                {
                    try
                    {
                        if ((newBlocks[i, ii] != null && x + ii > width - 1) || (newBlocks[i, ii] != null && screen[y - i, ii + x] != null))
                        {
                            inBounds = false;
                            break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        inBounds = false;
                    }
                }
            }
            
            
            if (inBounds)
            {
                rotation++;
                blocks = newBlocks;
            }
        }

        protected int FindMaxX()
        {
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int ii = 0; ii < 4; ii++)
                {
                    if (blocks[i, ii] != null && x < ii)
                    {
                        x = ii;
                    }
                }
            }

            return x;
        }

        public int FindMinX()
        {
            int x = 4;
            for (int i = 0; i < 4; i++)
            {
                for (int ii = 0; ii < 4; ii++)
                {
                    if (blocks[i, ii] != null && x > ii)
                    {
                        x = ii;
                    }
                }
            }

            return x;
        }

        public void Rotate()
        {
            int module = rotation % 4;
            switch (module)
            {
                case 0:
                    rotation0();
                    break;
                case 1:
                    rotation1();
                    break;
                case 2:
                    rotation2();
                    break;
                case 3:
                    rotation3();
                    break;
            }
        }

        public virtual void rotation0()
        {

        }

        public virtual void rotation1()
        {

        }

        public virtual void rotation2()
        {

        }

        public virtual void rotation3()
        {

        }

    }
}
