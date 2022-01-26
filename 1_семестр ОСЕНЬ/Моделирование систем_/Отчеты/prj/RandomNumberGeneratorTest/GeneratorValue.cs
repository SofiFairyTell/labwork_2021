using CsvHelper.Configuration.Attributes;
using System.Linq;
using System;

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
        [Name("X1 (lambda)")]
        public double X1 { get; set; }

        [Name("X2 (m1)")]
        public double X2 { get; set; }

        [Name("X3 (m2)")]
        public double X3 { get; set; }

        [Name("X4 (E)")]
        public int X4 { get; set; }


        [Name("Y (lost signal)")]
        public double Y { get; set; }

        [Name("t1")]
        public double T1 { get; set; }

        [Name("t2")]
        public double T2 { get; set; }
        [Name("t3")]
        public double T3 { get; set; }

        public ResultLine(
            double x1,
            double x2,
            double x3,
            double x4,
            double y,
            double t1,
            double t2,
            double t3)
        {
            Y = y;
            X1 = x1;
            X2 = x2;
            X3 = x3;
            X4 = (int)x4;
            T1 = t1;
            T2 = t2;
            T3 = t3;
        }
    }

    public class ResultLineExtend:IComparable<ResultLineExtend>
    {
        [Name("ID (exp)")]
        public int ParamID { get; set; }
        [Name("X1 (lambda)")]
        public double X1 { get; set; }

        [Name("X2 (m1)")]
        public double X2 { get; set; }

        [Name("X3 (m2)")]
        public double X3 { get; set; }

        [Name("X4 (E)")]
        public int X4 { get; set; }

        [Name("t1")]
        public double T1 { get; set; }

        [Name("t2")]
        public double T2 { get; set; }
        [Name("t3")]
        public double T3 { get; set; }

        //Показатели работы моделируемой системы
        [Name("L% (LostSignalChance)")]
        public double L { get; set; }
        [Name("W% (WaitSignalChance)")]
        public double W { get; set; }
        [Name("S (SpeedSignalProcessing)")]
        public double S { get; set; }
        public ResultLineExtend() { }
        public ResultLineExtend(int PID,
            double x1,
            double x2,
            double x3,
            double x4,
            double t1,
            double t2,
            double t3,
            double l,
            double w,
            double s)
        {
            ParamID = PID;
            L = l;
            W = w;
            S = s;
            X1 = x1;
            X2 = x2;
            X3 = x3;
            X4 = (int)x4;
            T1 = t1;
            T2 = t2;
            T3 = t3;
        }
        public int CompareTo(ResultLineExtend resultLineExtend)
        {
            var R = new int[2];
            R[0] = L == resultLineExtend.L
                ? 0
                : L < resultLineExtend.L ? 1 : -1;
            //R[1] = W == resultLineExtend.W
            //    ? 0
            //    : W > resultLineExtend.W ? 1 : -1;
            R[1] = S == resultLineExtend.S
                ? 0
                : S > resultLineExtend.S ? 1 : -1;

            return R.All(x => x == 0)
                ? 0
                : R.All(x => x == 1 || x == 0)
                    ? 1
                    : R.All(x => x == -1 || x == 0) ? -1 : 0;
        }

    }

    public class SLAULine
    {
        [Name("a0")]
        public double a0 { get; set; }

        [Name("a1")]
        public double a1 { get; set; }

        [Name("a2")]
        public double a2 { get; set; }

        [Name("a3")]
        public double a3 { get; set; }

        [Name("a4")]
        public double a4 { get; set; }

        [Name("b")]
        public double b { get; set; }
    }
}