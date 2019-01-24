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
       
        public void AddWeights(double[] w)
        {
            m_Weight.Add(w);
        }

        public double[] GetWeights(int layer)
        {
            return m_Weight[layer];
        }

        public IEnumerator GetEnumerator()
        {
            return m_Weight.GetEnumerator();
        }

        public int LayerSize => (m_Weight != null) ? m_Weight.Count : 0;
    }
}
