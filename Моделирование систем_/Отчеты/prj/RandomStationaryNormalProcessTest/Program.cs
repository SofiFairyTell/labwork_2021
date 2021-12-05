using RandomStationaryNormalProcess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomStationaryNormalProcessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new NormalProcessValueGenerator(
                new double[] { 0.904, 0.191, 6.132, 2.447 },
                40, 80);
            var N = 1000;
            var a = new List<double>();
            var b = new List<double>();
            for (var i = 0; i < N * 2; ++i)
            {
                if (i % 2 == 0)
                {
                    a.Add(generator.GetNextValue());
                }
                else
                {
                    b.Add(generator.GetNextValue());
                }
            }

            var aM = a.Sum() / N;
            var bM = b.Sum() / N;
            var aD = 0d;
            var bD = 0d;
            for (var i = 0; i < N; i++)
            {
                aD += Math.Pow(a[i] - aM, 2) / (N - 1);
                bD += Math.Pow(b[i] - bM, 2) / (N - 1);
            }

            var D = ((N - 1) * aD + (N - 1) * bD) / (N - 2);
            var studentCriterion = Math.Sqrt((Math.Pow(aM - bM, 2) * N * N) / (D * N * 2));
            Console.WriteLine($"Фрагмент чётных сгенерированных значений - [{string.Join(", ", a.Take(50))}]");
            Console.WriteLine($"Критерий Стьюдента - {studentCriterion}");
            _ = Console.ReadKey();
        }
    }
}
