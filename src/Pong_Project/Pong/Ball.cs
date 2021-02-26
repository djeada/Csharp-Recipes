using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
   class Ball :  PictureBox{
        private double vx = 10;
        private double vy = 10;
        public double Vx { get { return vx; } set { vx = value; } }
        public double Vy { get { return vy; } set { vy = value; } }

        public Ball() {
            this.Location = new Point(30, 30);
            this.Image = global::Pong.Properties.Resources.soccer_ball_clip_art_13012;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        }
    }
}
