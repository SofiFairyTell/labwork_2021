using System;
using System.Linq;

namespace IIS5
{
    public class Neuron
    {
        private double[] EntranceWeights;

        public double Exit;

        private readonly double LearningRate;

        public Neuron(int entranceCount, double learningRate)
        {
            var rnd = new Random();
            EntranceWeights = Enumerable.Range(0, entranceCount)
                .Select(_ => rnd.NextDouble() * 2 - 1) // [-1..1]
                .ToArray();
            LearningRate = learningRate;
        }

        public double AskQuestion(double[] question)
        {
            var sum = Enumerable.Range(0, EntranceWeights.Length)
                .Select(i => question[i] * EntranceWeights[i])
                .Sum();
            Exit = Sigmoid(sum);

            return Exit;
        }

        public double[] RecountEntrancesWeightsByAnswer(double[] question, double answer)
        {
            var error = Exit - answer;

            return RecountEntrancesWeightsByError(question, error);
        }

        public double[] RecountEntrancesWeightsByError(double[] question, double error)
        {
            var signoidDX = SigmoidDerivative(Exit);
            var weightDelta = error * signoidDX;
            EntranceWeights = Enumerable.Range(0, EntranceWeights.Length)
                .Select(i => EntranceWeights[i] - question[i] * weightDelta * LearningRate)
                .ToArray();

            return EntranceWeights.Select(x => x * weightDelta).ToArray();
        }

        private double Sigmoid(double x) 
            => 1 / (1 + Math.Exp(-x));

        private double SigmoidDerivative(double exit)
            => exit * (1 - exit);
    }
}
