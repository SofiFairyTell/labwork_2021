using System;

namespace RandomNumberGenerator
{
    public class Generator
    {
        private readonly Random ExponentialRandom = new Random();

        private readonly Random NormalRandom = new Random();

        public double ExponentialDistributionFunction(double lambda) 
            => -(1 / lambda) * Math.Log(ExponentialRandom.NextDouble());

        public double NormalDistributionFunction(double sigma, double m) 
            => (sigma * Math.Cos(2 * Math.PI * NormalRandom.NextDouble())
                * Math.Sqrt(-2 * Math.Log(NormalRandom.NextDouble()))) + m;
    }
}
