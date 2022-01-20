using System.Collections.Generic;
using System.Linq;

namespace IIS5
{
    public class TwoLevelNeuralNetwork
    { 
        private readonly Neuron[] Neurons;

        private readonly Neuron FinalNeuron;

        public TwoLevelNeuralNetwork(int entranceCount, int twoLevelCount = 2, double learningRate = 0.1)
        {
            Neurons = Enumerable.Range(0, twoLevelCount)
                .Select(_ => new Neuron(entranceCount, learningRate))
                .ToArray();
            FinalNeuron = new Neuron(twoLevelCount, learningRate);
        }

        public double AskQuestion(double[] question)
        {
            var answers = Enumerable.Range(0, Neurons.Length)
                .Select(i => Neurons[i].AskQuestion(question))
                .ToArray();

            return FinalNeuron.AskQuestion(answers);
        }

        public void Training(List<(double[] question, double answer)> tuples, int count)
        {
            for (var k = 0; k < count; k++)
            {
                foreach(var tuple in tuples)
                {
                    var answer = AskQuestion(tuple.question);
                    if ((answer > 0.5 && tuple.answer != 1) || (answer <= 0.5 && tuple.answer == 1))
                    {
                        var question = Neurons.Select(x => x.Exit).ToArray();
                        var entrancesError = FinalNeuron.RecountEntrancesWeightsByAnswer(question, tuple.answer);
                        for (var i = 0; i < Neurons.Count(); i++)
                        {
                            Neurons[i].RecountEntrancesWeightsByError(tuple.question, entrancesError[i]);
                        }
                    }
                }
            }
        }
    }
}
