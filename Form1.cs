using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collision_test
{
    public partial class Form1 : Form
    {
        // ball 1
        double xspeed1, yspeed, newyspeed, startingypos;
        double newxpos, newypos, oldxpos, oldypos;
        double newx, oldx, newy, oldy;
        double acc, t;
        const int ground = 500;
        int xmouse, ymouse;
        bool dragging = true, trace, collisiony;

        // ball 2
        double xspeed2, yspeed2, newyspeed2, startingypos2;
        double newxpos2, newypos2, oldxpos2, oldypos2;
        double newx2, oldx2, newy2, oldy2;
        double acc2, t2;
        int xmouse2, ymouse2;
        bool dragging2, trace2, collisiony2;

        // ball 3
        double xspeed3, yspeed3, newyspeed3, startingypos3;
		double newxpos3, newypos3, oldxpos3, oldypos3;
		double newx3, oldx3, newy3, oldy3;
		double acc3, t3;
        int xmouse3, ymouse3;
        bool dragging3, trace3, collisiony3;

        int choice = 1;
        int numberofballs = 1;
        Ballinstance b1 = new Ballinstance();
        Ballinstance b2 = new Ballinstance();
        Ballinstance b3 = new Ballinstance();

        public Form1()
        {
            InitializeComponent();
        }
        private void timer_Elapsed(object sender, EventArgs e)
        {
            b1.play(ref xspeed1, ref yspeed, ref newyspeed, ref startingypos, ref newxpos, ref newypos, ref oldxpos, ref oldypos, ref newx, ref oldx, ref newy, ref oldy, ref acc, ref t, ref xmouse, ref ymouse, ref dragging, ref trace, ref collisiony);
            ball.Left = (int)newxpos;
            ball.Top = (int)(ground - newypos);

            b2.play(ref xspeed2, ref yspeed2, ref newyspeed2, ref startingypos2, ref newxpos2, ref newypos2, ref oldxpos2, ref oldypos2, ref newx2, ref oldx2, ref newy2, ref oldy2, ref acc2, ref t2, ref xmouse2, ref ymouse2, ref dragging2, ref trace2, ref collisiony2);
            ball2.Left = (int)newxpos2;
            ball2.Top = (int)(ground - newypos2); //The position of the ball is determined here  || But this is also the reason for a problem (I want to be able to pull the ball with the mouse arrow)

            b3.play(ref xspeed3, ref yspeed3, ref newyspeed3, ref startingypos3, ref newxpos3, ref newypos3, ref oldxpos3, ref oldypos3, ref newx3, ref oldx3, ref newy3, ref oldy3, ref acc3, ref t3, ref xmouse3, ref ymouse3, ref dragging3, ref trace3, ref collisiony3);
            ball3.Left = (int)newxpos3;
            ball3.Top = (int)(ground - newypos3);

            Collision();
        }
		private void Collision()
		{
			#region ball and ball2
			// ball hits ball2 from the right, and we don't know the direction of ball2 nor ball
			if (((ball.Right > ball2.Left && ball.Right < ball2.Right) && ((ball.Top >= ball2.Top && ball.Top <= ball2.Bottom) || (ball.Top <= ball2.Top && ball.Bottom >= ball2.Top))))
			{
				// xspeed1 either will decrease or increase at the same or the oppisite direction, depends on its direction
				// xspeed2 either will decrease or increase at the same or the oppisite direction, depends on its direction
				// hit with the same direction, the power of hit depends on the xspeed, by the "preserved momentum law", knowing that they have the same mass -> xspeed1 + xspeed2 = xspeed1` + xspeed2`

				if (Math.Abs(xspeed1) < 0.5 && Math.Abs(xspeed1) >= 0)
					xspeed1 = xspeed2;
				else if (xspeed1 > 0)
					xspeed1 *= -0.9;
				else
					xspeed1 *= 1.35;

				if (Math.Abs(xspeed2) < 0.5 && Math.Abs(xspeed2) >= 0)
					xspeed2 = xspeed1;
				else if (xspeed2 > 0)
					xspeed2 *= 1.35;
				else
					xspeed2 *= -0.9;
			}

			// ball hits ball2 from the left, and we don't know the direction of ball2 nor ball
			if (((ball.Left > ball2.Left && ball.Left < ball2.Right) && ((ball.Top >= ball2.Top && ball.Top <= ball2.Bottom) || (ball.Top <= ball2.Top && ball.Bottom >= ball2.Top))))
			{
				// xspeed either will decrease or increase at the same or the oppisite direction, depends on its direction
				// xspeed2 either will decrease or increase at the same or the oppisite direction, depends on its direction
				// hit with the same direction, the power of hit depends on the xspeed, by the "preserved momentum law", knowing that the have the same mass -> xspeed + xspeed2 = xspeed` + xspeed2`

				if (Math.Abs(xspeed1) < 0.5 && Math.Abs(xspeed1) >= 0)
					xspeed1 = xspeed2;
				else if (xspeed1 < 0)
					xspeed1 *= -0.9;
				else
					xspeed1 *= 1.35;

				if (Math.Abs(xspeed2) < 0.5 && Math.Abs(xspeed2) >= 0)
					xspeed2 = xspeed1;
				else if (xspeed2 < 0)
					xspeed2 *= 1.35;
				else
					xspeed2 *= -0.9;
			}
			#endregion ball and ball2

			#region ball and ball3
			// ball hits ball3 from the right, and we don't know the direction of ball3 nor ball
			if (((ball.Right > ball3.Left && ball.Right < ball3.Right) && ((ball.Top >= ball3.Top && ball.Top <= ball3.Bottom) || (ball.Top <= ball3.Top && ball.Bottom >= ball3.Top))))
			{
				// xspeed either will decrease or increase at the same or the oppisite direction, depends on its direction
				// xspeed3 either will decrease or increase at the same or the oppisite direction, depends on its direction
				// hit with the same direction, the power of hit depends on the xspeed, by the "preserved momentum law", knowing that the have the same mass -> xspeed + xspeed3 = xspeed` + xspeed3`

				if (Math.Abs(xspeed1) < 0.5 && Math.Abs(xspeed1) >= 0)
					xspeed1 = xspeed3;
				else if (xspeed1 > 0)
					xspeed1 *= -0.9;
				else
					xspeed1 *= 1.35;

				if (Math.Abs(xspeed3) < 0.5 && Math.Abs(xspeed3) >= 0)
					xspeed3 = xspeed1;
				else if (xspeed3 > 0)
					xspeed3 *= 1.35;
				else
					xspeed3 *= -0.9;
			}

			// ball hits ball3 from the left, and we don't know the direction of ball3 nor ball
			if (((ball.Left > ball3.Left && ball.Left < ball3.Right) && ((ball.Top >= ball3.Top && ball.Top <= ball3.Bottom) || (ball.Top <= ball3.Top && ball.Bottom >= ball3.Top))))
			{
				// xspeed either will decrease or increase at the same or the oppisite direction, depends on its direction
				// xspeed3 either will decrease or increase at the same or the oppisite direction, depends on its direction
				// hit with the same direction, the power of hit depends on the xspeed, by the "preserved momentum law", knowing that the have the same mass -> xspeed + xspeed3 = xspeed` + xspeed3`

				if (Math.Abs(xspeed1) < 0.5 && Math.Abs(xspeed1) >= 0)
					xspeed1 = xspeed3;
				else if (xspeed1 < 0)
					xspeed1 *= -0.9;
				else
					xspeed1 *= 1.35;

				if (Math.Abs(xspeed3) < 0.5 && Math.Abs(xspeed3) >= 0)
					xspeed3 = xspeed1;
				else if (xspeed3 < 0)
					xspeed3 *= 1.35;
				else
					xspeed3 *= -0.9;
			}
			#endregion ball and ball3

			#region ball2 and ball3
			// ball2 hits ball3 from the right, and we don't know the direction of ball3 nor ball2
			if (((ball2.Right > ball3.Left && ball2.Right < ball3.Right) && ((ball2.Top >= ball3.Top && ball2.Top <= ball3.Bottom) || (ball2.Top <= ball3.Top && ball2.Bottom >= ball3.Top))))
			{
				//The same as above (with xspeed1 and xspeed2, only with other variables (xspeed2 and xspeed3))
				if (Math.Abs(xspeed2) < 0.5 && Math.Abs(xspeed2) >= 0)
					xspeed2 = xspeed3;
				else if (xspeed2 > 0)
					xspeed2 *= -0.9;
				else
					xspeed2 *= 1.35;

				if (Math.Abs(xspeed3) < 0.5 && Math.Abs(xspeed3) >= 0)
					xspeed3 = xspeed2;
				else if (xspeed3 > 0)
					xspeed3 *= 1.35;
				else
					xspeed3 *= -0.9;
			}

			// ball2 hits ball3 from the left, and we don't know the direction of ball3 nor ball2
			if (((ball2.Left > ball3.Left && ball2.Left < ball3.Right) && ((ball2.Top >= ball3.Top && ball2.Top <= ball3.Bottom) || (ball2.Top <= ball3.Top && ball2.Bottom >= ball3.Top))))
			{
				//The same as above (region ball2 and ball3)

				if (Math.Abs(xspeed2) < 0.5 && Math.Abs(xspeed2) >= 0)
					xspeed2 = xspeed3;
				else if (xspeed2 < 0)
					xspeed2 *= -0.9;
				else
					xspeed2 *= 1.35;

				if (Math.Abs(xspeed3) < 0.5 && Math.Abs(xspeed3) >= 0)
					xspeed3 = xspeed2;
				else if (xspeed3 < 0)
					xspeed3 *= 1.35;
				else
					xspeed3 *= -0.9;
			}
			#endregion ball2 and ball3
		}
		#region drag and drop ball2
		private void ball2_MouseDown(object sender, MouseEventArgs e)  //if you press the 'mouse button'
		{
			PictureBox send = (PictureBox)sender; send.Tag = e.Location;
		}
		private void ball2_MouseMove(object sender, MouseEventArgs e)  //if you move the mouse cursor
		{
			PictureBox send = (PictureBox)sender;
			if (send.Tag != null)
			{
				Point start = (Point)send.Tag;
				send.Location = new Point(send.Location.X + e.X - start.X, send.Location.Y + e.Y - start.Y);
			}
		}
		private void ball2_MouseUp(object sender, MouseEventArgs e) //When you release the mouse button
		{
			PictureBox send = (PictureBox)sender; send.Tag = null; 
		}
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
			//sw = new StreamWriter("trace.txt");
			t = t2 = t3 = 0;
			acc = acc2 = acc3 = 10;
			// Hide the balls
			newxpos2 = newxpos3 = 2000;
			newypos2 = newypos3 = 2000;

		}
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			// Pick a ball randomly
			// Random rnd = new Random(DateTime.Now.Second);
			// Choice = rnd.Next(1,numberofballs);

			if (numberofballs == 1)
				choice = 1;
			else if (numberofballs == 2)
				choice = (choice == 1) ? 2 : 1;
			else    // 3 balls available
			{
				if (choice == 1)
					choice = 2;
				else if (choice == 2)
					choice = 3;
				else
					choice = 1;
			}
			switch (choice)
			{
				case 1:
					dragging = true;
					newxpos = e.X;
					newypos = e.Y;
					xmouse = e.X;
					ymouse = e.Y;
					break;
				case 2:
					dragging2 = true;
					newxpos2 = e.X;
					newypos2 = e.Y;
					xmouse2 = e.X;
					ymouse2 = e.Y;
					break;
				case 3:
					dragging3 = true;
					newxpos3 = e.X;
					newypos3 = e.Y;
					xmouse3 = e.X;
					ymouse3 = e.Y;
					break;
			}
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			switch (choice)
			{
				case 1:
					xmouse = e.X;
					ymouse = e.Y;
					break;
				case 2:
					xmouse2 = e.X;
					ymouse2 = e.Y;
					break;
				case 3:
					xmouse3 = e.X;
					ymouse3 = e.Y;
					break;
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			switch (choice)
			{
				case 1:
					dragging = false;
					break;
				case 2:
					dragging2 = false;
					break;
				case 3:
					dragging3 = false;
					break;
			}
		}
		private void hide1_btn_Click(object sender, EventArgs e)
		{
			groupBall1.Visible = false;
		}

		private void hide2_btn_Click(object sender, EventArgs e)
		{
			groupBall2.Visible = false;
		}

		private void hide3_btn_Click(object sender, EventArgs e)
		{
			groupBall3.Visible = false;
		}
		private void ok1_btn_Click(object sender, System.EventArgs e)
		{
			xspeed1 = (double)n1.Value;
			yspeed = (double)n2.Value;
			newxpos = (double)n3.Value;
			newypos = (double)n4.Value;
			acc = (double)acc_one.Value;
			dragging = false;
		}

		private void ok2_btn_Click(object sender, System.EventArgs e)
		{
			xspeed2 = (double)n8.Value;
			yspeed2 = (double)n7.Value;
			newxpos2 = (double)n6.Value;
			newypos2 = (double)n5.Value;
			acc2 = (double)acc_two.Value;
			dragging = false;
		}

		private void ok3_btn_Click(object sender, System.EventArgs e)
		{
			xspeed3 = (double)n12.Value;
			yspeed3 = (double)n11.Value;
			newxpos3 = (double)n10.Value;
			newypos3 = (double)n9.Value;
			acc3 = (double)acc_three.Value;
			dragging = false;
		}
		private void menuItem2_Click(object sender, EventArgs e)
        {
			groupBall1.Visible = true;
		}

        private void menuItem3_Click(object sender, EventArgs e)
        {
			if (groupBall1.Visible == true)
				groupBall2.Visible = true;
		}

        private void menuItem4_Click(object sender, EventArgs e)
        {
			if (groupBall2.Visible == true)
				groupBall3.Visible = true;
		}

        private void menuItem11_Click(object sender, EventArgs e)
        {
			Application.Exit();
		}

        private void menuItem6_Click(object sender, EventArgs e)
        {
			if (numberofballs != 3)
				numberofballs++;
		}

        private void menuItem7_Click(object sender, EventArgs e)
        {

		}

		private void menuItem8_Click(object sender, EventArgs e)
        {
			int c;
			double a = 0.5; int b = Convert.ToInt32(a); c = 1 - b;
			timer.Interval *= c;                            //(Have to be bigger than 0 .... actually 0,5)
		}

        private void menuItem9_Click(object sender, EventArgs e)
        {
			timer.Interval *= 2;
		}

        private void menuItem15_Click(object sender, EventArgs e)
        {
			MessageBox.Show(this, "This program ball collision is programed by:\n\nAndré J.\nandre_jann@web.de\n0176 92142406", "About");
		}
    }
	public class Ballinstance
	{
		int xpos, ypos;
		const int ground = 500;
		public void play(ref double xspeed, ref double yspeed, ref double newyspeed, ref double startingypos, ref double newxpos, ref double newypos, ref double oldxpos, ref double oldypos, ref double newx, ref double oldx, ref double newy, ref double oldy, ref double acc, ref double t, ref int xmouse, ref int ymouse, ref bool dragging, ref bool trace, ref bool collisiony)
		{
			//Hide the balls (as we already know)
			xpos = (int)newxpos;
			ypos = (int)newypos;

			// This code will be visited 50 (timer has 20 ms) times per second while dragging
			if (dragging)  //I want to change that soon!!!
			{
				// Grip the center of the ball when dragging (but I want to change that soon)
				xpos = xmouse;
				ypos = ymouse;

				// While dragging the starting y-axis position of the ball is ball.Top
				startingypos = ground - ypos;

				// Calculate the x and y speed based on the mouse movement within 20 msec
				// the speed is the change in the displacement with respect to time which
				// is already running (the code is within the timer), so we don't have to divide 
				// by time.
				newx = xpos;
				newy = ground - ypos;
				xspeed = (newx - oldx) / 1;  //// speed = distance/time  ->  time = 20 ms 
				yspeed = (newy - oldy) / 1;
				oldx = newx;
				oldy = newy;

				// The time -while dragging- will not start yet
				t = 0;

			}
			else
			{
				// This code will be visited 50 times per second while not dragging
				// The ball position is where it's last dragged
				oldxpos = xpos;
				// X-axis motion
				if (xpos < 580 && 0 < xpos)
				{
					newxpos = oldxpos + xspeed;
				}
				else
				{
					// Here the ball will hits the wall
					// Ball xspeed will decrease every time it hits the wall
					// Minus sign: to change the ball direction when it collides with the wall
					// Wall resitance, the ball will lose som energy when hitting the wall
					xspeed *= -0.9; // Wall resistance  	
					newxpos = oldxpos + xspeed;
				}

				// Y-axis motion
				if (0 < newypos || collisiony)
				{
					// Newton first motion equation (Vy = Vy - g*t)
					newyspeed = yspeed - (acc * t);
					// Newton third motion equation (Y = Y0 + Vy * ty - 0,5 * g * t^2)
					newypos = startingypos + ((yspeed * t) - 0.5 * acc * (t * t));
					// no collision happend
					collisiony = false;
				}
				else
				{
					// Here the ball will hits the ground
					// Initialize the ball variables again
					startingypos = -1;
					// Here set startingypos=-1 not 0, because if 0 newypos will be 0 every time the ball 
					// Hits the ground so no bouncing will happens to the ball
					t = 0;
					// Ball yspeed will decrease every time it hits the ground
					// 0.75 is the elasticity coefficient - assumption
					// The initial speed(yspeed) is 0.75 of the final speed(newyspeed)
					yspeed = newyspeed * -0.75;
					newypos = startingypos + ((yspeed * t) - 0.5 * acc * (t * t));
					collisiony = true;
				}
				// Always
				// Ball xspeed will always decrease, even if it didn't hit the wall
				xspeed *= 0.99; // Air resistance

				if (xspeed > -0.5 && xspeed < 0)
					xspeed = 0;

				// Update the ball position
				xpos = (int)newxpos;
				ypos = (int)(ground - newypos);
				// Increase the time
				t += 0.3;
			}
		}

	}
}
