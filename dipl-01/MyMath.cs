using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace dipl_01
{
    class MyMath
    {
        private static Random random = new Random();

        static private Dictionary<int, BigInteger> memento = new Dictionary<int, BigInteger>();
        
        static public BigInteger Factorial(int input)
        {
            BigInteger tmp;
            if (!memento.TryGetValue(input, out tmp))
            {
                tmp = TrueFactorial(input);
                memento.Add(input, tmp);
            }
            return tmp;
        }

        static public BigInteger TrueFactorial(int i)
        {
            switch(i)
            {
                case 0:
                    return 1;
                case 1:
                    return 1;
                default:
                    return i*Factorial(i-1);
            }
        }

        public static BigInteger RandomIntegerBelow(BigInteger N)
        {
            byte[] bytes = N.ToByteArray();
            BigInteger R;
            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F; //force sign bit to positive
                R = new BigInteger(bytes);
            } while (R >= N);

            return R;
        }
    }
}
