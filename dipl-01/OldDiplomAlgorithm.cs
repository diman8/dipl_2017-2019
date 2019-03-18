using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dipl_01
{
    class OldDiplomAlgorithm : IAlgorithm
    {
        private IProblem prb;
        private int heap_size = 4;

        public OldDiplomAlgorithm(int _heap_size)
        {
            heap_size = _heap_size;
        }

        public void Init(IProblem prb)
        {
            this.prb = prb;
        }

        public List<ISolution> Neibours(ISolution sol)
        {
            List<ISolution> heap = new List<ISolution>();
            int temp;
            int[] solu = new int[sol.GetSize()];
            Array.Copy(sol.GetVec(), solu, solu.Length);
            for (int i=0; i < solu.Length-1; i++)
            {
                for (int j = i+1; j < solu.Length; j++)
                {
                    temp = solu[i]; solu[i] = solu[j]; solu[j] = temp;
                    heap.Add(new Solution(solu));
                    temp = solu[i]; solu[i] = solu[j]; solu[j] = temp;
                }
            }
            return heap;
        }

        public List<ISolution> BuildPath(ISolution one, ISolution two)
        {
            List<ISolution> heap = new List<ISolution>();
            if (one.GetId() != two.GetId())
            {
                int[] sol1 = new int[one.GetSize()];
                int[] sol2 = new int[two.GetSize()];
                Array.Copy(one.GetVec(), sol1, sol1.Length);
                Array.Copy(two.GetVec(), sol2, sol2.Length);
                for (int i = 0; i < sol1.Length; i++)
                {
                    if (sol1[i] != sol2[i])
                    {
                        int j, temp;
                        for (j = i; j < sol1.Length - 1; j++)
                        {
                            if (sol1[j] == sol2[i])
                                break;
                        }
                        temp = sol1[i]; sol1[i] = sol1[j]; sol1[j] = temp;
                        heap.Add(new Solution(sol1));
                    }
                }
                heap.Remove(heap[heap.Count - 1]);
            }
            return heap;
        }

        public List<ISolution> BuildPathWithEnds(ISolution one, ISolution two)
        {
            List<ISolution> heap = BuildPath(one, two);
            heap.Add(one);
            heap.Add(two);
            return heap;
        }

        public int Distance(ISolution one, ISolution two)
        {
            if (one.GetId() == two.GetId())
                return 0;
            return BuildPath(one, two).Count + 1;
        }

        public int NextStep(List<ISolution> sol)
        {
            return 0;
        }

        public List<ISolution> GenerateInitial()
        {
            List<ISolution> heap = new List<ISolution>();
            heap.Add(new Solution(0, prb.GetSize()));
            int[] temp = new int[prb.GetSize()];
            Array.Copy(heap[0].GetVec(), temp, temp.Length);
            for (int k = 0; k < (heap_size - 1); k++)
            {
                int tmp = temp[0];
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    temp[i] = temp[i + 1];
                }
                temp[temp.Length - 1] = tmp;
                heap.Add(new Solution(temp));
            }
            return heap;
        }

        public ISolution HillClimbing(ISolution sol)
        {
            int min = prb.Eval(sol);
            ISolution best = sol;
            List<ISolution> nebh = Neibours(sol);
            foreach (ISolution a in nebh)
                if (prb.Eval(a) < min) best = a;
            return best;
        }

        public List<ISolution> Mutate(List<ISolution> lst)
        {
            ISolution first = lst[0];
            for (int i=0;i<lst.Count-1;i++)
            {
                List<ISolution> path = BuildPath(lst[i], lst[i + 1]);
                foreach (ISolution a in path)
                    if (prb.Eval(a) <= prb.Eval(lst[i])) lst[i] = a;
            }
            {
                List<ISolution> path = BuildPath(lst[lst.Count-1], first);
                foreach (ISolution a in path)
                    if (prb.Eval(a) < prb.Eval(lst[lst.Count - 1])) lst[lst.Count - 1] = a;
            }
            return lst;
        }

        public ISolution Cross(List<ISolution> lst)
        {
            ISolution a = lst[0];
            for (int i=0; i<lst.Count; i++)
            {
                for (int j = i; j < lst.Count; j++)
                {
                    List<ISolution> temp = BuildPathWithEnds(lst[i], lst[j]);
                    foreach (ISolution b in temp)
                    {
                        if (prb.Eval(b) < prb.Eval(a)) a = b;
                    }
                }
            }
            return a;
        }

        public IProblem GetProblem()
        {
            return prb;
        }
    }
}
