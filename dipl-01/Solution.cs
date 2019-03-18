using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace dipl_01
{
    class Solution : ISolution
    {
        private BigInteger id;
        private int[] vector;

        public Solution(int[] sol)
        {
            //this.vector = sol;
            this.vector = new int[sol.Length];
            Array.Copy(sol, this.vector, sol.Length);
            int[] temp = new int[sol.Length];
            Array.Copy(sol, temp, sol.Length);
            
            //calc size
            for (int i = 1; i < temp.Length; i++)
            {
                int minus_counter = 0;
                for (int pos = 0; pos < temp.Length; pos++)
                {
                    if (vector[pos] == i)
                    {
                        id += (pos - minus_counter) * MyMath.Factorial(temp.Length - i);
                        temp[pos] = -1;
                        break;
                    }
                    else if (temp[pos] == -1)
                    {
                        minus_counter++;
                    }
                }
            }
        }

        public Solution(BigInteger id, int size)
        {
            this.id = id;
            this.vector = new int[size];
            for (int i = 0; i < this.vector.Length; i++)
            {
                this.vector[i] = -1;
            }
            BigInteger index = this.id;
            for (int i = this.vector.Length; i > 0; i--)
            {
                BigInteger f = MyMath.Factorial(i - 1);
                int pos = (int) (index / f);
                index = index % f;
                InsInPos(this.vector, pos, this.vector.Length - (i - 1));
            }
        }

        static private void InsInPos(int[] vector, int pos, int num)
        {
            int i = 0;
            while (true)
            {
                if (vector[i] == -1)
                {
                    pos--;
                    if (pos == -1)
                    {
                        vector[i] = num;
                        return;
                    }
                }
                i++;
            }
        }

        public int[] GetVec()
        {
            return vector;
        }

        public BigInteger GetId()
        {
            return id;
        }

        public int GetSize()
        {
            return this.vector.Length;
        }

        public string Print()
        {
            string text = "[ ";
            for (int i = 0; i < this.vector.Length; i++)
            {
                text += this.vector[i] + " ";
            }
            text += "]";
            return text;
        }

        public int CompareTo(object sol2)
        {
            return CalculationManager.GetInstance().alg.GetProblem().Eval(this).CompareTo(
                CalculationManager.GetInstance().alg.GetProblem().Eval(sol2 as ISolution));            
        }
    }
}
