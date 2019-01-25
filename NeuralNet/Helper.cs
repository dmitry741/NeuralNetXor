using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetLib
{
    public class VectorCore
    {
        public static double Dot(List<double> weights, List<double> X)
        {
            if (weights.Count != X.Count)
                throw new Exception("Weights and X arrays have different lenghts.");

            return weights.Zip(X, (a, b) => a * b).Sum();
        }

        public static double Distance(double[] A, double[] B)
        {
            if (A.Length != B.Length)
                throw new Exception("A and B vectors have different lenghts.");

            return Math.Sqrt(A.Zip(B, (a, b) => (a - b) * (a - b)).Sum());
        }

        public static double[] Diff(List<double> A, List<double> B)
        {
            if (A.Count != B.Count)
                throw new Exception("A and B vectors have different lenghts.");

            return A.Zip(B, (a, b) => a - b).ToArray();
        }
    }
}
