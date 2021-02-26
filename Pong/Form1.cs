using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Platform : Form
    {
        private bool flaga = true;
        private bool dragging = false;

        List<Ball> listBalls = new List<Ball>();


        public Platform()
        {

            InitializeComponent();

        }
        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }


        private void buttonStart_Click(object sender, EventArgs e){

            if(flaga == true){
                timer1.Start();
                flaga = false;
            }
            else{
                timer1.Stop();
                flaga = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int dx = 0;
            int dy = 0;
            Random rnd = new Random();
            foreach (Ball ball in listBalls)
            {
                dx = ball.Left + Convert.ToInt32(ball.Vx);
                dy = ball.Top + Convert.ToInt32(ball.Vy);

                if(dx < 0)
                {
                    dx = 0;
                    ball.Vx = ball.Vx * -1;
                }

                if(dx > panel1.Width - ball.Width)
                {
                    dx = panel1.Width - ball.Width;
                    ball.Vx = ball.Vx * -1;
                }

                if (dy < 0)
                {
                    dy = 0;
                    ball.Vy = ball.Vy * -1;
                }

                if (dy > panel1.Height - ball.Height)
                {
                    dy = panel1.Height - ball.Height;
                    ball.Vy = ball.Vy * -1;
                }

                if (Math.Abs(dy - paletka.Top) < 50 && Math.Abs(dx - (paletka.Left +paletka.Width/2)) < paletka.Width/2)
                {
                    dy = dy - 50;
                    ball.Vy = ball.Vy * - 1.1;
                    ball.Vx = ball.Vx * (Math.Sin(ConvertToRadians(rnd.Next(0, 90))+0.5));
                }
                
                ball.Location = new Point(dx, dy);
            }
            if (dragging)
            {
                paletka.Location = new Point(Cursor.Position.X, paletka.Top);
            }

        }

        private void buttonGenerate_Click(object sender, EventArgs e){
            Ball pileczka = new Ball();
            panel1.Controls.Add(pileczka);
            listBalls.Add(pileczka);
        }

        private void panel1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (dragging)
            {
                dragging = false;

            }
            else
            { 
                dragging = true;
            }
        }
    }
}
