using System.Collections.Generic;
using System.Linq;

namespace IIS4
{
    public class NeuralNetwork
    {
        private Neuron[] Neurons;

        public NeuralNetwork(int entranceCount, int neuronCount)
        {
            Neurons = Enumerable.Range(0, neuronCount)
                .Select(_ => new Neuron(entranceCount))
                .ToArray();
        }

        public int[] AskQuestion(int[] question) 
            => Neurons.Select(x => x.AskQuestion(question)).ToArray();

        public void Training(List<(int[] question, int[] answers)> tuples)
        {
            var countGoodAnswer = 0;
            while (countGoodAnswer < tuples.Count())
            {
                countGoodAnswer = 0;
                for (var i = 0; i < tuples.Count(); ++i)
                {
                    var tuple = tuples[i];
                    var countGoodAnswerForNeuron = 0;
                    var answers = AskQuestion(tuple.question);
                    for (var j = 0; j < Neurons.Count(); ++j)
                    {
                        if (answers[j] == tuple.answers[j])
                        {
                            countGoodAnswerForNeuron++;
                        }
                        else
                        {
                            Neurons[j].RecountEntrancesWeights((tuple.question, tuple.answers[j]));
                        }
                    }

                    if (countGoodAnswerForNeuron == Neurons.Count())
                    {
                        ++countGoodAnswer;
                    }
                }
            }
        }
    }
}
