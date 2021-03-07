using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		
        // Written by Eduard Morgun
        
        public static Rectangle FindRectangle(List<Point> points)
        {
            if (points == null || points.Count < 2)
            {
                throw new NullReferenceException("List is null");
            }

            var pointEquality = new PointEquality(); // Equals for Point
            
            var points1 = points; // copy because the out of scope changes 

            // Checking for the same coordinates
            var intersect = points.Where(p => points1.Count(i => pointEquality.Equals(p,i)) > 1);
            if (intersect.Count() > 1)
            {
                throw new ArgumentException("Identical Points");
            }

            var pointsSortX = points.OrderBy(p => p.X).ThenBy(p=> p.Y).ToList();
            var pointsSortY = points.OrderBy(p => p.Y).ThenBy(p=> p.X).ToList();

            int x, y, width, height;

            foreach (var point in pointsSortX)
            {
                Console.WriteLine(point);
            }
            
            if (points.Count == 2)
            {
                x = pointsSortX[^1].X;
                y = pointsSortX[^1].Y;
                width = 1;
                height = 1;
                return new Rectangle { X = x, Y = y, Width = width, Height = height };
            }

            if (points.Count(p => p.X == points[0].X) >= points.Count - 1)
            {
                x = pointsSortY[0].X;
                y = pointsSortY[0].Y - 1;
                width = 1;
                height = Math.Abs(Math.Abs(pointsSortY[^2].Y) - pointsSortY[0].Y) + 1;
                return new Rectangle { X = x, Y = y, Width = width, Height = height };
            }
            
            if (points.Count(p => p.Y == points[0].Y) >= points.Count - 1)
            {
                x = pointsSortX[0].X - 1;
                y = pointsSortX[0].Y;
                width = Math.Abs(Math.Abs(pointsSortX[^2].X) - pointsSortY[0].X) + 1;
                height = 1;
                return new Rectangle { X = x, Y = y, Width = width, Height = height };
            }

            if (pointsSortX[^1].X != pointsSortX[^2].X)
            {
                x = pointsSortX[0].X;
                y = pointsSortY[0].Y;
                width = Math.Abs(Math.Abs(pointsSortX[^2].X) - pointsSortX[0].X);
                height = Math.Abs(Math.Abs(pointsSortY[^1].Y) - pointsSortY[0].Y);
            }
            else if (pointsSortX[0].X != pointsSortX[1].X)
            {
                x = pointsSortX[1].X;
                y = pointsSortY[0].Y;
                width = Math.Abs(Math.Abs(pointsSortX[^1].X) - pointsSortX[1].X);
                height = Math.Abs(Math.Abs(pointsSortY[^1].Y) - pointsSortY[0].Y);
            }
            else if (pointsSortY[^1].Y != pointsSortY[^2].Y)
            {
                x = pointsSortX[0].X;
                y = pointsSortY[0].Y;
                width = Math.Abs(Math.Abs(pointsSortX[^1].X) - pointsSortX[0].X);
                height = Math.Abs(Math.Abs(pointsSortY[^2].Y) - pointsSortY[0].Y);
            }
            else if (pointsSortY[0].Y != pointsSortY[1].Y)
            {
                x = pointsSortX[0].X;
                y = pointsSortY[1].Y;
                width = Math.Abs(Math.Abs(pointsSortX[^1].X) - pointsSortX[0].X);
                height = Math.Abs(Math.Abs(pointsSortY[^1].Y) - pointsSortY[1].Y);
            }
            else
            {
                throw new ArgumentException("Invalid list");
            }

            return new Rectangle{X = x, Y = y, Width = width, Height = height};
		}
	}
}
