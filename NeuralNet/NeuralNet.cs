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

        static double DiffSigmoid(double x)
        {
            double s = Sigmoid(x);
            return s * (1 - s);
        }

        static double NeuronOutput(List<double> w, List<double> x)
        {
            return Sigmoid(VectorCore.Dot(w, x));
        }

        static double Normalize(double min, double max, byte v)
        {
            return (max - min) / 255.0 * Convert.ToDouble(v) + min;
        }

        void Randomize()
        {
            Random rnd = new Random();

            foreach (NeuralLayer layer in m_NeuronLayers)
            {
                for (int i = 0; i < layer.LayerSize; i++)
                {
                    byte[] rb = new byte[layer.Weights[i].Length];
                    rnd.NextBytes(rb);
                    double[] w = rb.Select(x => Normalize(-0.5, 0.5, x)).ToArray();
                    layer.Weights[i] = w;
                }                           
            }
        }        

        #endregion

        public double[] FeedForward(List<double> X)
        {
            List<double> input = X;

            foreach (NeuralLayer layer in m_NeuronLayers)
            {
                var inputNew = layer.Weights.Select(z => NeuronOutput(z.ToList(), input));
                input = inputNew.ToList();
            }

            return input.ToArray();
        }

        public void Fit(List<double[]> X, List<double[]> y)
        {
            Randomize();

            int iterationCount = 1;
            double c_eta = 0.1;

            for (int iterator = 0; iterator < iterationCount; iterator++)
            {
                double[] X_train = X[iterator % y.Count];
                double[] y_train = y[iterator % y.Count];

                double[] predict = FeedForward(X_train.ToList());
                double[] d = VectorCore.Diff(predict.ToList(), y_train.ToList());

                m_NeuronLayers[m_NeuronLayers.Count - 1].D = d.ToList();

                for (int j = m_NeuronLayers.Count - 2; j > 0; j--)
                {                    
                    NeuralLayer layer = m_NeuronLayers[j];
                    int neuronCount = layer.NeuronCount;
                    double[] d1 = new double[neuronCount];

                    for (int s = 0; s < neuronCount; s++)
                    {
                        d1[s] = VectorCore.Dot(d.ToList(), layer.Weights[s].ToList());
                    }

                    layer.D = d1.ToList();
                    d = d1;
                }

                NeuralLayer layerZero = m_NeuronLayers[0];

                for (int s = 0; s < layerZero.NeuronCount; s++)
                {
                    
                }
            }
        }
    }
}
