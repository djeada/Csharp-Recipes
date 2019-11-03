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

        Point GetMousePos()
        {
            Point p = Mouse.GetPosition(Application.Current.MainWindow);
            p.X -= 50;
            p.Y -= 50;
            return p;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Thickness m = target.Margin;
            m.Left = GetMousePos().X;
            m.Top = GetMousePos().Y;
            target.Margin = m;

            foreach (Image k in kaczki)
            {
                m = k.Margin;
                m.Left -= 10;
                m.Top -= r.Next(-5, 5);
                k.Margin = m;
            }
        }
    }
}
