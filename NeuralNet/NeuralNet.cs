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
                int wc = layer.Neurons[0].Weights.Count;

                for (int k = 0; k < wc; k++)
                {
                    List<double> w = new List<double>();

                    for (int j = 0; j < layer.Neurons.Count; j++)
                    {
                        w.Add(layer.Neurons[j].Weights[k]);
                    }

                    double r = NeuronOutput(w, input);
                    inputNew.Add(r);
                }

                input = inputNew;
            }

            return input[0];
        }
    }
}
