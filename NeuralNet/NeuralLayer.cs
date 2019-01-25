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
        List<double[]> m_Weight = new List<double[]>();
        List<double> m_d = null;
       
        public void AddWeights(double[] w)
        {
            m_Weight.Add(w);
        }

        public double[] GetWeights(int layer)
        {
            return m_Weight[layer];
        }

        public int NeuronCount => (m_Weight != null) ? m_Weight[0].Length : 0;

        public int LayerSize => (m_Weight != null) ? m_Weight.Count : 0;

        public List<double[]> Weights => m_Weight;

        public void InitializeDiff()
        {
            m_d = new List<double>(m_Weight[0].Length);
        }

        public List<double> D
        {
            get { return m_d; }
            set { m_d = value; }
        }
    }
}
