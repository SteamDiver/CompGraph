using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.D3;

namespace Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TriangleVerticesChange()
        {
            var vv = new List<Vertex>()
            {
                new Vertex(0, 0, 0),
                new Vertex(1, 1, 1),
                new Vertex(2, 2, 2),
            };

            var t = new Triangle(vv[0], vv[1], vv[2], null, null, null);

            var coordV = new MatrixVector(new double[]{1, 2, 3});
            foreach (var v in vv)
            {
                v.X = coordV.Vector[0];
                v.Y = coordV.Vector[1];
                v.Z = coordV.Vector[2];
            }

            Assert.AreNotEqual(2, t.V3.X);
        }
    }
}
