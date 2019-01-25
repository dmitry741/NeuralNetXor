using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetLib;
using NeuralNet.Base;

// Developed by Dmitry Pavlov. email: dmitrypavlov74@gmail.com.
// under GitHub since 24 January 2019.

namespace NeuralNetXor
{
    class Program
    {
        static void Main(string[] args)
        {
            INeuralNet net = NetSet.XorNet;

            List<double[]> X = new List<double[]>
            {
                new double[] { 0, 0, 1 },
                new double[] { 0, 1, 1 },
                new double[] { 1, 0, 1 },
                new double[] { 1, 1, 1 }
            };

            foreach (double[] xin in X)
            {
                double[] result = net.FeedForward(xin.ToList());
                Console.WriteLine(string.Format("{0} {1}, xor: {2}", xin[0], xin[1], Math.Round(result[0], 3)));
            }

            List<double[]> y = new List<double[]>
            {
                new double[] { 0 },
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 0 }
            };

            //net.Fit(X, y);

            Console.ReadLine();
        }
    }
}
