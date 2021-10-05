using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lw_sm_1
{
    public partial class Form1 : Form
    {
        public static List<comp> compList = new List<comp>();

        Timer tmr = new Timer();
        int sign = 1;
        //счетчик канала
        int min = 0, max = 10, signalCounter = 0, OutSignalCounter = 0;
        //для компьютеров
        private bool emptyComp = true;
        //для детерминированной СМО
        int t0 = 0, N = 3, t1 = 10, t2 = 10, t3 = 33, Е = 4, detT = 1;
        int arivTime = 0, prepTime = 0, checkTime = 0, prepTimeComp = 0, prepSignal = 0;
        int StartX = 0, StartY = 0;
        public Form1()
        {
            InitializeComponent();
            tmr.Interval = 100;
            tmr.Tick += new EventHandler(tmr_Tick);
            route.Text = signalCounter.ToString();
            StartX = signal.Location.X;
            StartY = signal.Location.Y;
        }

        private void DrawSignal()
        {
            Bitmap mybit = new Bitmap(signal.Width, signal.Height);
            Graphics g = Graphics.FromImage(mybit);
            SolidBrush grBrush = new SolidBrush(Color.Green);
            g.FillRectangle(grBrush, 0, 0, signal.Width, signal.Height);
            g.DrawImage(mybit, StartX, StartY);
            SignalMovement();
        }

        private void SignalMovement()
        {
            do
            {
                if (signal.Location.X < 100)
                {
                    SlideLeft();
                }
                else
                {
                    if (signal.Location.X == 106)
                    {
                        SlideUp();
                    }
                }
            } while (signal.Location.Y >= 50);
            //DrawSignal();


        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            DrawSignal();
            Write();
            signalCounter = 0;
            tmr.Enabled = !tmr.Enabled; //старт/стоп       
            for (int i = 0; i < N; i++)
            {
                compList.Add(new comp());
            }
            Count();

        }

        private async void SlideLeft()
        {
            signal.Location = new Point(signal.Location.X + 50, signal.Location.Y);
        }
        private async void SlideUp()
        {
            signal.Location = new Point(signal.Location.X, signal.Location.Y - 50);
        }
        private void AK1()
        {
            arivTime = t0 + t1;
            signalCounter++;
            Task.Delay(40).Wait();
        }
        private void AK2()
        {
            checkTime = checkTime + t2;//для фиксации общего времени проверки в канале
            prepTime = t0 + t2;
            OutSignalCounter++;//считаем количесво исходящих сигналов
            Task.Delay(40).Wait();
        }

        private void AK3()
        {
            for (int i = 0; i < N; i++)
            {
                if (compList[min].capacity > compList[i].capacity)
                {
                    min = i;
                }
            }
            compList[min].capacity++; //если емкость
            prepSignal++;
            if (compList[min].capacity <= 4)
            {
                prepTimeComp = t0 + t3;
            }
            else
            {
                compList[min].capacity = 0;
            }
            Task.Delay(40).Wait();
        }
        private async void Count()
        {
                for (; prepSignal <= 1000; t0 += detT)
                {
                    route.Text = signalCounter.ToString();
                    if (t0 >= arivTime)
                    {
                        AK1();//выполнение первого действия
                        logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(arivTime),
                        " ", " ", " ", " ", "Прием сигнала");
                    }
                    if (t0 >= prepTime)
                    {
                        AK2();//выполнение обработки в канале
                        logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(arivTime),
                        Convert.ToString(prepTime), " ", " ", " ", "Обработка в канале");
                    }
                    //if (signalCounter+OutSignalCounter >0)
                    if (t0 >= prepTimeComp)
                    {
                        AK3(); //установка в очередь перед компьютером
                        logTable.Rows.Add(Convert.ToString(t0), "", "", Convert.ToString(prepTimeComp),
                        Convert.ToString(min), Convert.ToString(prepSignal), "Обработка в ЭВМ");
                    }
                }
        } 

        private async void Write()
        {
            if ((t0>=0) || (t0 <= arivTime))
            {
                logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(arivTime),
                    " ", " "," ", " ", "Прием сигнала");

            }
            else
            {
                    if ((t0 >= 0) || (prepTime>0))
                    {
                        logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(arivTime),
                            Convert.ToString(prepTime), " ", " ", " ", "Обработка в канале");
                    }
                    else
                    {
                        if ((t0 > 0) || t0 <= prepTimeComp)
                        {
                            logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(arivTime),
                                Convert.ToString(prepTime), Convert.ToString(prepTimeComp),
                                Convert.ToString(min), Convert.ToString(prepSignal), "Обработка в ЭВМ");
                        }
                    }
            }
           
           
            Task.Delay(10).Wait();
        }
        async void tmr_Tick(object sender, EventArgs e)
        {
           if(signalCounter >= 1000)
            {
              // signalCounter = 0;
               tmr.Enabled = !tmr.Enabled; //старт/стоп
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
