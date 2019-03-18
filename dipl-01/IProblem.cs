using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dipl_01
{
    interface IProblem
    {
        //List<ISolution> Neibours(ISolution sol);
        int Eval(ISolution sol);
        int GetSize();
        string Print();
        string SolPrint(ISolution sol);
        int GetEvalCount();
        ISolution GetBestSol();
        void SetBestSol(ISolution sol);
    }
}
