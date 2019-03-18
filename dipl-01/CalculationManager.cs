using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dipl_01
{
    class CalculationManager
    {
        static private CalculationManager inner_ref = null;

        public IProblem prb;
        public IAlgorithm alg;
        public List<ISolution> pool;

        private CalculationManager()
        {

        }
        static public CalculationManager GetInstance()
        {
            if (inner_ref == null)
                inner_ref = new CalculationManager();
            return inner_ref;
        }
        static public CalculationManager ScrapAndCreateNew()
        {
            inner_ref = new CalculationManager();
            return inner_ref;
        }
    }
}
