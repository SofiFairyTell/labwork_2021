using System;
using System.Collections.Generic;
using System.Linq;

namespace IIS5
{
    class Program
    {
        static void Main()
        {
            var neuralNetwork = new TwoLevelNeuralNetwork(25, 3);
            var set = new List<(double[] question, double answer)>
            {
                (//буква С
                    new double[]
                    {
                        -1, 1,  1,  1,  1,
                        -1, 1, -1, -1, -1,
                        -1, 1, -1, -1, -1,
                        -1, 1, -1, -1, -1,
                        -1, 1,  1,  1,  1
                    },
                    -1
                ),
                (
                    new double[]
                    {
                        1, 1,  1,  1,  1,
                        1, 1, -1, -1, -1,
                        1, 1, -1, -1, -1,
                        1, 1, -1, -1, -1,
                        1, 1,  1,  1,  1
                    },
                    -1
                ),
                (
                    new double[]
                    {
                        1, 1,  1,  1, -1,
                        1, 1, -1, -1, -1,
                        1, 1, -1, -1, -1,
                        1, 1, -1, -1, -1,
                        1, 1,  1,  1, -1
                    },
                    -1
                ),
                (//буква У
                    new double[]
                    {
                        -1,  1, -1, -1,  1,
                        -1, -1,  1, -1,  1,
                        -1, -1, -1,  1, -1,
                        -1, -1, -1,  1, -1,
                        -1,  1,  1, -1, -1,
                    },
                    1
                ),
                (
                    new double[]
                    {
                        -1, 1, -1, -1, 1,
                        -1, -1, 1, -1, 1,
                        -1, -1, -1, 1, -1,
                        -1, -1, -1, 1, -1,
                        -1, 1, 1, -1, -1,
                    },
                    1
                ),
                (
                    new double[]
                    {
                        -1,  1, -1, -1,  1,
                        -1, -1,  1, -1,  1,
                        -1, -1, -1,  1, -1,
                        -1, -1, -1,  1, -1,
                        -1, -1,  1, -1, -1,
                    },
                    1
                )
            };

            neuralNetwork.Training(set, 40);
            var values = set.Select(x => x.question).ToList();
            var res = neuralNetwork.AskQuestion(values[0]);
            Console.WriteLine($"С (1) : [{ string.Join(", ", ResultOutput(res)) }]");
            res = neuralNetwork.AskQuestion(values[1]);
            Console.WriteLine($"С (2) : [{ string.Join(", ", ResultOutput(res)) }]");
            res = neuralNetwork.AskQuestion(values[2]);
            Console.WriteLine($"С (3) : [{ string.Join(", ", ResultOutput(res)) }]");
            res = neuralNetwork.AskQuestion(values[3]);
            Console.WriteLine($"У (1) : [{ string.Join(", ", ResultOutput(res)) }]");
            res = neuralNetwork.AskQuestion(values[4]);
            Console.WriteLine($"У (2) : [{ string.Join(", ", ResultOutput(res)) }]");
            res = neuralNetwork.AskQuestion(values[5]);
            Console.WriteLine($"У (3) : [{ string.Join(", ", ResultOutput(res)) }]");

            _ = Console.ReadKey();
        }

        static string ResultOutput(double result)
            => result < 0.5 ? "С" : "У";
    }
}
