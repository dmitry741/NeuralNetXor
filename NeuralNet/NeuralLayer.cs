using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetLib
{
    public class NeuralLayer
    {
        List<Neuron> m_Neurons = null;

        public NeuralLayer()
        {
            m_Neurons = new List<Neuron>();
        }

        public void AddNeuron(Neuron neuron)
        {
            m_Neurons.Add(neuron);
        }

        public IEnumerator GetEnumerator()
        {
            return m_Neurons.GetEnumerator();
        }

        public List<Neuron> Neurons => m_Neurons;
    }
}
