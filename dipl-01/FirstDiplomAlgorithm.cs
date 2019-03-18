using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dipl_01
{
    class FirstDiplomAlgorithm : DiplomAlgorithm
    {
        public FirstDiplomAlgorithm(int size) : base(size) { }

        override public List<ISolution> ListSuspicious(List<ISolution> heap)
        {
            List<ISolution> heap2 = new List<ISolution>();
            if (heap.Count > 3)
            {
                for (int i = 1; i < heap.Count - 1; i++)
                {
                    if (GetProblem().Eval(heap[i]) < GetProblem().Eval(heap[i - 1]) &&
                        GetProblem().Eval(heap[i]) < GetProblem().Eval(heap[i + 1]))
                    {
                        heap2.Add(heap[i]);
                        break;
                    }
                }
            }
            return heap2;
        }
    }
}
