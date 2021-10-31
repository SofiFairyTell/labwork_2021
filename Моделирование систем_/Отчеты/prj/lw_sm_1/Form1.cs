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
        readonly Timer tmr = new Timer();
        //счетчик канала
        int min = 0, signalCounter = 0, OutSignalCounter = 0;
        bool Visible = false;
        //для детерминированной СМО
        double t0 = 0, N = 3, t1 = 10, t2 = 10, t3 = 33, Е = 4, detT = 10;
        //Локальное время обработки
        double arivTime = 0, prepTime = 0, checkTime = 0, prepTimeComp = 0, prepSignal = 0, lostSignal=0;

        //Для координат
        private int StartX = 0;
        private readonly int StartY = 0;

        public Form1()
        {
            InitializeComponent();
            tmr.Interval = 10;
            tmr.Tick += new EventHandler(tmr_Tick);
            route.Text = signalCounter.ToString();
            StartX = signal.Location.X;
            StartY = signal.Location.Y;
            tbT1.Text = "10";
            tbT2.Text = "10";
            tbT3.Text = "33";
            tbEpsilon.Text = "3";
            tbNumComp.Text = "3";
            tbNumSignal.Text = "1000";

        }

        private async void DrawSignal()
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
                if (signal.Location.X < 100)
                {
                    SlideLeft();
                }
                else
                {
                    if ((signal.Location.X >= 100)&&(signal.Location.X < 150))
                    {
                        
                        SlideUp();
                    }
                }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            signalCounter = 0;
            t0 = 0;
            arivTime = 0; prepTime = 0; checkTime = 0; prepTimeComp = 0; prepSignal = 0; OutSignalCounter = 0;lostSignal = 0;

            if (tmr.Enabled==false)
            {
                t1 = Convert.ToDouble(tbT1.Text.Trim());
                t2 = Convert.ToDouble(tbT2.Text.Trim());
                t3 = Convert.ToDouble(tbT3.Text.Trim());
                tmr.Enabled = true; //старт/стоп
                compList.Clear();
                for (int i = 0; i < Convert.ToDouble(tbNumComp.Text.Trim()); i++)
                {
                    compList.Add(new comp());
                }
                 lbComp1.Text = Convert.ToString(compList[0].capacity); 
                 lbComp2.Text = Convert.ToString(compList[1].capacity); 
                 lbComp3.Text = Convert.ToString(compList[2].capacity); 

                Task.Run(() =>
                    {
                        Count();
                        //DrawSignal();
                    });
            }
            else
            {
                tmr.Enabled = false; //старт/стоп
                //StatData();
            }
           
        }

        private void SlideLeft()
        {
            signal.Location = new Point(signal.Location.X + 50, signal.Location.Y);
            Task.Delay(50).Wait();
        }
        private void SlideUp()
        {
            signal.Location = new Point(signal.Location.X, signal.Location.Y - 50);
            Task.Delay(40).Wait();
        }
        private void AK1()
        {
            arivTime = t0;
            signalCounter++;
            Task.Delay(40).Wait();
        }
        private void AK2()
        {
            checkTime += t2;//для фиксации общего времени проверки в канале
            prepTime = t0;
            OutSignalCounter++;//считаем количесво исходящих сигналов

            //Определим где наименьшая очередь
            for (int i = 0; i < compList.Count(); i++)
            {
                if(compList[min].capacity >compList[i].capacity)
                {
                    min = i;
                }
            }             

            Task.Delay(40).Wait();
        }

        private void AK3()
        {
            
            if ((compList[min].in_work == false)&&(compList[min].capacity>=0))
            {
                prepTimeComp = t0;
                prepSignal++;
                if(compList[min].capacity >0)
                {
                    compList[min].capacity--;
                    Visible = false;
                }            
            }
            else
            {
                if((compList[min].in_work == true)&&(compList[min].capacity<4))
                {
                    compList[min].capacity++;
                    Visible = true;
                }
                else
                {
                    if ((compList[min].in_work == true) && (compList[min].capacity == 4))
                    {
                        lostSignal++;
                    }
                }
            }
 
            Task.Delay(40).Wait();
        }

        private void Count()
        {
                for (; prepSignal <= Convert.ToDouble(tbNumSignal.Text.Trim()); t0 += detT)
                {
                   
                    if ((t0 - arivTime) > t1)
                    {
                        AK1();//выполнение первого действия
                    }
                    if ((t0- prepTime)>t2)
                    {
                        AK2();//выполнение обработки в канале
                    }
                    if ((t0 - prepTimeComp) > t3)
                    {
                       compList[min].in_work = false;
                       AK3();
                    }
                    else
                    {
                        compList[min].in_work = true;
                        AK3(); //обработка в ПК                       
                    }
                }
        } 

         async void tmr_Tick(object sender, EventArgs e)
        {
            route.Text = signalCounter.ToString();
            signal.Visible = false;
            //signalRoute.Visible = false;
            if ((t0 - arivTime) == t1)
            {
                logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(arivTime),
                    " ", " ", " ", " ", " ", "Прием сигнала");
                signal.Visible = true;
            }
            if ((t0 - prepTime) > t2)
            {
                logTable.Rows.Add(Convert.ToString(t0), " ",
                Convert.ToString(prepTime), " ", " ", " ", " ", "Обработка в канале");
                signal.Visible = false;
            }
            if ((t0 - prepTimeComp) > t3)
            {
                logTable.Rows.Add(Convert.ToString(t0), "", "", Convert.ToString(prepTimeComp),
                Convert.ToString(min), Convert.ToString(compList[min].capacity), Convert.ToString(prepSignal), "Обработка в ЭВМ");
            }
           // SignalMovement();
            switch (min)
            {
                case 0:
                    lbComp1.Text = Convert.ToString(compList[0].capacity);
                    signalRoute.Visible = Visible;
                    signalRoute1.Visible = Visible;
                    signalRoute2.Visible = Visible;
                    signalRoutePC2_1.Visible = false;
                    signalRoutePC2_2.Visible = false;
                    signalRoutePC2_3.Visible = false;
                    signalRoutePC3_1.Visible = false;
                    signalRoutePC3_2.Visible = false;
                    signalRoutePC3_3.Visible = false;
                    signalPC1.Visible = Visible;
                    signalPC2.Visible = false;
                    signalPC3.Visible = false;
                    break;
                case 1:
                    lbComp2.Text = Convert.ToString(compList[1].capacity);
                    signalRoute.Visible = false;
                    signalRoute1.Visible = false;
                    signalRoute2.Visible = false;
                    signalRoutePC2_1.Visible = Visible;
                    signalRoutePC2_2.Visible = Visible;
                    signalRoutePC2_3.Visible = Visible;
                    signalRoutePC3_1.Visible = false;
                    signalRoutePC3_2.Visible = false;
                    signalRoutePC3_3.Visible = false;
                    signalPC1.Visible = false;
                    signalPC2.Visible = Visible;
                    signalPC3.Visible = false; 
                    break;
                case 2:
                    lbComp3.Text = Convert.ToString(compList[2].capacity);
                    signalRoute.Visible = false;
                    signalRoute1.Visible = false;
                    signalRoute2.Visible = false;
                    signalRoutePC2_1.Visible = false;
                    signalRoutePC2_2.Visible = false;
                    signalRoutePC2_3.Visible = false;
                    signalRoutePC3_1.Visible = Visible;
                    signalRoutePC3_2.Visible = Visible;
                    signalRoutePC3_3.Visible = Visible;
                    signalPC1.Visible = false;
                    signalPC2.Visible = false;
                    signalPC3.Visible = Visible; 
                    break;
                default:
                    break;
            }
            if (prepSignal == Convert.ToDouble(tbNumSignal.Text.Trim()))
            {
                tmr.Enabled = false; //старт/стоп
                StatData();
            }
        }

        private async void StatData()
        {
            lbSignalCounter.Text = signalCounter.ToString();
            lbPrepSignal.Text = prepSignal.ToString();
            lbOuterSignal.Text = OutSignalCounter.ToString();
            lbLostSignal.Text = lostSignal.ToString();
            lbAllCapacity.Text = (signalCounter - prepSignal).ToString();
            lbPSignal.Text = ((lostSignal / signalCounter) * 100).ToString("F" + tbEpsilon.Text.Trim()) + "%";
            lbWait.Text = (((signalCounter - prepSignal) / signalCounter) * 100).ToString("F" + tbEpsilon.Text.Trim()) + "%";
            lbProd.Text = "Обработано " + ((prepSignal / signalCounter) / t0).ToString("F" + tbEpsilon.Text.Trim()) + " сигналов в секунду ";
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
