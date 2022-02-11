using System;

namespace RandomNumberGeneratorTest
{
    public static class DefiniteIntegral
    {
        public static double CentralRectangle(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 0; i < n; i++)
            {
                var x = a + i / 2d * h;
                sum += f(x);
            }

            var result = h * sum;
            return result;
        }
    }
}
