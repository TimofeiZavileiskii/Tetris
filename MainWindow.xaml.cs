using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board board;
        DispatcherTimer timer;
        bool gameGoing;
        int difficulty;
        double ratio;
        
        public MainWindow()
        {
            InitializeComponent();
            difficulty = 1;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            gameGoing = false;
            ratio = 20 / 11;
            board = new Board();
            timer.Tick += Update;

        }

        private void Input(object sender, KeyEventArgs e)
        {
            if (gameGoing)
            {
                if (e.Key == Key.Right)
                {
                    if (board.flyingShape.x < board.width - board.flyingShape.maxX)
                    {
                        board.flyingShape.x++;
                        if (board.CheckForCollision())
                        {
                            board.flyingShape.x--;
                        }
                        else
                        {
                            DrawFrame();
                        }

                    }
                }
                else if (e.Key == Key.Left)
                {
                    if (board.flyingShape.x != 0 - board.flyingShape.FindMinX())
                    {
                        board.flyingShape.x--;
                        if (board.CheckForCollision())
                        {
                            board.flyingShape.x++;
                        }
                        else
                        {
                            DrawFrame();
                        }
                    }
                }
                else if (e.Key == Key.Down)
                {
                    timer.Stop();
                    timer.Start();
                    GameStep();
                }
                else if (e.Key == Key.R)
                {
                    board.flyingShape.Rotate();
                    DrawFrame();
                }
            }
        }


        private void Start(object sender, EventArgs e)
        {
            if (!gameGoing)
            {
                board.ResetScreen();
                board.ChangeDifficulty(difficulty);
                board.newShape();
                board.score = 0;
                Score.Text = "Score: 0";
                timer.Start();
                gameGoing = true;
                canvas.Children.Clear();
                Label.Visibility = Visibility.Collapsed;
                
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            if (gameGoing)
            {
                timer.Stop();
                gameGoing = false;
                Label.Visibility = Visibility.Visible;
                Label.Text = "Choose Difficulty";
                Label.Foreground = Brushes.Black;
            }
        }    
        private void Easy(object sender, EventArgs e)
        {
            if (!gameGoing)
            {
                board.ChangeRange(0, 105);
                timer.Interval = TimeSpan.FromMilliseconds(1500);
                Label.Text = "Easy";
                Label.Foreground = Brushes.Green;
                difficulty = 1;
            }
        }

        private void Medium(object sender, EventArgs e)
        {
            if (!gameGoing)
            {
                board.ChangeRange(0, 105);
                timer.Interval = TimeSpan.FromMilliseconds(800);
                Label.Text = "Medium";
                Label.Foreground = Brushes.Yellow;
                difficulty = 2;
            }
        }

        private void Hard(object sender, EventArgs e)
        {
            if (!gameGoing)
            {
                board.ChangeRange(0, 105);
                timer.Interval = TimeSpan.FromMilliseconds(400);
                Label.Text = "Hard";
                Label.Foreground = Brushes.Red;
                difficulty = 3;
            }
        }

        private void Crazy(object sender, EventArgs e)
        {
            if (!gameGoing)
            {
                board.ChangeRange(105, 165);
                timer.Interval = TimeSpan.FromMilliseconds(500);
                Label.Text = "Crazy";
                Label.Foreground = Brushes.Purple;
                difficulty = 10;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            GameStep();
        }

        private void GameStep()
        {
            if (gameGoing)
            {
                if (!board.Update())
                {
                    Label.Text = "You Lost!";
                    Label.Foreground = Brushes.Crimson;
                    Label.Visibility = Visibility.Visible;
                    
                    timer.Stop();
                    gameGoing = false;
                }
                DrawFrame();
                Score.Text = "Score: " + board.score.ToString();
            }
        }

        private void DrawFrame()
        {
            double widthOfBlock = canvas.ActualWidth / board.width;
            double heightOfBlock = canvas.ActualHeight / board.height;
            canvas.Children.Clear();

            //Drawing of the lying rectangles on the screen
            for (int i = 0; i < board.height; i++)
            {
                for (int ii = 0; ii < board.width; ii++)
                {
                    if (board.getScreen()[i, ii] != null)
                    {
                        DrawRectangle(i, ii, widthOfBlock, heightOfBlock, board.getScreen()[i, ii]);
                    }
                }
            }

            //Drawing of the falling shape on the screen
            for (int i = 0; i < 4; i++)
            {
                for (int ii = 0; ii < 4; ii++)
                {
                    if (board.flyingShape.blocks[i, ii] != null)
                    {
                        DrawRectangle(board.flyingShape.y - i, board.flyingShape.x + ii,
                            widthOfBlock, heightOfBlock, board.flyingShape.blocks[i, ii]);
                    }
                }
            }
        }

        private void DrawRectangle(int y, int x, double width, double height, string color)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;

            SolidColorBrush brush = new SolidColorBrush(
                Color.FromRgb(
                (byte)Convert.ToInt32(color.Substring(0, 3)),
                (byte)Convert.ToInt32(color.Substring(3, 3)), 
                (byte)Convert.ToInt32(color.Substring(6,3))));

            Canvas.SetLeft(rectangle, width * x);
            Canvas.SetTop(rectangle, height * (board.height - y));
            rectangle.Fill = brush;
            canvas.Children.Add(rectangle);
        }

        private void Resized(object sender, SizeChangedEventArgs e)
        {
            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Height = Application.Current.MainWindow.Width * ratio;
            if(board != null && gameGoing)
            {
                DrawFrame();
            }
        }
    }
}
