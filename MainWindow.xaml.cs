//Aidan, Jakob, Peter, Austin
//June 1, 2018
//Duck Hunt
//A recreation of the game Duck Hunt
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Duck_Hunt_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Duck duck = new Duck();
        Player player = new Player();
        MediaPlayer musicPlayer = new MediaPlayer();
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        Background background;
        int counter = 0;
        int Lives = 3;
        double Shot_X;
        double Shot_Y;
        bool gameOn;

        public MainWindow()
        {
            InitializeComponent();

            background = new Background(Canvas);/// initalize background class

            this.Cursor = background.crossHair;///set crosshair
            this.ForceCursor = true;

            gameTimer.Tick += GameTimer_Tick;///gametimer 
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();
            
            //start music
            musicPlayer.Open(new Uri("Imperial song  John Williams.mp3", UriKind.Relative));
            //musicPlayer.Play();

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameOn)
            {
                if (duck.isDuck == false)
                {
                    duck.Spawn(Canvas);
                }

                if (player.MouseClicked())
                {
                    ///this.Title = Mouse.GetPosition(this).ToString();
                    ///Console.WriteLine(Mouse.GetPosition(this).ToString());
                    Shot_X = Mouse.GetPosition(this).X + 25;
                    Shot_Y = Mouse.GetPosition(this).Y + 25;
                    duck.Kill(Shot_X, Shot_Y, Canvas, counter);
                }

                //else { this.Title = "no click"; } /// debug crap
                //this.Title = counter.ToString();

                if (duck.shots == 0)
                {
                    BitmapImage ThreeShots = new BitmapImage(new Uri("Three Shots.png", UriKind.Relative));
                    ImageBrush Three = new ImageBrush(ThreeShots);
                    background.bulletDisplay.Fill = Three;
                }///change shots remaining graphic
                if (duck.shots == 1)
                {
                    if (duck.isDuck == false)
                    {
                        duck.shots = 0;
                    }
                    BitmapImage TwoShots = new BitmapImage(new Uri("Two Shots.png", UriKind.Relative));
                    ImageBrush Two = new ImageBrush(TwoShots);
                    background.bulletDisplay.Fill = Two;
                }
                if (duck.shots == 2)
                {
                    if (duck.isDuck == false)
                    {
                        duck.shots = 0;
                    }
                    BitmapImage OneShot = new BitmapImage(new Uri("One Shot.png", UriKind.Relative));
                    ImageBrush One = new ImageBrush(OneShot);
                    background.bulletDisplay.Fill = One;
                }
                if (duck.shots == 3)
                {
                    BitmapImage NoShot = new BitmapImage(new Uri("No Shots.png", UriKind.Relative));
                    ImageBrush None = new ImageBrush(NoShot);
                    background.bulletDisplay.Fill = None;

                    Lives--;
                    if (Lives == 0)
                    {
                        duck.isDuck = false;
                        Canvas.Children.Remove(duck.duck);
                        background.GameOver(Canvas);
                        MessageBox.Show("GameOver");
                        gameOn = false;
                        duck.DucksKilled = 0;
                    }
                    else if (Lives > 0)
                    {
                        MessageBox.Show("out of ammo");
                        Canvas.Children.Remove(duck.duck);
                        duck.isDuck = false;
                        duck.shots = 0;
                    }
                }
                
                if (Lives == 3) ///change Lives remaining graphic
                {
                    BitmapImage ThreeShots = new BitmapImage(new Uri("Three Lives.png", UriKind.Relative));
                    ImageBrush Three = new ImageBrush(ThreeShots);
                    background.bulletDisplay.Fill = Three;
                }
                if (Lives == 2)
                {
                    BitmapImage TwoShots = new BitmapImage(new Uri("Two Lives.png", UriKind.Relative));
                    ImageBrush Two = new ImageBrush(TwoShots);
                    background.bulletDisplay.Fill = Two;
                }

                if (Lives == 1)
                {
                    BitmapImage OneShot = new BitmapImage(new Uri("One Live.png", UriKind.Relative));
                    ImageBrush One = new ImageBrush(OneShot);
                    background.bulletDisplay.Fill = One;
                }
                if (Lives == 0)
                {
                    BitmapImage NoShot = new BitmapImage(new Uri("No Lives.png", UriKind.Relative));
                    ImageBrush None = new ImageBrush(NoShot);
                    background.bulletDisplay.Fill = None;
                }
                
                duck.Move(counter);/// update duck
                background.scorebox.Content = (duck.DucksKilled * 100).ToString();
            }
            counter++;/// update counter
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.Enter))
            {
                if (gameOn == false)
                {
                    background.Start(Canvas);
                    gameOn = true;
                }
            }
        }
    }
}
