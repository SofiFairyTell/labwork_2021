using RandomStationaryNormalProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using RandomNumberGeneratorTest;

namespace RandomStationaryNormalProcessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Генерируется совокупность значений стационарного случайного процесса q
            var generator = new NormalProcessValueGenerator(
                new double[] { 0.036, 0.084, 0.228, 0.619 },
                2, 6);
            var N = 1000;
            var a = new List<double>();//значение на четных шагах модельного времени
            var b = new List<double>();//значение на нечетных шагах модельного времени

            List<ValuesList> res = new List<ValuesList>();
            var writer = new Writer();

            for (var i = 0; i < N * 2; ++i)
            {
                if (i % 2 == 0)
                {
                    var chet = generator.GetNextValue();
                    a.Add(chet);
                    res.Add(new ValuesList()
                    {
                        achet = chet
                    });
                }
                else
                {
                    var nechet = generator.GetNextValue();
                    b.Add(nechet);
                    res.Add(new ValuesList()
                    {
                        bnechet = nechet
                    });
                }

            }
            writer.WriterRandom(res);
            var student = new CounterStudent();
            var studentCriterion = student.StudentCriterion(a, b,N);
        }
    }
    public class CounterStudent
    {
        public double StudentCriterion(List<double> a, List<double> b, int N)
        {
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
            double studentCriterion = Math.Sqrt((Math.Pow(aM - bM, 2) * N * N) / (D * N * 2));
            var beta = N + N - 2;
            ConsoleLog(a, b, aM, bM, aD, bD, D, studentCriterion,beta);
            return studentCriterion;
        }

        public void ConsoleLog(List<double> a, List<double> b, double aM, double bM, double aD, double bD, double D, double studentCriterion, double beta)
        {
            Console.WriteLine($"Фрагмент чётных сгенерированных значений - [{string.Join(", ", a.Take(50))}]");
            Console.WriteLine($"Фрагмент нечётных сгенерированных значений - [{string.Join(", ", b.Take(50))}]");
            Console.WriteLine($"Параметры для расчета Критерия согласия Стьюдента");
            Console.WriteLine($"m'x - {aM}");
            Console.WriteLine($"m''y - {bM}");
            Console.WriteLine($"Dx - {aD}");
            Console.WriteLine($"Dy - {bD}");
            Console.WriteLine($"D - {D}");
            Console.WriteLine($"Степеней свободы - {beta}");
            Console.WriteLine($"Критерий Стьюдента - {studentCriterion}");
            _ = Console.ReadKey();
        }
    }

}
