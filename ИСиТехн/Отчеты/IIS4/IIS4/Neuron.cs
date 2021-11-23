using System.Collections.Generic;
using System.Linq;

namespace IIS4
{
    public class Neuron
    {
        private double[] EntranceWeights;

        private int Exit;

        public Neuron(int entranceCount)
        {
            EntranceWeights = new double[entranceCount];
        }

        public void Training(List<(int[] question, int answer)> tuples)
        {
            var countGoodAnswer = 0;
            while (countGoodAnswer < tuples.Count())
            {
                countGoodAnswer = 0;
                for (var i = 0; i < tuples.Count(); i++)
                {
                    var tuple = tuples[i];
                    Recount(tuple.question);
                    if (Exit != tuple.answer)
                    {
                        RecountEntrancesWeights(tuple);
                    }
                    else
                    {
                        countGoodAnswer++;
                    }
                }
            }
        }

        public int AskQuestion(int[] question)
        {
            Recount(question);

            return Exit;
        }

        public void RecountEntrancesWeights((int[] question, int answer) tuple)
        {
            for (var i = 0; i < tuple.question.Length; i++)
            {
                EntranceWeights[i] = EntranceWeights[i] + tuple.question[i] * tuple.answer;
            }
        }

        private void Recount(int[] question)
        {
            var sum = Enumerable.Range(0, EntranceWeights.Length)
                .Select(i => question[i] * EntranceWeights[i])
                .Sum();
            Exit = sum > 0 ? 1 : -1;
        }
    }
}
