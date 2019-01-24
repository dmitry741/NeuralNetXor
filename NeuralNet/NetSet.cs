using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetLib
{
    public class NetSet
    {
        public static NeuralNet PartyNet
        {
            get
            {
                Neuron n11 = new Neuron(new List<double> { 0.25, 0.5 });
                Neuron n21 = new Neuron(new List<double> { 0.25, -0.4 });
                Neuron n31 = new Neuron(new List<double> { 0, 0.9 });

                Neuron n12 = new Neuron(new List<double> { -1 });
                Neuron n22 = new Neuron(new List<double> { 1 });

                NeuralLayer layer1 = new NeuralLayer();

                layer1.AddNeuron(n11);
                layer1.AddNeuron(n21);
                layer1.AddNeuron(n31);

                NeuralLayer layer2 = new NeuralLayer();

                layer2.AddNeuron(n12);
                layer2.AddNeuron(n22);

                NeuralNet net = new NeuralNet();

                net.AddLayer(layer1);
                net.AddLayer(layer2);

                return net;
            }
        }

        public static NeuralNet XorNet
        {
            get
            {
                Neuron n11 = new Neuron(new List<double> { 20, 20, 0 });
                Neuron n21 = new Neuron(new List<double> { 20, 20, 0 });
                Neuron n31 = new Neuron(new List<double> { -30, -10, 0 });

                Neuron n12 = new Neuron(new List<double> { -60 });
                Neuron n22 = new Neuron(new List<double> { 60 });
                Neuron n23 = new Neuron(new List<double> { -30 });

                NeuralLayer layer1 = new NeuralLayer();

                layer1.AddNeuron(n11);
                layer1.AddNeuron(n21);
                layer1.AddNeuron(n31);

                NeuralLayer layer2 = new NeuralLayer();

                layer2.AddNeuron(n12);
                layer2.AddNeuron(n22);
                layer2.AddNeuron(n23);

                NeuralNet net = new NeuralNet();

                net.AddLayer(layer1);
                net.AddLayer(layer2);

                return net;
            }
        }
    }
}
