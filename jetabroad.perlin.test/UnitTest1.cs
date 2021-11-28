using jetabroad.perlin.Abstract;
using jetabroad.perlin.Implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace jetabroad.perlin.test
{
    [TestClass]
    public class UnitTest1
    {
        // I can only do one test since I am running out of time here lol.
        // But you should get the idea how to mock gradients and test grid class. 
        [TestMethod]
        public void TestLattice()
        {
            Grid grid = new Grid(new TestGradients().Create(), this.testHandler);
            double result = grid.Lattice(0, 0, 0,1d,2d,3d);
            Assert.AreEqual(result, 14);
        }

        private int testHandler(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    class TestGradients : IGradients
    {
        public double[] Create()
        {
            double[] gradients = new double[3];
            gradients[0] = 1;
            gradients[1] = 2;
            gradients[2] = 3;
            return gradients;
        }
    }
}
