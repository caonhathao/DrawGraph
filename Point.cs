using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Point
    {
        public int PointX;
        public int PointY;
        public int value;

        public void GetPoint(int x, int y, int v)
        {
            PointX = x;
            PointY = y;
            value = v;
        }
    }
}
