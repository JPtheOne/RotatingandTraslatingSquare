using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubo2
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        static Graphics g;
        int sqsize=100;
 
        Point a, b, c, d,origin,a1,b1,c1,d1,aAx,bAx,cAx,dAx;

        

        Point aT, bT, cT, dT;
        Point aRO, bRO, cRO, dRO;
        double angle;

       public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            origin = new Point(bmp.Width / 2, bmp.Height / 2);
            Axis();
            a = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            b = new Point((pictureBox1.Width / 2) + sqsize, pictureBox1.Height / 2);
            c = new Point((pictureBox1.Width / 2) + sqsize, (pictureBox1.Height / 2) - sqsize);
            d = new Point(pictureBox1.Width / 2, (pictureBox1.Height / 2) - sqsize);

            Square(a, b, c, d);
              
        }



        private void button1_Click(object sender, EventArgs e)
        {
            angle = Convert.ToInt32(textBox1.Text);
            angle = -(angle * Math.PI / 180);

            Rotate();
            g.Clear(Color.White);

            Axis();

            Square(a1, b1, c1, d1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            angle = Convert.ToInt32(textBox1.Text);
            angle = -(angle * Math.PI / 180);

            Translate();
            g.Clear(Color.White);

            Axis();

            Square(aT, bT, cT, dT);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            angle = Convert.ToInt32(textBox1.Text);
            angle = -(angle * Math.PI / 180);

            RotateinOrigin();
            g.Clear(Color.White);

            Axis();

            Square(aRO, bRO, cRO, dRO);
        }

        private void Square(Point a, Point b, Point c, Point d)//Square 
        {
            g.DrawLine(Pens.Gray, a, b);
            g.DrawLine(Pens.Gray, b, c);
            g.DrawLine(Pens.Gray, c, d);
            g.DrawLine(Pens.Gray, d, a);

            pictureBox1.Invalidate();
        }

        private void Axis() //Draws the cartesian plane in the canva
        {
            aAx = new Point(pictureBox1.Width / 2, 0);
            bAx = new Point(pictureBox1.Width / 2, pictureBox1.Height);
            cAx = new Point(0, pictureBox1.Height / 2);
            dAx = new Point(pictureBox1.Width, pictureBox1.Height / 2);

            g.DrawLine(Pens.Violet,aAx,bAx);
            g.DrawLine(Pens.Violet,cAx,dAx);
        }

        private void Rotate()
        {
            a1.X = (int)(((a.X - origin.X) * Math.Cos(angle)) - ((a.Y - origin.Y) * Math.Sin(angle)) + origin.X);
            a1.Y = (int)(((a.X - origin.X) * Math.Sin(angle)) + ((a.Y - origin.Y) * Math.Cos(angle)) + origin.Y);
            b1.X = (int)(((b.X - origin.X) * Math.Cos(angle)) - ((b.Y - origin.Y) * Math.Sin(angle)) + origin.X);
            b1.Y = (int)(((b.X - origin.X) * Math.Sin(angle)) + ((b.Y - origin.Y) * Math.Cos(angle)) + origin.Y);
            c1.X = (int)(((c.X - origin.X) * Math.Cos(angle)) - ((c.Y - origin.Y) * Math.Sin(angle)) + origin.X);
            c1.Y = (int)(((c.X - origin.X) * Math.Sin(angle)) + ((c.Y - origin.Y) * Math.Cos(angle)) + origin.Y);
            d1.X = (int)(((d.X - origin.X) * Math.Cos(angle)) - ((d.Y - origin.Y) * Math.Sin(angle)) + origin.X);
            d1.Y = (int)(((d.X - origin.X) * Math.Sin(angle)) + ((d.Y - origin.Y) * Math.Cos(angle)) + origin.Y);
        }

        private void Translate()
        {
            aT.X = (int)(((a.X - origin .X) * Math.Cos(angle)) - ((a.Y - origin .Y) * Math.Sin(angle)) + origin .X);
            aT.Y = (int)(((a.X - origin .X) * Math.Sin(angle)) + ((a.Y - origin .Y) * Math.Cos(angle)) + origin .Y);
            bT.X = (int)(((b.X - origin .X) * Math.Cos(angle)) - ((b.Y - origin .Y) * Math.Sin(angle)) + origin .X);
            bT.Y = (int)(((b.X - origin .X) * Math.Sin(angle)) + ((b.Y - origin .Y) * Math.Cos(angle)) + origin .Y);
            cT.X = (int)(((c.X - origin .X) * Math.Cos(angle)) - ((c.Y - origin .Y) * Math.Sin(angle)) + origin .X);
            cT.Y = (int)(((c.X - origin .X) * Math.Sin(angle)) + ((c.Y - origin .Y) * Math.Cos(angle)) + origin .Y);
            dT.X = (int)(((d.X - origin .X) * Math.Cos(angle)) - ((d.Y - origin .Y) * Math.Sin(angle)) + origin .X);
            dT.Y = (int)(((d.X - origin .X) * Math.Sin(angle)) + ((d.Y - origin .Y) * Math.Cos(angle)) + origin .Y);
        }


        private void RotateinOrigin()
        {
            aRO.X = (int)(((a.X - 50 - origin.X) * Math.Cos(angle)) - ((a.Y + 50 - origin.Y) * Math.Sin(angle)) + origin.X);
            aRO.Y = (int)(((a.X - 50 - origin.X) * Math.Sin(angle)) + ((a.Y + 50 - origin.Y) * Math.Cos(angle)) + origin.Y);
            bRO.X = (int)(((b.X - 50 - origin.X) * Math.Cos(angle)) - ((b.Y + 50 - origin.Y) * Math.Sin(angle)) + origin.X);
            bRO.Y = (int)(((b.X - 50 - origin.X) * Math.Sin(angle)) + ((b.Y + 50 - origin.Y) * Math.Cos(angle)) + origin.Y);
            cRO.X = (int)(((c.X - 50 - origin.X) * Math.Cos(angle)) - ((c.Y + 50 - origin.Y) * Math.Sin(angle)) + origin.X);
            cRO.Y = (int)(((c.X - 50 - origin.X) * Math.Sin(angle)) + ((c.Y + 50 - origin.Y) * Math.Cos(angle)) + origin.Y);
            dRO.X = (int)(((d.X - 50 - origin.X) * Math.Cos(angle)) - ((d.Y + 50 - origin.Y) * Math.Sin(angle)) + origin.X);
            dRO.Y = (int)(((d.X - 50 - origin.X) * Math.Sin(angle)) + ((d.Y + 50 - origin.Y) * Math.Cos(angle)) + origin.Y);
        }
    }   
 
       
    
}
