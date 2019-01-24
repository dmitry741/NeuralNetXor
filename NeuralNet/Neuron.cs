using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetLib
{
    public class Neuron
    {
        List<double> m_weights = null;

        public Neuron()
        {
            m_weights = new List<double>();
        }

        public Neuron(List<double> w)
        {
            m_weights = new List<double>(w);
        }

        public List<double> Weights => m_weights;
    }
}
