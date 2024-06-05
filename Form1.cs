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
            int addY = (this.Height - oldHeight);

            oldHeight = this.Height;
            oldWidth = this.Width;

            DrawBtn.Location = new System.Drawing.Point(
                DrawBtn.Left + addX,
                DrawBtn.Top + addY);

            ConnectBtn.Location = new System.Drawing.Point(
                ConnectBtn.Left + addX,
                ConnectBtn.Top + addY);

            CLoseBtn.Location = new System.Drawing.Point(
                CLoseBtn.Left + addX,
                CLoseBtn.Top + addY);

            ClearBrn.Location = new System.Drawing.Point(
                ClearBrn.Left + addX,
                ClearBrn.Top + addY);
        }
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            count = 1;
            points.Clear();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            if (nodes != 0)
            {
                Graphics gp = this.CreateGraphics();
                gp.Clear(this.BackColor);
                gp.Dispose();

                ThreadStart threadStart = new ThreadStart(Draw);
                Thread thread = new Thread(threadStart);
                thread.IsBackground = true;
                thread.Start();
            }
            else DrawPoint();
        }

        private void CLoseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearBrn_Click(object sender, EventArgs e)
        {
            count = 1;
            nodes = 0;
            points.Clear();

            Graphics gp = this.CreateGraphics();
            gp.Clear(this.BackColor);
            gp.Dispose();
        }

        Point[] p = new Point[2];
        int k = 0;
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            double d = 0f;
            bool IsChoosePoint = false;
            Pen pen;
            Graphics gp;


            for (int i = 0; i < points.Count; i++)
            {
                d = Math.Sqrt((Math.Pow(e.X - points[i].X, 2) + Math.Pow(e.Y - points[i].Y, 2)));
                if (d <= 30f)
                {
                    IsChoosePoint = true;
                    pen = new Pen(Color.Blue, 2);
                    gp = this.CreateGraphics();
                    gp.DrawEllipse(pen, points[i].X - 15, points[i].Y - 15, 30, 30);
                    gp.Dispose();
                    pen.Dispose();

                    p[k] = points[i];
                    k++;
                    if (k == 2)
                    {
                        DrawLine(p[0], p[1]);
                    }
                    break;
                }
            }
            if ((IsChoosePoint == false || k == 2) && p[0] != null)
            {
                k = 0;
                for (int i = 0; i < 2; i++)
                {
                    pen = new Pen(Color.Green, 2);
                    gp = this.CreateGraphics();
                    gp.DrawEllipse(pen, p[i].X - 15, p[i].Y - 15, 30, 30);
                    gp.Dispose(); pen.Dispose();
                }
            }
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
            int X = 0, Y = 0;

            X = random.Next(10, this.Width - 200);
            Y = random.Next(15, this.Height - 200);

            //Ve hinh tron dai dien cho cac node
            Pen penNode = new Pen(Color.Green, 2);
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawEllipse(penNode, X, Y, 30, 30);
            penNode.Dispose();
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
            p.SetPoint(X + 15, Y + 15, count);
            points.Add(p);

            //Graphics formGraphics2 = this.CreateGraphics();
            //string drawLocation = "x:" + p.X.ToString() + " y:" + p.Y.ToString();
            //formGraphics2.DrawString(drawLocation, font, solidBrush, X + 10, Y + 10, stringFormat);

            font.Dispose();
            solidBrush.Dispose();
            stringFormat.Dispose();
        }

        private void DrawLine(Point a, Point b)
        {
            Pen pen = new Pen(Color.Red);
            Graphics graphics = this.CreateGraphics();

            double dx = a.X - b.X;
            double dy = a.Y - b.Y;

            double magnitude = Math.Sqrt(dx * dx + dy * dy);

            dx = dx / magnitude * 15;
            dy = dy / magnitude * 15;

            int x1 = b.X + (int)dx;
            int y1 = b.Y + (int)dy;
            int x2 = a.X - (int)dx;
            int y2 = a.Y - (int)dy;

            graphics.DrawLine(pen, x1, y1, x2, y2);
        }
    }
}
