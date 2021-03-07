using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle.Impl
{
    public class PointEquality : IEqualityComparer<Point>
    {
        public bool Equals(Point p1, Point p2)
        {
            return p1 != null && p2 != null && p1.X == p2.X && p1.Y == p2.Y;
        }

        public int GetHashCode(Point obj)
        {
            return 0;
        }
    }
}
