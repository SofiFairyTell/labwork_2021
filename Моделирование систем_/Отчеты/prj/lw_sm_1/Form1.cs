﻿using System;
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
            //do
            //{
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
            //} while (signal.Location.Y >= 50);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
           // DrawSignal();
            signalCounter = 0;
            t0 = 0;
            arivTime = 0; prepTime = 0; checkTime = 0; prepTimeComp = 0; prepSignal = 0; OutSignalCounter = 0;lostSignal = 0;

            if (tmr.Enabled==false)
            {
                t1 = Convert.ToDouble(tbT1.Text.Trim());
                t2 = Convert.ToDouble(tbT2.Text.Trim());
                t3 = Convert.ToDouble(tbT3.Text.Trim());
                tmr.Enabled = true; //старт/стоп       
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
                //compList[min].in_work = true;
                if(compList[min].capacity >0)
                {
                    compList[min].capacity--;
                }            
            }
            else
            {
                if((compList[min].in_work == true)&&(compList[min].capacity<4))
                {
                    compList[min].capacity++;
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
            //DrawSignal();
            route.Text = signalCounter.ToString();
            
            if ((t0 - arivTime) == t1)
            {
                logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(arivTime),
                    " ", " ", " ", " ", " ", "Прием сигнала");
            }
            if ((t0 - prepTime) > t2)
            {
                logTable.Rows.Add(Convert.ToString(t0), " ",
                Convert.ToString(prepTime), " ", " ", " ", " ", "Обработка в канале");
            }
            if ((t0 - prepTimeComp) > t3)
            {
                logTable.Rows.Add(Convert.ToString(t0), "", "", Convert.ToString(prepTimeComp),
                Convert.ToString(min), Convert.ToString(compList[min].capacity), Convert.ToString(prepSignal), "Обработка в ЭВМ");
            }
            SignalMovement();
            switch (min)
            {
                case 0:
                    lbComp1.Text = Convert.ToString(compList[0].capacity); break;
                case 1:
                    lbComp2.Text = Convert.ToString(compList[1].capacity); break;
                case 2:
                    lbComp3.Text = Convert.ToString(compList[2].capacity); break;
                default:
                    break;
            }
            if (prepSignal == Convert.ToDouble(tbNumSignal.Text.Trim()))
            {
                //signalCounter = 0;
                tmr.Enabled = false; //старт/стоп
                lbSignalCounter.Text = signalCounter.ToString();
                lbPrepSignal.Text = prepSignal.ToString();
                lbOuterSignal.Text = OutSignalCounter.ToString();
                lbLostSignal.Text = lostSignal.ToString();
                lbAllCapacity.Text = (signalCounter - prepSignal).ToString();
                lbProd.Text = "Обработано "+ ((prepSignal / signalCounter)/ t0).ToString() + " сигналов в секунду ";
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
