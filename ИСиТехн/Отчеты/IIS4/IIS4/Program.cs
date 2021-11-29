using System;
using System.Collections.Generic;
using System.Linq;

namespace IIS4
{
    class Program
    {
        static void Main()
        {
            FirstTest();
            SecondTest();
            _ = Console.ReadKey();
        }

        static void FirstTest()
        {
            Console.WriteLine("Первое задание ");
            var neuron = new Neuron(9);
            var set = new List<(int[] question, int answer)>
            {
                (
                //цифра 4
                    new int[]
                    {
                            1, -1, 1,
                            1, 1, 1,
                            -1,-1, 1
                    },
                    1
                ),
                (
                //цифра 1
                    new int[]
                    {
                        -1, -1, 1,
                        -1, -1, 1,
                        -1, -1, 1,
                    },
                    -1
                )
            };
            neuron.Training(set);
            var res = neuron.AskQuestion(new int[]
                {
                    1, -1, 1,
                    1, 1, 1,
                    -1, -1, 1
                });
            Console.WriteLine($"4: { res }");
            res = neuron.AskQuestion(new int[]
                {
                    -1, -1, 1,
                    -1, -1, 1,
                    -1, -1, 1
                });
            Console.WriteLine($"1: { res }");
        }

        static void SecondTest()
        {
            Console.WriteLine("Второе задание ");
            var neuralNetwork = new NeuralNetwork(25, 4);
            var set = new List<(int[] question, int[] answer)>
            {
                (
                //буква С
                    new int[]
                    {
                        -1, 1,  1,  1, 1,
                        -1, 1, -1, -1, -1,
                        -1, 1, -1, -1, -1,
                        -1, 1, -1, -1, -1,
                        -1, 1,  1,  1,  1
                    },
                    new int[]{ 1, -1, -1, -1}
                ),
                (
                 //буква С другой вариант
                    new int[]
                    {
                        1, 1,  1,  1,  1,
                        1, 1, -1, -1, -1,
                        1, 1, -1, -1, -1,
                        1, 1, -1, -1, -1,
                        1, 1,  1,  1,  1
                    },
                    new int[]{ 1, -1, -1, -1}
                ),
                (//буква у
                    new int[]
                    {
                        -1, 1, -1, -1, 1,
                        -1, -1, 1, -1, 1,
                        -1, -1, -1, 1, -1,
                        -1, -1, -1, 1, -1,
                        -1, 1, 1, -1, -1,
                    },
                    new int[]{ -1, 1, -1, -1}
                ),
                (//буква у другой вариант
                    new int[]
                    {
                        -1, 1, -1, -1, 1,
                        -1, -1, 1, -1, 1,
                        -1, -1, -1, 1, -1,
                        -1, -1, -1, 1, -1,
                        -1, 1, 1, -1, -1,
                    },
                    new int[]{ -1, 1, -1, -1}
                ),
                (//буква Р первый вариант
                    new int[]
                    {
                        -1, 1,  1,  1,  1,
                        -1, 1, -1, -1,  1,
                        -1, 1,  1,  1,  1,
                        -1, 1, -1, -1, -1,
                        -1, 1, -1, -1, -1,
                    },
                    new int[]{ -1, -1, 1, -1}
                ),
                (//буква Р второй вариант
                    new int[]
                    {
                        1, 1,  1,  1,  1,
                        1, 1, -1, -1,  1,
                        1, 1,  1,  1,  1,
                        1, 1, -1, -1, -1,
                        1, 1, -1, -1, -1,
                    },
                    new int[]{ -1, -1, 1, -1}
                ),
                (
                    new int[]
                    {
                        -1, 1, -1, -1, 1,
                        -1, 1, -1, 1, -1,
                        -1, 1, 1, -1, -1,
                        -1, 1, -1, 1, -1,
                        -1, 1, -1, -1, 1,
                    },
                    new int[]{ -1, -1, -1, 1}
                ),
                (
                    new int[]
                    {
                        -1, 1, -1, -1, 1,
                        -1, 1, -1, 1, -1,
                        -1, 1, 1, 1, -1,
                        -1, 1, -1, 1, -1,
                        -1, 1, -1, -1, 1,
                    },
                    new int[]{ -1, -1, -1, 1}
                ),
                (
                    new int[]
                    {
                        -1, -1, -1, -1, -1,
                        -1, -1, -1, -1, -1,
                        -1, -1, -1, -1, -1,
                        -1, -1, -1, -1, -1,
                        -1, -1, -1, -1, -1,
                    },
                    new int[]{ -1, -1, -1, -1}
                ),
            };

            neuralNetwork.Training(set);
            var values = set.Select(x => x.question).ToList();

            var res = neuralNetwork.AskQuestion(values[0]);
            Console.WriteLine($"С (1) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[1]);
            Console.WriteLine($"С (2) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[2]);
            Console.WriteLine($"У (1) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[3]);
            Console.WriteLine($"У (2) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[4]);
            Console.WriteLine($"Р (1) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[5]);
            Console.WriteLine($"Р (2) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[6]);
            Console.WriteLine($"К (1) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[7]);
            Console.WriteLine($"К (2) : [{ string.Join(", ", res) }]");
            res = neuralNetwork.AskQuestion(values[8]);
            Console.WriteLine($"Б  : [{ string.Join(", ", res) }]");
        }
    }
}
