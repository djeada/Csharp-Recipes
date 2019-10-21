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
    public partial class Form1 : Form
    {
        bool flaga = true;
        List<Ball> listBalls = new List<Ball>();

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

                ball.Location = new Point(dx, dy);
            }

        }

        private void buttonGenerate_Click(object sender, EventArgs e){
            Ball pileczka = new Ball();
            panel1.Controls.Add(pileczka);
            listBalls.Add(pileczka);
        }

    }
}
