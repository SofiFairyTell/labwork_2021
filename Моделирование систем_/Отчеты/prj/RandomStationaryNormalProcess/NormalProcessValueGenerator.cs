using RandomNumberGenerator;
using System.Collections.Generic;
using System.Linq;

namespace RandomStationaryNormalProcess
{
    public class NormalProcessValueGenerator
    {
        private List<double> q;
        private readonly double[] C;
        private readonly double M;
        private readonly Generator Generator = new Generator();

        public NormalProcessValueGenerator(double[] C, double min, double max)
        {
            this.C = C;
            M = (max + min) / 2;
            q = new List<double>();
            for (var i = 0; i < C.Length; i++)
            {
                q.Add(Generator.NormalDistributionFunction(1, 0));
            }
        }

        private void ShiftQ()
        {
            q = q.Skip(1).ToList();
            q.Add(Generator.NormalDistributionFunction(1, 0));
        }

        public double GetNextValue() 
        {
            var value = Enumerable.Range(0, C.Length).Select(i => C[i] * q[i]).Sum() + M;
            ShiftQ();

            return value;
        }
    }
}
