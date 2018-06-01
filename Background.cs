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
using System.IO;

namespace Duck_Hunt_2._0
{
    class Background
    {
        public Cursor crossHair;
        public Rectangle bulletDisplay;
        public Rectangle livesDisplay;
        public Label scorebox;
        Rectangle background = new Rectangle();

        public Background(Canvas canvas)
        {
            FileStream fileStream;///set cursor
            fileStream = new FileStream("Crosshair.cur", FileMode.Open);
            crossHair = new Cursor(fileStream);

            background.Height = 800;
            background.Width = 1000;
            BitmapImage bitmapSplash = new BitmapImage(new Uri("Splash.png", UriKind.Relative));
            ImageBrush splashBrush = new ImageBrush(bitmapSplash);
            background.Fill = splashBrush;
            canvas.Children.Add(background);
        }

        public void Start(Canvas canvas)
        {

            BitmapImage bitmapBackground = new BitmapImage(new Uri("Background.png", UriKind.Relative));
            ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            background.Fill = backgroundBrush;
            
            bulletDisplay = new Rectangle();
            bulletDisplay.Height = 50;
            bulletDisplay.Width = 80;
            Canvas.SetBottom(bulletDisplay, 10);
            canvas.Children.Add(bulletDisplay);
            
            //creating displays for lives
            livesDisplay = new Rectangle();
            livesDisplay.Height = 50;
            livesDisplay.Width = 120;
            Canvas.SetBottom(livesDisplay, 10);
            Canvas.SetLeft(livesDisplay, 440);
            canvas.Children.Add(livesDisplay);
            
            scorebox = new Label();
            scorebox.Width = 80;
            scorebox.Height = 40;
            Canvas.SetBottom(scorebox, 20);
            Canvas.SetLeft(scorebox, 900);
            scorebox.FontSize = 20;
            //scorebox.FontStyle;
            canvas.Children.Add(scorebox);
            
            canvas.UpdateLayout();
        }
        public void GameOver (Canvas canvas)
        {
            BitmapImage bitmapSplash = new BitmapImage(new Uri("Splash.png", UriKind.Relative));
            ImageBrush splashBrush = new ImageBrush(bitmapSplash);
            background.Fill = splashBrush;
            canvas.Children.Remove(scorebox);
            canvas.Children.Remove(bulletDisplay);
        }
    }
}
