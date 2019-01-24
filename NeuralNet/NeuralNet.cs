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
        List<NeuralLayer> m_NeuronLayers = null;

        public NeuralNet()
        {
            m_NeuronLayers = new List<NeuralLayer>();
        }

        public void AddLayer(NeuralLayer layer)
        {
            m_NeuronLayers.Add(layer);
        }

        #region === private ===

        double Sigmoid(double x)
        {
            return 1.0 / (1 + Math.Exp(-x));
            //return x >= 0.5 ? 1 : 0;
        }

        double NeuronOutput(List<double> w, List<double> x)
        {
            return Sigmoid(VectorCore.Dot(w, x));
        }

        #endregion

        public double FeedForward(List<double> X)
        {
            List<double> input = X;

            foreach (NeuralLayer layer in m_NeuronLayers)
            {
                List<double> inputNew = new List<double>();
                int wc = layer.LayerSize;

                for (int i = 0; i < wc; i++)
                {
                    double[] w = layer.GetWeights(i);
                    double r = NeuronOutput(w.ToList(), input);
                    inputNew.Add(r);
                }

                input = inputNew;
            }

            return input[0];
        }
    }
}
