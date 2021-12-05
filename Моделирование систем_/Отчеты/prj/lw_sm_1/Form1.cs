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


namespace lw_sm_1
{
    public partial class Form1 : Form
    {       
        readonly Timer tmr = new Timer();
        #region Значения детерминированной СМО
        //счетчик канала
        int min = 0, signalCounter = 0, OutSignalCounter = 0;
        bool Visible = false;
        //для детерминированной СМО
        public static double t0 = 0, N = 3, t1 = 10, t2 = 10, t3 = 33, Ecapcity = 4, detT = 10;
        //Локальное время обработки
        public static double arivTime = 0, prepTime = 0, checkTime = 0, prepTimeComp = 0, prepSignal = 0, lostSignal=0;
        string MESSAGE = "";
        #endregion
      
        #region Графика
        //Для координат
        private int StartX = 0;
        private readonly int StartY = 0;
        private int SignalWidth = 0;
        private int SignalHeight = 0;
        private int Delay = 40;
        #endregion

        #region Списки для записей и выводов
        public static List<comp> compList = new List<comp>();
        List<LogTable> res = new List<LogTable>();
        List<ResultLine> resultLine = new List<ResultLine>();
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
        private void Generate()
        {
            var generator = new Generator();
            t1 = generator.ExponentialDistributionFunction(0.1);
            t2 = generator.NormalDistributionFunction(1.5, 10);
            t3 = generator.NormalDistributionFunction(3, 33);
        }
        private void GenerateStationary()
        {
            var generator = new RandomStationaryNormalProcess.NormalProcessValueGenerator(
                new double[] { 0.036, 0.084, 0.228, 0.619 },
                2, 6);
            Ecapcity = Math.Round(generator.GetNextValue(), MidpointRounding.ToEven);
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

        #region Выводы в таблицы и файлы и на экран
        private void LogAdd()
        {
            logTable.Rows.Add(Convert.ToString(t0), "", "", Convert.ToString(prepTimeComp),
                   Convert.ToString(min), Convert.ToString(compList[min].capacity), Convert.ToString(prepSignal), MESSAGE);
        }
        private void TableAdd()
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

        private void ResultLineAdd()
        {

        }
        private async void StatData()
        {
            lbSignalCounter.Text = signalCounter.ToString();
            lbPrepSignal.Text = prepSignal.ToString();
            lbOuterSignal.Text = OutSignalCounter.ToString();
            lbLostSignal.Text = lostSignal.ToString();
            var waitPosition = compList[0].capacity + compList[1].capacity + compList[2].capacity;
            lbAllCapacity.Text = waitPosition.ToString();
            var lost = (lostSignal / signalCounter) * 100;
            if (lost > 100)
            {
                lost = 100;
            }
            lbPSignal.Text = lost.ToString("F" + tbEpsilon.Text.Trim()) + "%";
            //Вероятность ожидания в очереди сигнала
            var wait = 100 * ((signalCounter - waitPosition) / signalCounter);
            if (wait > 100)
            {
                wait = 100;
            }
            lbWait.Text = wait.ToString("F" + tbEpsilon.Text.Trim()) + "%";
            lbProd.Text = "Обработано " + ((prepSignal / signalCounter) / t0).ToString("F" + tbEpsilon.Text.Trim()) + " сигналов в секунду ";
        }
        #endregion

        #region Активности и вычисления
        private void AK1()
        {
            arivTime = t0;
            signalCounter++;
            MESSAGE = "Прием сигнала";
            Task.Delay(Delay).Wait();
        }
        private void AK2()
        {
            checkTime += t2;//для фиксации общего времени проверки в канале
            prepTime = t0;
            OutSignalCounter++;//считаем количесво исходящих сигналов
            MESSAGE = "Обработка в канале";
            //Определим где наименьшая очередь
            min = MinPC();
            Task.Delay(Delay).Wait();
        }
        private int MinPC()
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
        private void AK3()
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

        private static void Count()
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

        static ResultLine Work()
        {
            Count();
            return new ResultLine(t1, t2, t3, Ecapcity, prepSignal);
        }
        #endregion

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
            compList.Clear();
            res.Clear();
            logTable.Rows.Clear();
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

        private void btnExperiment_Click(object sender, EventArgs e)
        {
            
            if (tmr.Enabled == false)
            {
                tmr.Enabled = true; //старт/стоп
                NullEverything();
                for (int i = 0; i < Convert.ToDouble(tbNumComp.Text.Trim()); i++)
                {
                    compList.Add(new comp());
                }
                ConvertTo(compList[0].capacity, compList[1].capacity, compList[2].capacity);

                Task.Run(() =>
                {
                    //Count();
                    var res = Work();
                    resultLine.Add(res);
                });
            }
            else
            {
                tmr.Enabled = false; //старт/стоп
            }

        }

        #endregion


        async void tmr_Tick(object sender, EventArgs e)
        {        
            route.Text = signalCounter.ToString();
            lbPrepVisual.Text = prepSignal.ToString() + " / " + tbNumSignal.Text.Trim();
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
                var writer = new Writer();
                writer.WriterLog(res);
                lbPrepVisual.Text = prepSignal.ToString() + " / " + tbNumSignal.Text.Trim();
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
