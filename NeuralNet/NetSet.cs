﻿using System;
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
                NeuralLayer layer1 = new NeuralLayer();

                layer1.AddWeights(new double[] { 0.25, 0.25, 0 });
                layer1.AddWeights(new double[] { 0.5, -0.4, 0.9 });

                NeuralLayer layer2 = new NeuralLayer();

                layer2.AddWeights(new double[] { -1, 1 });

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
                NeuralLayer layer1 = new NeuralLayer();

                layer1.AddWeights(new double[] { 20, 20, -30 });
                layer1.AddWeights(new double[] { 20, 20, -10 });
                layer1.AddWeights(new double[] { 0, 0, 0 });

                NeuralLayer layer2 = new NeuralLayer();

                layer2.AddWeights(new double[] { -60, 60, -30 });

                NeuralNet net = new NeuralNet();

                net.AddLayer(layer1);
                net.AddLayer(layer2);

                return net;
            }
        }
    }
}
