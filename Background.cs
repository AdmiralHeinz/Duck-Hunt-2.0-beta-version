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
        public Background(Canvas canvas)
        {
            FileStream fileStream;///set cursor
            fileStream = new FileStream("Crosshair.cur", FileMode.Open);
            crossHair = new Cursor(fileStream);


            Rectangle background = new Rectangle();
            background.Height = 800;
            background.Width = 1000;

            BitmapImage bitmapBackground = new BitmapImage(new Uri("Background.png", UriKind.Relative));
            ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            background.Fill = backgroundBrush;

            canvas.Children.Add(background);
            canvas.UpdateLayout();

            //start music
            ///MediaPlayer musicPlayer = new MediaPlayer();
            //musicPlayer.Open(new Uri("tapperSong.mp3", UriKind.Relative));
            //musicPlayer.Play();

        }
    }
}
