using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dipl_01
{
    interface IAlgorithm
    {
        void Init(IProblem prb);
        List<ISolution> Neibours(ISolution sol);
        //List<ISolution> BuildPath(ISolution one, ISolution two);
        int Distance(ISolution one, ISolution two);
        ISolution HillClimbing(ISolution sol);
        IProblem GetProblem();
        List<ISolution> GenerateInitial();
        List<ISolution> Mutate(List<ISolution> lst);
        ISolution Cross(List<ISolution> lst);
    }
}
