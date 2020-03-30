using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Board
    {

        private string[,] screen;
        public int width;
        public int height;
        public int score;
        public int difficulty;
        private int maxRange;
        private int minRange;

        public Shape flyingShape;
        private Random rn;

        public Board()
        {
            width = 10;
            height = 20;
            score = 0;
            difficulty = 1;
            screen = new string[height, width];
            rn = new Random();
        }

        public Shape GetFlyingShape()
        {
            return flyingShape;
        }
        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetScore()
        {
            return score;
        }

        public void ChangeDifficulty(int n)
        {
            difficulty = n;
        }

        public string[,] getScreen()
        {
            return screen;
        }

        public void ChangeRange(int minN, int maxN)
        {
            minRange = minN;
            maxRange = maxN;
        }

        public bool newShape()
        {
            // Creates randomly chosen shape
            int randomInt = rn.Next(minRange, maxRange);

            if(randomInt < 15)
            {
                flyingShape = new Square(height, width, screen);
            }
            else if(randomInt < 30)
            {
                flyingShape = new Line(height, width, screen);
            }
            else if(randomInt < 45)
            {
                flyingShape = new LShape(height, width, screen);
            }
            else if (randomInt  < 60)
            {
                flyingShape = new ReversedLShape(height, width, screen);
            }
            else if (randomInt < 75)
            {
                flyingShape = new SShape(height, width, screen);
            }
            else if(randomInt < 90)
            {
                flyingShape = new ReversedSShape(height, width, screen);
            }
            else if(randomInt < 105)
            {
                flyingShape = new TShape(height, width, screen);
            }
            else if (randomInt < 110)
            {
                flyingShape = new BridgeShape(height, width, screen);
            }
            else if(randomInt < 120)
            {
                flyingShape = new StairShape(height, width, screen);
            }
            else if(randomInt < 130)
            {
                flyingShape = new ChestShape(height, width, screen);
            }
            else if(randomInt < 155)
            {
                flyingShape = new BirdShape(height, width, screen);
            }
            else if(randomInt < 165)
            {
                flyingShape = new CrossShape(height, width, screen);
            }
            else if(randomInt < 175)
            {
                flyingShape = new LongLShape(height, width, screen);
            }


            //Rotates the created shape for random amount of times
            randomInt = rn.Next(0, 4);
            for(int i = 0; i < randomInt; i++)
            {
                flyingShape.Rotate();
            }

            if (CheckForCollision())
            {
                return false;
            }
            return true;
        }

        public bool CheckForCollision()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int ii = 0; ii < 4; ii++)
                {
                    try
                    {
                        if ((flyingShape.blocks[i, ii] != null && screen[flyingShape.y - i, ii + flyingShape.x] != null)
                            || (flyingShape.blocks[i, ii] != null && flyingShape.y - i == 0))
                        {
                            return true;
                        }
                    }
                    catch(IndexOutOfRangeException)
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        public bool Update()
        {
            flyingShape.y--;
            if(CheckForCollision() || flyingShape.y == 0)
            {
                flyingShape.y++;

                //When the shape lands on something its blocks are added to the screen array
                for (int i = 0; i < 4; i++)
                {
                    for (int ii = 0; ii < 4; ii++)
                    {
                        if (flyingShape.blocks[i, ii] != null)
                        {
                            screen[flyingShape.y - i, flyingShape.x + ii] = flyingShape.blocks[i, ii];
                        }
                        //Checks if a row is fully filled
                        CheckForRows();
                    }
                }
                return newShape();
            }
            return true;
        }


        private void CheckForRows()
        {
            //Checks and removes all empty rows -----------------------

            List<int> removedRows = new List<int>();
            bool filled = true;
            for (int i = 0; i < height; i++)
            {
                filled = true;
                for (int ii = 0; ii < width; ii++)
                {
                    if (screen[i, ii] == null)
                    {
                        filled = false;
                        break;
                    }
                }
                if (filled)
                {
                    removedRows.Add(i);
                    for(int ii = 0; ii < width; ii++)
                    {
                        screen[i, ii] = null;
                    }
                }
            }

            //Then all rows above the removed rows are brought down ------

            foreach(int i in removedRows)
            {
                for(int ii = i; ii < height; ii++)
                {
                    for(int iii = 0; iii < width; iii++)
                    {
                        if(ii < height - 1)
                        {
                            screen[ii, iii] = screen[ii + 1, iii];
                        }
                    }
                }
            }

            AddScore(removedRows.Count());
        }

        public void ResetScreen()
        {
            screen = new string[height, width];
        }
        private void AddScore(int removedRows)
        {
            int addition = 5;
            for(int i = 0; i < removedRows; i++)
            {
                score += difficulty * addition;
                addition++;
            }
        }

        public void movement(bool right)
        {
            if (right)
            {
                flyingShape.x++;
                if (CheckForCollision() || flyingShape.x == width)
                {
                    flyingShape.x--;
                }
            }
            else
            {
                flyingShape.x--;
                if (CheckForCollision() || flyingShape.x == -1)
                {
                    flyingShape.x++;
                }
            }
        }


    }
}
