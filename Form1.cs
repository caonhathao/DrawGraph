using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Form1 : Form
    {
        private int oldHeight;
        private int oldWidth;
        private int count = 1;
        private List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {

        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            DrawPoint();
        }
        private void DrawPoint()
        {
            Random random = new Random();
            int X = random.Next(10, this.Width - 50);
            int Y = random.Next(10, this.Height - 50);

            //Ve hinh tron dai dien cho cac node
            SolidBrush myBush = new SolidBrush(Color.GreenYellow);
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(myBush, new Rectangle(
                X,
                Y,
                20, 20
                ));
            myBush.Dispose();
            formGraphics.Dispose();

            Graphics formGraphics1 = this.CreateGraphics();
            string drawNumber = count.ToString();
            Font font = new Font("UTM Alexander", 10);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat();
            formGraphics1.DrawString(drawNumber, font, solidBrush, X, Y, stringFormat);
            count++;

            Point p = new Point();
            p.GetPoint(X, Y, count);
            points.Add(p);

            Graphics formGraphics2 = this.CreateGraphics();
            string drawLocation = "x:" + p.PointX.ToString() + " y:" + p.PointY.ToString();
            formGraphics2.DrawString(drawLocation, font, solidBrush, X + 10, Y + 10, stringFormat);

            font.Dispose();
            solidBrush.Dispose();
            stringFormat.Dispose();
        }
    }
}
