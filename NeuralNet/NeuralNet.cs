using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Base;

namespace NeuralNetLib
{
    public class NeuralNet : INeuralNet
    {
        List<NeuralLayer> m_NeuronLayers = new List<NeuralLayer>();

        public void AddLayer(NeuralLayer layer)
        {
            m_NeuronLayers.Add(layer);
        }

        #region === private ===

        static double Sigmoid(double x)
        {
            return 1.0 / (1 + Math.Exp(-x));
            //return x >= 0.5 ? 1 : 0;
        }

        static double NeuronOutput(List<double> w, List<double> x)
        {
            return Sigmoid(VectorCore.Dot(w, x));
        }

        #endregion

        public double FeedForward(List<double> X)
        {
            List<double> input = X;

            foreach (NeuralLayer layer in m_NeuronLayers)
            {
                var inputNew = layer.Weights.Select(z => NeuronOutput(z.ToList(), input));
                input = inputNew.ToList();
            }

            return input[0];
        }
    }
}
