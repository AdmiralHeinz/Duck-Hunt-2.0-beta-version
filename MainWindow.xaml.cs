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

        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();

            Background background = new Background(Canvas);/// initalize background class

            this.Cursor = background.crossHair;///set crosshair
            this.ForceCursor = true;

            gameTimer.Tick += GameTimer_Tick;///gametimer 
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();



        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (duck.isDuck == false)
            {
                duck.Spawn(Canvas);
                MessageBox.Show("spawn");
            }


            if (player.MouseClicked())
            {
                ///this.Title = Mouse.GetPosition(this).ToString();
                ///Console.WriteLine(Mouse.GetPosition(this).ToString());
                double Shot_X;
                double Shot_Y;
                Shot_X = Mouse.GetPosition(this).X;
                Shot_Y = Mouse.GetPosition(this).Y;
                Shot_X += 25;
                Shot_Y += 25;
                duck.Kill(Shot_X, Shot_Y, Canvas, counter);

            }

            //else { this.Title = "no click"; } /// debug crap
            //this.Title = counter.ToString();

            duck.Move(counter);/// update duck


            counter++;/// update counter


        }
    }
}
