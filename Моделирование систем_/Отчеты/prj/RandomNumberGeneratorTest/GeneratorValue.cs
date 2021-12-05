using CsvHelper.Configuration.Attributes;

namespace RandomNumberGeneratorTest
{
    class GeneratorValue
    {
        [Name("Показательная величина")]
        public double ExponentialValue { get; set; }

        [Name("Нормальная величина 1")]
        public double Normal1Value { get; set; }

        [Name("Нормальная величина 2")]
        public double Normal2Value { get; set; }

        [Name("Нормальная величина 3")]
        public double Normal3Value { get; set; }
    }
    public class LogTable
    {
        [Name("t0")]
        public double T0 { get; set; }
        [Name("prepTimeComp")]
        public double prepTimeComp { get; set; }
        [Name("MINcomp")]
        public double minComp { get; set; }
        [Name("Capacity")]
        public double capacity { get; set; }
        [Name ("prepSignal")]
        public double prepSignal { get; set; }
        [Name ("Message")]
        public string message { get; set; }    
    }

    public class ValuesList
    {
        [Name("a-chet")]
        public double achet{ get; set; }
        [Name("b-nechet")]
        public double bnechet{ get; set; }       
    }

    public class ResultLine
    {
        [Name("X1")]
        public int X1 { get; set; }

        [Name("X2")]
        public int X2 { get; set; }

        [Name("X3")]
        public int X3 { get; set; }

        [Name("X4")]
        public int X4 { get; set; }


        [Name("Y")]
        public int Y { get; set; }

        public ResultLine(
            double x1,
            double x2,
            double x3,
            double x4,
            double y)
        {
            Y = (int)y;
            X1 = (int)x1;
            X2 = (int)x2;
            X3 = (int)x3;
            X4 = (int)x4;
        }
    }
}