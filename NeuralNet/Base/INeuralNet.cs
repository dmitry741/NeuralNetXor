using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Base
{
    public interface INeuralNet
    {
        double FeedForward(List<double> X);
    }
}
