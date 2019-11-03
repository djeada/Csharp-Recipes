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

namespace Duck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        List<Image> kaczki = new List<Image>();
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(50);
            dispatcherTimer.Start();
            kaczki.Add(kaczka1);
            kaczki.Add(kaczka2);
            kaczki.Add(kaczka3);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            target.Margin = move(target.Margin, GetMousePos().X, GetMousePos().Y);

            foreach (Image k in kaczki)
            {
                k.Margin = move(k.Margin, k.Margin.Left - 10, k.Margin.Top - r.Next(-5, 5));
                if (checkColisions(target.Margin, k.Margin))
                {
                    k.Visibility = Visibility.Hidden;
                    counter++;
                    display.Content = "Duck counter: " + Convert.ToString(counter) + "/3";
                }
            }
        }
        Thickness move(Thickness old, double x, double y)
        {
            Thickness m = old;
            m.Left = x;
            m.Top = y;
            return m;
        }
        private Point GetMousePos()
        {
            Point p = Mouse.GetPosition(Application.Current.MainWindow);
            p.X -= 50;
            p.Y -= 50;
            return p;
        }

        bool checkColisions(Thickness m1, Thickness m2)
        {
            if(Math.Abs(center(m1).X - center(m2).X) < 20 & Math.Abs(center(m1).Y - center(m2).Y) < 20 & Mouse.LeftButton == MouseButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        Point center(Thickness m)
        {
            return new Point((m.Top - m.Bottom) / 2, (m.Left - m.Right) / 2);
        }
    }
}
