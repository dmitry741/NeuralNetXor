using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetLib;
using NeuralNet.Base;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVectorDot()
        {
            List<double> w = new List<double>() { 1, -1, 2 };
            List<double> x = new List<double>() { 10, 20, 30 };

            Assert.IsTrue(VectorCore.Dot(w, x) == 50);
        }

        [TestMethod]
        public void TestDistance()
        {
            double[] x = new double[] { 1, 0, 2 };
            double[] y = new double[] { 0, 1, 0 };

            Assert.IsTrue(Math.Abs(VectorCore.Distance(x, y) - Math.Sqrt(6)) < 0.0001);
        }

        bool ComparePredictAndTest(INeuralNet net, List<double[]> X, List<double> y, double epsilon)
        {
            bool result = true;

            for (int i = 0; i < X.Count; i++)
            {
                double[] predict = net.FeedForward(X[i].ToList());

                if (Math.Abs(predict[0] - y[i]) > epsilon)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        [TestMethod]
        public void TestNetParty()
        {
            // 101 -> 0.559715469842
            // 010 -> 0.459870459392
            // 110 -> 0.475649243525

            List<double[]> X = new List<double[]>
            {
                new double[] { 1, 0, 1 },
                new double[] { 0, 1, 0 },
                new double[] { 1, 1, 0 }
            };            

            List<double> y = new List<double>() { 0.56, 0.46, 0.48 };

            Assert.IsTrue(ComparePredictAndTest(NetSet.PartyNet, X, y, 0.01));
        }

        [TestMethod]
        public void TestXorNet()
        {
            List<double[]> X = new List<double[]>
            {
                new double[] { 0, 0, 1 },
                new double[] { 0, 1, 1 },
                new double[] { 1, 0, 1 },
                new double[] { 1, 1, 1 }
            };

            List<double> y = new List<double>() { 0, 1, 1, 0 };

            Assert.IsTrue(ComparePredictAndTest(NetSet.XorNet, X, y, 0.001));
        }
    }
}
