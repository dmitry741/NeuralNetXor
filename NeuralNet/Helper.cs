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
    }
}
