using CsvHelper;
using RandomNumberGenerator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RandomNumberGeneratorTest
{
    class Program
    {
        static double GetPirson(IEnumerable<double> values, Func<double, double> f, int m)
        {
            var valuesCount = values.Count();
            var a = values.Min();
            var b = values.Max();
            var step = (b - a) / m;
            var res = 0d;
            for (var t = a; t < b; t+=step)
            {
                var integralValue = DefiniteIntegral.CentralRectangle(f, t, t + step, 100);
                var statistiсValue = (double)values.Count(x => t < x && x < (t + step)) / valuesCount;
                res += Math.Pow(statistiсValue - integralValue, 2) / integralValue;
            }

            return res * valuesCount;
        }

        static void Main()
        {
            var generator = new Generator();
            var res = new List<GeneratorValue>();
            for (int i = 0; i < 2000; ++i)
            {
                res.Add(new GeneratorValue()
                {
                    ExponentialValue = generator.ExponentialDistributionFunction(0.1),
                    Normal1Value = generator.NormalDistributionFunction(1.5, 10),
                    Normal2Value = generator.NormalDistributionFunction(3, 33)
                });
            }

            using (var streamReader = new StreamWriter("GeneratorTest.csv"))
            {
                using (var csvReader = new CsvWriter(streamReader, new CultureInfo("ru-RU")))
                {
                    csvReader.Configuration.Delimiter = ";";
                    csvReader.WriteRecords(res);
                }
            }

            var exponentialPirson = GetPirson(res.Select(x => x.ExponentialValue), x => 0.1 * Math.Exp(-0.1 * x), 10);
            var normal1Pirson = GetPirson(res.Select(x => x.Normal1Value), x => (1 / (1.5 * Math.Sqrt(2 * Math.PI))) * Math.Exp(-Math.Pow(x - 10, 2) /( Math.Pow((2*1.5),2))), 10);
            var normal2Pirson = GetPirson(res.Select(x => x.Normal2Value), x => (1 / (3 * Math.Sqrt(2 * Math.PI))) * Math.Exp(-Math.Pow(x - 33, 2) /( Math.Pow((2*3),2))), 33);
            Console.WriteLine($"Значения критериев согласия \n Показательная величина - {exponentialPirson} \n Нормальная величина 1 - {normal1Pirson}"
                + $"\n Нормальная величина 2 - {normal2Pirson} \n");
            _ = Console.ReadKey();
        } 
        


    }   
    public class Writer
        {
        public void WriterLog(List<LogTable> res)
        {
            using (var streamReader = new StreamWriter("LogTest.csv"))
            {
                using (var csvReader = new CsvWriter(streamReader, new CultureInfo("ru-RU")))
                {
                    csvReader.Configuration.Delimiter = ";";
                    csvReader.WriteRecords(res);
                }
            }
        }
        }
}
