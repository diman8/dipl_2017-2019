using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dipl_01
{
    class BestDiplomAlgorithm : DiplomAlgorithm
    {
        public BestDiplomAlgorithm(int size) : base(size) { }

        override public List<ISolution> ListSuspicious(List<ISolution> heap)
        {
            ISolution tmp = null; int crit = int.MaxValue;
            List<ISolution> heap2 = new List<ISolution>();
            if (heap.Count > 3)
            {
                for (int i = 1; i < heap.Count - 1; i++)
                {
                    if (GetProblem().Eval(heap[i]) < GetProblem().Eval(heap[i - 1]) &&
                        GetProblem().Eval(heap[i]) < GetProblem().Eval(heap[i + 1]))
                    {
                        if (GetProblem().Eval(heap[i]) < crit) tmp = heap[i];
                        i++;
                    }
                }
            }
            if (tmp != null)
                heap2.Add(tmp);
            return heap2;
        }
    }
}
