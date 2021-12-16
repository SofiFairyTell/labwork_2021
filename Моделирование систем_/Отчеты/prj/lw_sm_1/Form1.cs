using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RandomNumberGeneratorTest;
using RandomNumberGenerator;
using RandomStationaryNormalProcessTest;

using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace lw_sm_1
{
    public partial class Form1 : Form
    {       
        readonly Timer tmr = new Timer();
        #region Значения детерминированной СМО
        //счетчик канала
        public static int min = 0, signalCounter = 0, OutSignalCounter = 0;
        public static bool Visible = false;
        public int experiments = 0;
        //для детерминированной СМО
        public static double t0 = 0, N = 3, t1 = 10, t2 = 10, t3 = 33, Ecapcity = 4, detT = 10;
        //Локальное время обработки
        public static double arivTime = 0, prepTime = 0, checkTime = 0, prepTimeComp = 0, prepSignal = 0, lostSignal=0;
        public static string MESSAGE = "";
        public static bool ExperimentMode=false;
        public static int Experiment = 0;
        public static int ExpNum = 0;
        public static bool stop = false;
        #endregion

        #region Значения для стохастической СМО
        public static double lambda = 0.1;
        public static double m1 = 1.5;
        public static double m2 = 3;
        public static double sigma1 = 10;
        public static double sigma2 = 33;
        #endregion

        #region Графика
        //Для координат
        private int StartX = 0;
        private readonly int StartY = 0;
        private int SignalWidth = 0;
        private int SignalHeight = 0;
        private static int Delay = 40;
        #endregion

        #region Списки для записей и выводов
        public static List<comp> compList = new List<comp>();
        public static List<LogTable> res = new List<LogTable>();
        public static List<ResultLine> resultLine = new List<ResultLine>();
        public static List<ResultLineExtend> resultExtend= new List<ResultLineExtend>();
        #endregion
        public Form1()
        {
            InitializeComponent();
            tmr.Interval = 10;
            tmr.Tick += new EventHandler(tmr_Tick);
            route.Text = signalCounter.ToString();
            StartX = 16;
            StartY = 151;
            SignalWidth = 36;
            SignalHeight = 36;
            tbT1.Text = "10";
            tbT2.Text = "10";
            tbT3.Text = "33";
            tbEpsilon.Text = "3";
            tbNumComp.Text = "3";
            tbNumSignal.Text = "1000";
            tbEcapcity.Text = "4";
            tbSpeed.Scroll += tbSpeed_Scroll;
        }
        #region Графическое отображение перемещения сигналов
        private void SignalMovement()
        {
                if (signal.Location.X < 62)
                {
                    SlideLeft();
                }
                else
                {
                    if (signal.Location.X >= 65 && (signal.Location.Y >= 150) && signal.Location.X < 366)
                    {
                        ChangeBox(Color.Gold);
                        switch (min)
                        {
                            case 0:
                                while (signal.Location.Y >= 50)
                                {
                                    SlideUp();
                                }
                                while (signal.Location.X <= 366)
                                {
                                    SlideLeft();
                                }
                            break;
                                
                            case 1:
                                while (signal.Location.X <= 366)
                                {
                                    SlideLeft();
                                }
                            break;
                            case 2:
                                while (signal.Location.Y <260)
                                {
                                    SlideDown();
                                }
                                while (signal.Location.X <= 366)
                                {
                                    SlideLeft();
                                }
                                break;
                            default:
                            break;
                        }
                    }
                    else
                        {
                            SlideStart();
                        }
                }
        }
        private void SlideLeft()
        {
            signal.Location = new Point(signal.Location.X + 50, signal.Location.Y);
            Task.Delay(Delay).Wait();
        }
        private void SlideUp()
        {
            signal.Location = new Point(signal.Location.X, signal.Location.Y - 50);
            Task.Delay(Delay).Wait();
        }
        private void SlideDown()
        {
            signal.Location = new Point(signal.Location.X, signal.Location.Y + 50);
            Task.Delay(Delay).Wait();
        }
        private void SlideStart()
        {
            signal.Location = new Point(StartX, StartY);
            signal.Width = SignalWidth;
            signal.Height = SignalHeight;
            signal.BackColor = Color.Maroon;
            Task.Delay(Delay).Wait();
        }
        private void ChangeBox(Color color)
        {
            signal.BackColor = color;
            signal.Width = Convert.ToInt32(SignalWidth / 1.5);
            signal.Height = Convert.ToInt32(SignalHeight / 1.5);
        }
        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            if (tbSpeed.Value >= 20)
            {
                // Delay = 100;
                detT = 30;
            }
            else
            {
                if ((tbSpeed.Value >= 10) || (tbSpeed.Value <= 20))
                {
                    //Delay = 50;
                    detT = 20;
                }
                else
                {
                    if ((tbSpeed.Value >= 0) || (tbSpeed.Value <= 10))
                    {
                        detT = 10;
                        // Delay = 10;
                    }
                }
            }
        }
        private void tbSpeed_Scroll2(object sender, EventArgs e)
        {
            if (tbSpeed.Value >= 20)
            {
                //Delay = 100;
                detT = 30;
            }
            else
            {
                if ((tbSpeed.Value >= 10) || (tbSpeed.Value <= 20))
                {
                    // Delay = 50;
                    detT = 20;
                }
                else
                {
                    if ((tbSpeed.Value >= 0) || (tbSpeed.Value <= 10))
                    {
                        //Delay = 10;
                        detT = 10;
                    }
                }

            }
        }

        #endregion

        #region Случайности
        private static void Generate()
        {
            var generator = new Generator();
            t1 = generator.ExponentialDistributionFunction(lambda);
            t2 = generator.NormalDistributionFunction(m1, sigma1);
            t3 = generator.NormalDistributionFunction(m2, sigma2);
        }
        private static void Generate(double la,double mat1,double mat2)//,double lambda, double sig1,double sig2)
        {
            var generator = new Generator();
            t1 = generator.ExponentialDistributionFunction(la);
            
            t2 = generator.NormalDistributionFunction(mat1, sigma1);
            t3 = generator.NormalDistributionFunction(mat2, sigma2);

        }
        private static void GenerateStationary()
        {
            var generator = new RandomStationaryNormalProcess.NormalProcessValueGenerator(
                new double[] { 0.036, 0.084, 0.228, 0.619 },
                2, 6);
            Ecapcity = Math.Round(generator.GetNextValue(), MidpointRounding.ToEven);
        }

        private static void GenerateStationary(double e1, double e2)
        {
            var generator = new RandomStationaryNormalProcess.NormalProcessValueGenerator(
                new double[] { 0.036, 0.084, 0.228, 0.619 },
                e2-1.0, e2);
           // Ecapcity = Math.Round(generator.GetNextValue(), MidpointRounding.ToEven);
            Ecapcity = Math.Round(generator.GetNextValue());
        }
        #endregion

        #region Галочки для случайностей
        private void cbRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRandom.Checked)
            {
                //сформируем стартовые значения
                Generate();
                tbT1.Text = t1.ToString("F" + tbEpsilon.Text.Trim());
                tbT2.Text = t2.ToString("F" + tbEpsilon.Text.Trim());
                tbT3.Text = t3.ToString("F" + tbEpsilon.Text.Trim());
            }
            else
            {
                tbT1.Text = Convert.ToString(10);
                tbT2.Text = Convert.ToString(10);
                tbT3.Text = Convert.ToString(33);
            }

        }
        private void cbRandomEcapcity_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRandomEcapacity.Checked)
            {
                GenerateStationary();

                tbEcapcity.Text = Ecapcity.ToString("F" + 0);
            }
            else
            {
                //Ecapcity = 4;
                tbEcapcity.Text = Convert.ToString(4);
            }
        }
        #endregion

//Выводы в таблицы и файлы и на экран
        private void LogAdd()
        {
            logTable.Rows.Add(Convert.ToString(t0), "", "", Convert.ToString(prepTimeComp),
                   Convert.ToString(min), Convert.ToString(compList[min].capacity), Convert.ToString(prepSignal), MESSAGE);
        }
        private static void TableAdd()
        {
            res.Add(new LogTable()
            {
                T0 = t0,
                prepTimeComp = prepTimeComp,
                minComp = min,
                capacity = compList[min].capacity,
                prepSignal = prepSignal,
                message = MESSAGE
            });
        }

        private async void StatData()
        {          
            var waitPosition = compList[0].capacity + compList[1].capacity + compList[2].capacity;
        
            var lost = LostSignalChance();
            var wait = WaitSignalChance();
            var speed = SpeedSignalProcessing();

            lbAllCapacity.Text = waitPosition.ToString();

            SystemOutputText();
            SystemProductivityText(lost,wait,speed);
        }
        private void SystemOutputText()
        {
            lbSignalCounter.Text = signalCounter.ToString();
            lbPrepSignal.Text = prepSignal.ToString();
            lbOuterSignal.Text = OutSignalCounter.ToString();
            lbLostSignal.Text = lostSignal.ToString();
        }

        private void SystemProductivityText(int LostSignalChance, int WaitSignalChance, double SpeedSignalProcessing)
        {
            lbPSignal.Text = LostSignalChance.ToString("F" + tbEpsilon.Text.Trim()) + "%";
            lbWait.Text = WaitSignalChance.ToString("F" + tbEpsilon.Text.Trim()) + "%"; //Вероятность ожидания в очереди сигнала
            lbProd.Text = "Обработано " + SpeedSignalProcessing.ToString("F" + tbEpsilon.Text.Trim()) + " сигналов в секунду ";
        }
        #region Функции для расчета показателей производительности системы

        public static int LostSignalChance()
        {
            var LostSignalChance = (lostSignal / signalCounter) * 100;
            if (LostSignalChance > 100)
            {
                LostSignalChance = 100;
            }
            return (int)LostSignalChance;
        }

        public static int WaitSignalChance()
        {
            var waitPosition = compList[0].capacity + compList[1].capacity + compList[2].capacity;
            var WaitSignalChance = 100 * ((signalCounter - waitPosition) / signalCounter);
            if (WaitSignalChance > 100)
            {
                WaitSignalChance = 100;
            }
            return (int)WaitSignalChance;
        }

        public static double SpeedSignalProcessing()
        {
            var SpeedSignalProcessing = (prepSignal / signalCounter)/t0;
            return SpeedSignalProcessing;
        }

        #endregion
        #region Активности и вычисления
        private static void AK1()
        {
            arivTime = t0;
            signalCounter++;
            MESSAGE = "Прием сигнала";
            Task.Delay(Delay).Wait();
        }
        private static void AK2()
        {
            checkTime += t2;//для фиксации общего времени проверки в канале
            prepTime = t0;
            OutSignalCounter++;//считаем количесво исходящих сигналов
            MESSAGE = "Обработка в канале";
            //Определим где наименьшая очередь
            min = MinPC();
            Task.Delay(Delay).Wait();
        }
        private static int MinPC()
        {
            int locMin = 0;
            //Определим где наименьшая очередь
            for (int i = 0; i < compList.Count(); i++)
            {
                if (compList[min].capacity > compList[i].capacity)
                {
                    locMin = i;
                }
            }
            return locMin;
        }


        private static void AK3()
        {
            MESSAGE = "Обработка в ЭВМ";
            if ((compList[min].in_work == false) && (compList[min].capacity >= 0))
            {
                prepTimeComp = t0;
                prepSignal++;
                if (compList[min].capacity > 0)
                {
                    compList[min].capacity--;
                    Visible = false;
                }
            }
            else
            {
                if ((compList[min].in_work == true) && (compList[min].capacity < Ecapcity))
                {
                    compList[min].capacity++;
                    Visible = true;
                }
                else
                {
                    if ((compList[min].in_work == true) || (compList[min].capacity >= Ecapcity))
                    {
                        //lostSignal = OutSignalCounter - prepSignal;
                        lostSignal++;
                    }
                }
            }
            Task.Delay(Delay).Wait();
        }
        #endregion

        public void Count()
        {
            for (; prepSignal <= Convert.ToDouble(tbNumSignal.Text.Trim()); t0 += detT)
            {
                if (cbRandom.Checked)
                {
                    Generate();
                }
                if (cbRandomEcapacity.Checked)
                {
                    GenerateStationary();
                }

                if ((t0 - arivTime) > t1)
                {
                    AK1();//выполнение первого действия
                    TableAdd();
                }
                if ((t0 - prepTime) > t2)
                {
                    AK2();//выполнение обработки в канале
                    TableAdd();
                    //LogAdd();
                }
                if ((t0 - prepTimeComp) > t3)
                {
                    compList[min].in_work = false;
                    AK3();
                    TableAdd();
                    // LogAdd();
                }
                else
                {
                    compList[min].in_work = true;
                    AK3(); //обработка в ПК
                     //LogAdd();
                    TableAdd();
                }
            }
        }

        public static void CountExperiment(double NumPrepSignal,bool RandomTCheck, bool RandomEcapCheck,
            double mat1, double mat2, double E, double la)//double lamb, , double sig1, double sig2)
        {
            for (; prepSignal <= NumPrepSignal; t0 += detT)
            {
                if (RandomTCheck == true || RandomEcapCheck == true)
                {
                    Generate( la, mat1, mat2);//lamb,,sig1,sig2);
                    GenerateStationary(E,E);
                }               

                if ((t0 - arivTime) > t1)
                {
                    AK1();//выполнение первого действия
                    TableAdd();
                }
                if ((t0 - prepTime) > t2)
                {
                    AK2();//выполнение обработки в канале
                    TableAdd();
                    //LogAdd();
                }
                if ((t0 - prepTimeComp) > t3)
                {
                    compList[min].in_work = false;
                    AK3();
                    TableAdd();
                    // LogAdd();
                }
                else
                {
                    compList[min].in_work = true;
                    AK3(); //обработка в ПК
                           //LogAdd();
                    TableAdd();
                }
            }
        }



        static ResultLine Work(double NumPrepSignal, double la,double mat1, double mat2, double E)//double lamb,, double sig1, double sig2)
        {
            CountExperiment(NumPrepSignal, true, true, mat1, mat2, E,la);//lamb, , sig1, sig2);          
            return new ResultLine(la, mat1, mat2, E, lostSignal,t1,t2,t3);
        }
        static ResultLineExtend WorkExt(double NumPrepSignal, double la, double mat1, double mat2, double E)//double lamb,, double sig1, double sig2)
        {
            CountExperiment(NumPrepSignal, true, true, mat1, mat2, E, la);//lamb, , sig1, sig2);
            var l = LostSignalChance();
            var w = WaitSignalChance();
            var s = SpeedSignalProcessing();
            return new ResultLineExtend
            {
                ParamID = ExpNum++,
                X1 = la, 
                X2 = mat1, 
                X3 = mat2, 
                X4 = (int)E, 
                T1 = t1,
                T2 = t2,
                T3 = t3,
                L = l,
                W = w,
                S = s
            };
        }

        #region Общее
        private void NullEverything()
    {
        signalCounter = 0;
        t0 = 0;
        arivTime = 0;
        prepTime = 0;
        checkTime = 0;
        prepTimeComp = 0;
        prepSignal = 0;
        OutSignalCounter = 0;
        lostSignal = 0;
    }
    private void ConvertTo(double t1, double t2, double t3)
    {
        t1 = Convert.ToDouble(tbT1.Text.Trim());
        t2 = Convert.ToDouble(tbT2.Text.Trim());
        t3 = Convert.ToDouble(tbT3.Text.Trim());
    }
    private void ConvertTo(int t1, int t2, int t3)
    {
        lbComp1.Text = Convert.ToString(t1);
        lbComp2.Text = Convert.ToString(t2);
        lbComp3.Text = Convert.ToString(t2);
    }
    #endregion

        #region Кнопочки для запуска
        private void btnExperiment_Click(object sender, EventArgs e)
        {
            ExperimentMode = true;
            
            if (tmr.Enabled == false)
            {
                tmr.Enabled = true; //старт/стоп
                ExperimentParams();
                SLAUwriter();
            }
            else
            {
                tmr.Enabled = false; //старт/стоп
            }

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            NullEverything();
            if (tmr.Enabled == false)
            {
                if (!cbRandom.Checked)
                {
                    ConvertTo(t1, t2, t3);
                }
                if (!cbRandomEcapacity.Checked)
                {
                    Ecapcity = Convert.ToDouble(tbEcapcity.Text.Trim());
                }

                tmr.Enabled = true; //старт/стоп

                for (int i = 0; i < Convert.ToDouble(tbNumComp.Text.Trim()); i++)
                {
                    compList.Add(new comp());
                }
                ConvertTo(compList[0].capacity,compList[1].capacity,compList[2].capacity);

                Task.Run(() =>
                {
                    Count();
                });
            }
            else
            {
                tmr.Enabled = false; //старт/стоп
            }

        }

        private void btOp_Click(object sender, EventArgs e)
        {
            //количество опытов которые будут сгенерированны с учетом того,
            //что внутри ExperimentParamsCycle уже будет два значения возвращено
            for (var exp = 0; exp < Convert.ToInt16(tbEXP.Text.Trim()); exp++)
            {
                //tmr.Enabled = true; //старт/стоп
                ExperimentParamsCycle(false);

                //tmr.Enabled = false; //старт/стоп
            }
            SLAUwriter();
        }
        private void btnParettoOPT_Click(object sender, EventArgs e)
        {
            for (var exp = 0; exp < Convert.ToInt16(tbEXP.Text.Trim()); exp++)
            {

                //tmr.Enabled = true; //старт/стоп
                ExperimentParamsCycle(true);

                //tmr.Enabled = false; //старт/стоп
            }
            var writer = new Writer();
            writer.WriterResultLine(resultExtend, "OutputEXT.csv");
            GetPareto(resultExtend);
            writer.WriterResultLine(resultExtend, "OutputParreto.csv");
        }

    #endregion
    public void ExperimentParamsCycle(bool extend)
        {
            compList.Clear();
            for (int i = 0; i < Convert.ToDouble(tbNumComp.Text.Trim()); i++)
            {
                compList.Add(new comp());
            }
            var numSignal = Convert.ToDouble(tbNumSignal.Text.Trim());
            NullEverything();
            var rnd = new Random();
            foreach (var la1 in Enumerable.Range(1, 2).OrderBy(x => rnd.Next()).Take(1))
                {
                    foreach (var mat1 in Enumerable.Range(1, 2).OrderBy(x => rnd.Next()).Take(1))
                    {
                       foreach(var mat2 in Enumerable.Range(2,3).OrderBy(x=>rnd.Next()).Take(1))
                       {    
                            foreach (var E in Enumerable.Range(1, 2).OrderBy(x => rnd.Next()).Take(1))
                            {
                                if (extend)
                                {
                                    ExpEXT(la1, mat1, mat2, E, numSignal);
                                }
                                else
                                {
                                    Exp(la1, mat1, mat2, E, numSignal);
                                }
                                
                            }
                       }
                    }
                }
            if (extend == false)
            {
                var writer = new Writer();
                writer.WriterResultLine(resultLine);
            }
            else
            {
                //var writer = new Writer();
                //writer.WriterResultLine(resultExtend, "OutputEXT.csv");
                //GetPareto(resultExtend);
                //writer.WriterResultLine(resultExtend, "OutputParreto.csv");
            }
        }

    public void ExperimentParams()
    {
        compList.Clear();
        logTable.Rows.Clear();
        if (!cbRandom.Checked)
        {
            ConvertTo(t1, t2, t3);
        }
        if (!cbRandomEcapacity.Checked)
        {
            Ecapcity = Convert.ToDouble(tbEcapcity.Text.Trim());
        }
        for (int i = 0; i < Convert.ToDouble(tbNumComp.Text.Trim()); i++)
        {
            compList.Add(new comp());
        }

        var numSignal = Convert.ToDouble(tbNumSignal.Text.Trim());
        NullEverything();
        Task.Run(() =>
        {
            //for (var la1 = 0.1; la1 < 0.5; la1 += 0.4)
            //{
            //    for (var E = 2; E <= 3; E++)
            //    {
            //            for (var mat1 = 0.9; mat1 < 1.6; mat1 += 0.7)
            //            {
            //                for (var mat2 = 2.5; mat2 <= 3; mat2 += 0.5)
            //                {
            //                    Exp(la1, mat1, mat2, E, numSignal);
            //                }
            //            }
            //        }
            //}
            var rnd = new Random();
            foreach (var la1 in Enumerable.Range(1, 2).OrderBy(x => rnd.Next()).Take(1))
            {
                foreach (var mat1 in Enumerable.Range(1, 2).OrderBy(x => rnd.Next()).Take(1))
                {
                    foreach (var mat2 in Enumerable.Range(2, 3).OrderBy(x => rnd.Next()).Take(1))
                    {
                        foreach (var E in Enumerable.Range(1, 2).OrderBy(x => rnd.Next()).Take(1))
                        {
                            Exp(la1, mat1, mat2, E, numSignal);
                        }
                    }
                }
            }
            var writer = new Writer();
            writer.WriterResultLine(resultLine);
        });

    }

    public void SLAUwriter()
    {

        var Slau = new SLAULine
        {
            a0 = Experiment,
            a1 = resultLine.Select(x => x.X1).Sum(),
            a2 = resultLine.Select(x => x.X2).Sum(),
            a3 = resultLine.Select(x => x.X3).Sum(),
            a4 = resultLine.Select(x => x.X4).Sum(),
            b = resultLine.Select(x => x.Y).Sum()
        };
        var Slau1 = new SLAULine
        {
            a0 = resultLine.Select(x => x.X1).Sum(),
            a1 = resultLine.Select(x => x.X1 * x.X1).Sum(),
            a2 = resultLine.Select(x => x.X2 * x.X1).Sum(),
            a3 = resultLine.Select(x => x.X3 * x.X1).Sum(),
            a4 = resultLine.Select(x => x.X4 * x.X1).Sum(),
            b = resultLine.Select(x => x.Y * x.X1).Sum(),
        };

        var Slau2 = new SLAULine
        {
            a0 = resultLine.Select(x => x.X2).Sum(),
            a1 = resultLine.Select(x => x.X1 * x.X2).Sum(),
            a2 = resultLine.Select(x => x.X2 * x.X2).Sum(),
            a3 = resultLine.Select(x => x.X3 * x.X2).Sum(),
            a4 = resultLine.Select(x => x.X4 * x.X2).Sum(),
            b = resultLine.Select(x => x.Y * x.X2).Sum(),
        };

        var Slau3 = new SLAULine
        {
            a0 = resultLine.Select(x => x.X3).Sum(),
            a1 = resultLine.Select(x => x.X1 * x.X3).Sum(),
            a2 = resultLine.Select(x => x.X2 * x.X3).Sum(),
            a3 = resultLine.Select(x => x.X3 * x.X3).Sum(),
            a4 = resultLine.Select(x => x.X4 * x.X3).Sum(),
            b = resultLine.Select(x => x.Y * x.X3).Sum(),
        };

        var Slau4 = new SLAULine
        {
            a0 = resultLine.Select(x => x.X4).Sum(),
            a1 = resultLine.Select(x => x.X1 * x.X4).Sum(),
            a2 = resultLine.Select(x => x.X2 * x.X4).Sum(),
            a3 = resultLine.Select(x => x.X3 * x.X4).Sum(),
            a4 = resultLine.Select(x => x.X4 * x.X4).Sum(),
            b = resultLine.Select(x => x.Y * x.X4).Sum(),
        };
        var SLAU = new List<SLAULine>
                    {
                    Slau, Slau1, Slau2, Slau3,Slau4
                    };
        var slau = new Writer();
        slau.WriterResultLine(SLAU);
    }
    

    
    public void Exp( double la,double mat2, double mat3, double E, double numSignal)//double la1,, double sig1, double sig2)
    {

        (lambda, m1, m2, Ecapcity) = (la,mat2, mat3, E);          
        var res = Work(numSignal,la,mat2,mat3,E);
        resultLine.Add(res);
        Experiment = ++experiments;
    }

    public void ExpEXT(double la, double mat2, double mat3, double E, double numSignal)//double la1,, double sig1, double sig2)
    {

        (lambda, m1, m2, Ecapcity) = (la, mat2, mat3, E);
        var res = WorkExt(numSignal, la, mat2, mat3, E);
        resultExtend.Add(res);
        Experiment = ++experiments;
    }
        static void GetPareto(List<ResultLineExtend> ResultExtend)
    {
        var j_list= new List<int>();
        var j = ResultExtend.FirstOrDefault(); //выберем вариант j
        do
        {
            j_list.Add(j.ParamID); //добавим вариант в список

            var k = ResultExtend.FirstOrDefault(x => j.ParamID != x.ParamID && j.CompareTo(x) == -1);//для варианта k != j
            if (k != null)
            {
                    ResultExtend.Remove(j);
            }

            j = ResultExtend.FirstOrDefault(x => !j_list.Contains(x.ParamID));
        }
        while (j != null); //пока не просмотрены все варианты
    }

        async void tmr_Tick(object sender, EventArgs e)
    {        
        route.Text = signalCounter.ToString();
        lbPrepVisual.Text = prepSignal.ToString() + " / " + tbNumSignal.Text.Trim();
        lbExper.Text = Experiment.ToString();
        signal.Visible = true;
        LogAdd();

        SignalMovement();
        switch (min)
        {
            case 0:
                lbComp1.Text = Convert.ToString(compList[0].capacity);
                break;
            case 1:
                lbComp2.Text = Convert.ToString(compList[1].capacity);
                break;
            case 2:
                lbComp3.Text = Convert.ToString(compList[2].capacity);
                break;
            default:
                break;
        }

        if (prepSignal >= Convert.ToDouble(tbNumSignal.Text.Trim()))
        {                                      
            tmr.Enabled = false; //старт/стоп
            if(!ExperimentMode)
            {
                var result = res;
                var writer = new Writer();
                writer.WriterLog(result); 
            } 
            lbPrepVisual.Text = prepSignal.ToString() + " / " + tbNumSignal.Text.Trim();
            lbExperiment.Text = Experiment.ToString();
            StatData(); 
        }
            
    }

//двойная буферизация
    protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
