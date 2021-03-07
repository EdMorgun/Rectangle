using System.Linq;
using Rectangle.Impl;

namespace Rectangle.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		
        static void Main(string[] args)
		{
            var points = new[] { new Point(-99, -99), new Point(-100,-100)}.ToList();
			var rectangle = Service.FindRectangle(points);

            var ss = rectangle.CheckPoints(points);
			System.Console.WriteLine(rectangle);

            System.Console.WriteLine();

            System.Console.WriteLine(ss[0] + " " + ss[1]);
            System.Console.ReadKey();
		}
	}
}
