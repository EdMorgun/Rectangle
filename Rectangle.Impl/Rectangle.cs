using System;
using System.Collections.Generic;

namespace Rectangle.Impl
{
	public sealed class Rectangle
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Width: " + Width + " Height: " + Height;
        }

        public int[] CheckPoints(List<Point> points)
        {
            var inRect = 0;
            var outRect = 0;

            foreach (var point in points)
            {
                if (point.X >= X && point.X <= X + Width && point.Y >= Y && point.Y <= Y + Height)
                {
                    inRect++;
                    continue;
                }

                outRect++;
            }

            return new[] {inRect, outRect};
        }
    }
}
