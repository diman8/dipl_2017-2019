using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace dipl_01
{
    class ShuffleProblem : IProblem
    {
        public int[][] problem;
        public ISolution best_solution;
        public int[] solution;
        public int result;

        private Dictionary<BigInteger, int> memento;

        public ShuffleProblem()
        {
            memento = new Dictionary<BigInteger, int>();
        }

        public void ClearMemento()
        {
            memento = new Dictionary<BigInteger, int>();
        }

        public ISolution GetBestSol()
        {
            return best_solution;
        }

        public void SetBestSol(ISolution sol)
        {
            this.best_solution = sol;
        }

        public int GetSize()
        {
            return problem.Length;
        }

        public int GetEvalCount()
        {
            return memento.Count;
        }

        public int Eval(ISolution solution)
        {
            int tmp;
            if (!memento.TryGetValue(solution.GetId(), out tmp))
            {
                tmp = DirectEval(solution);
                memento.Add(solution.GetId(), tmp);
            }
            return tmp;
        }

        private int DirectEval(ISolution solution)
        {
            int[] sol = solution.GetVec();
            
            // rearrange of cols in table
            int[][] temp_table = new int[this.problem.Length][];
            for (int i = 0; i < temp_table.Length; i++)
            {
                temp_table[i] = this.problem[sol[i]-1];
            }

            // create a table of min start time for each work on each machine
            int[,] btable = new int[this.problem.Length, this.problem[0].Length];

            // calc that table
            for (int j = 1; j < this.problem[0].Length; j++)
            {
                btable[0, j] = btable[0, j - 1] + temp_table[0][j - 1];
            }

	        for (int i = 1; i<this.problem.Length; i++)
	        {
		        for (int j = 0; j<this.problem[0].Length; j++)
		        {
			        if (j == 0)
			        {
				        btable[i,j] = btable[i - 1,j] + temp_table[i - 1][j];
			        }
			        else
			        {
				        btable[i,j] = btable[i - 1,j] + temp_table[i - 1][j];
				        int temp = btable[i,j - 1] + temp_table[i][j - 1];
				        if (btable[i,j] < temp)
					        btable[i,j] = temp;
			        }
		        }
	        }
            
            int max = btable[this.problem.Length - 1,0] + temp_table[this.problem.Length - 1][0];
            for (int j = 1; j < this.problem[0].Length; j++)
            {
                int temp = btable[this.problem.Length - 1,j] + temp_table[this.problem.Length - 1][j];
                if (temp > max) max = temp;
            }
            return max;
        }

        public string Print()
        {
            string temp = "";
            //temp += "Table:\n";
            //for (int i=0; i<problem.Length; i++)
            //{
            //    for (int j = 0; j < problem[0].Length; j++)
            //    {
            //        temp += problem[i][j] + " ";
            //    }
            //    temp += "\n";
            //}
            //temp += "Solution:\n";
            //ISolution a = new Solution(solution);
            //temp += a.Print() + "\n";
            temp += "Result precalc:" + result + "\n";
            return temp;
        }

        public string SolPrint(ISolution sol)
        {
            string text = sol.Print() + " " + Eval(sol);
            return text;
        }
    }
}
