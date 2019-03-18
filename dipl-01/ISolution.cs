using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Numerics;

namespace dipl_01
{
    interface ISolution : IComparable
    {
        int[] GetVec();
        BigInteger GetId();
        int GetSize();
        string Print();
    }
}
