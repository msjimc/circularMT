using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circularMT
{
    internal class featureSorter : IComparer<feature>
    {
        int IComparer<feature>.Compare(feature x, feature y)
        {            
            return x.StartPoint - y.StartPoint;
        }
    }
}
