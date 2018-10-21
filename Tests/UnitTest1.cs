using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using MyDrawing.VisualObjects;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLineNormalisation_Count()
        {
            var points1 = new List<PointF>()
            {
                new PointF(0,0),
                new PointF(2,2)
            };

            var points2 = new List<PointF>()
            {
                new PointF(0,0),
                new PointF(1,1),
                new PointF(2,2)
            };
            var line1 = new Line(points1, Color.Black, 1);
            var line2 = new Line(points2, Color.Blue, 1);

            line1.NormalizeWithNewLine(line2);
            Assert.AreEqual(3, line1.Points.Count);
        }

        [TestMethod]
        public void TestLineNormalisation2_Count()
        {
            var points1 = new List<PointF>()
            {
                new PointF(0,0),
                new PointF(2,2)
            };

            var points2 = new List<PointF>()
            {
                new PointF(0,0),
                new PointF(1,1),
                new PointF(2,2)
            };
            var line1 = new Line(points2, Color.Black, 1);
            var line2 = new Line(points1, Color.Blue, 1);

            line1.NormalizeWithNewLine(line2);
            Assert.AreEqual(2, line1.Points.Count);
        }
    }
}
