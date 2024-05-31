using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Form1 : Form
    {
        private int count = 1;
        private List<Point> points = new List<Point>();

        public static bool[,] mxGraph = new bool[100, 100];
        public static int nodes = 0;

        private int oldWidth = 0, oldHeight = 0;
        public Form1()
        {
            InitializeComponent();
            oldHeight = this.Height;
            oldWidth = this.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int addX = (this.Width - oldWidth) / 2;
            int addY = (this.Height - oldHeight) / 2;

            oldHeight = this.Height;
            oldWidth = this.Width;

            DrawBtn.Location = new System.Drawing.Point(
                DrawBtn.Left + addX,
                DrawBtn.Top + addY);

            ConnectBtn.Location = new System.Drawing.Point(
                ConnectBtn.Left + addX,
                ConnectBtn.Top + addY);

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            if (nodes != 0)
            {
                ThreadStart threadStart = new ThreadStart(Draw);
                Thread thread = new Thread(threadStart);
                thread.IsBackground = true;
                thread.Start();
            }
            else DrawPoint();
        }

        void Draw()
        {
            for (int i = 0; i < nodes; i++)
            {
                DrawPoint();
                System.Threading.Thread.Sleep(200);
            }

            for (int i = 1; i <= nodes; i++)
            {
                for (int j = 1; j <= nodes; j++)
                {
                    if (mxGraph[i, j] == true)
                    {
                        DrawLine(points[i - 1], points[j - 1]);
                        System.Threading.Thread.Sleep(200);
                    }
                }
            }
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
               30, 30
                ));
            myBush.Dispose();
            formGraphics.Dispose();

            Graphics formGraphics1 = this.CreateGraphics();
            string drawNumber = count.ToString();
            Font font = new Font("UTM Alexander", 10);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat();

            formGraphics1.DrawString(
                drawNumber,
                font,
                solidBrush,
                X + 10 - drawNumber.Length * 1.5f,
                Y + 5,
                stringFormat);

            count++;

            Point p = new Point();
            p.GetPoint(X, Y, count);
            points.Add(p);

            //Graphics formGraphics2 = this.CreateGraphics();
            //string drawLocation = "x:" + p.PointX.ToString() + " y:" + p.PointY.ToString();
            //formGraphics2.DrawString(drawLocation, font, solidBrush, X + 10, Y + 10, stringFormat);

            font.Dispose();
            solidBrush.Dispose();
            stringFormat.Dispose();
        }

        private void DrawLine(Point a, Point b)
        {
            Pen pen = new Pen(Color.Black);
            Graphics graphics = this.CreateGraphics();

            graphics.DrawLine(pen, a.PointX, a.PointY, b.PointX, b.PointY);
        }
    }
}
