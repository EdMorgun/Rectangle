using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}
        

		[Test]
		public void Test1()
		{
            var points = new[] { new Point(2, 2), new Point(2, -2), new Point(-2, 2), new Point(-2, -2), new Point(4, 4) }.ToList();
            var rectangle = Service.FindRectangle(points);
			var result = rectangle.CheckPoints(points);
            Assert.AreEqual(result, new[] { 4, 1 });
		}
        
        [Test]
		public void Test2()
		{
			var points = new[] { new Point(2, 2), new Point(2, -2), new Point(-2, 2), new Point(-2, -2), new Point(4, 2) }.ToList();
            var rectangle = Service.FindRectangle(points);
            var result = rectangle.CheckPoints(points);
            Assert.AreEqual(result, new[] { 4, 1 });
		} 
        
        [Test]
		public void Test3()
		{
            var points = new[] { new Point(2, 2), new Point(2, -2), new Point(-2, 2), new Point(-2, -2), new Point(2, 4) }.ToList();
            var rectangle = Service.FindRectangle(points);
            var result = rectangle.CheckPoints(points);
            Assert.AreEqual(result, new[] { points.Count - 1, 1 });
		}
		
        [Test]
		public void Test4()
		{
			var points = new[] { new Point(2, 2), new Point(2, -2), new Point(-2, 2), new Point(-2, -2), new Point(2, -4) }.ToList();
            var rectangle = Service.FindRectangle(points);
            var result = rectangle.CheckPoints(points);
			Assert.AreEqual(result, new []{ points.Count - 1, 1 });
		}

        [Test]
        public void Test5()
        {
            var points = new[] { new Point(2, 2), new Point(2, -2), new Point(-2, 2), new Point(-2, -2), new Point(-4, -4) }.ToList();
            var rectangle = Service.FindRectangle(points);
            var result = rectangle.CheckPoints(points);
            Assert.AreEqual(result, new[] { points.Count - 1, 1 });
        }

        [Test]
        public void TestInLineX()
        {
            var points = new[] { new Point(2, 2), new Point(2, -2), new Point(2, 5)}.ToList();
            var rectangle = Service.FindRectangle(points);
            var result = rectangle.CheckPoints(points);
            Assert.AreEqual(result, new[] { points.Count -1, 1 });
        }

        [Test]
        public void TestInLineY()
        {
            var points = new[] { new Point(-1, 2), new Point(5, 2), new Point(3, 2) }.ToList();
            var rectangle = Service.FindRectangle(points);
            var result = rectangle.CheckPoints(points);
            Assert.AreEqual(result, new[] { points.Count - 1, 1 });
        }

        [Test]
        public void TestFromLourency()
        {
            var points = new[] { new Point(2, 2), new Point(0, 0), new Point(2, -1), new Point(-1, -1), new Point(-2, -1) }.ToList();
            var rectangle = Service.FindRectangle(points);
            var result = rectangle.CheckPoints(points);
            Assert.AreEqual(result, new[] { points.Count - 1, 1 });
        }
    }
}