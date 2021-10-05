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
        int t0 = 0, N = 3, t1 = 10, t2 = 10, t3 = 33, Е = 4;
        int arivTime = 0, prepTime = 0, checkTime = 0,prepTimeComp = 0, prepSignal = 0;

        public Form1()
        {
            InitializeComponent();  
            tmr.Interval = 100;          
            tmr.Tick += new EventHandler(tmr_Tick);
            route.Text = signalCounter.ToString();
        }

        private async void DrawSignal()
        {
            Bitmap mybit = new Bitmap(50, 50);
            Graphics g = Graphics.FromImage(mybit);
            SolidBrush grBrush = new SolidBrush(Color.Green);
            g.FillRectangle(grBrush,0,0, 50, 50);
            g.DrawImage(mybit,80,80);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            signalCounter = 0;
            DrawSignal();
            for (int i = 0; i < N; i++)
            {
                compList.Add(new comp());
            }
            tmr.Enabled = !tmr.Enabled; //старт/стоп          
        }

        private async void SlideLeft()
        {
            signal.Location = new Point(signal.Location.X + 50, signal.Location.Y);
        }
        private async void SlideUp()
        {
            signal.Location = new Point(signal.Location.X, signal.Location.Y - 50);
        }
        private async void AK1()
        {
            arivTime = t0 + t1;
            signalCounter++;
            Task.Delay(50).Wait();
        }
        private async void AK2()
        {
            checkTime = checkTime + t2;//для фиксации общего времени проверки в канале
            prepTime = t0 + t2;
            OutSignalCounter++;//считаем количесво исходящих сигналов
            Task.Delay(50).Wait();
        }

        private async void AK3()
        {
            for (int i = 0; i < N; i++)
            {
                if(compList[min].capacity > compList[i].capacity)
                {
                    min = i;
                }    
            }
            compList[min].capacity++; //если емкость
            prepSignal++;
            if (compList[min].capacity<=4)
            {
                prepTimeComp = t0 + t3;
            }
            else
            {
                compList[min].capacity = 0;
            }
            Task.Delay(50).Wait();
        }
        private async void Count()
        {
                for (int t0 = 0; t0 < 40; t0++)
                {
                    route.Text = signalCounter.ToString();
                    //DrawSignal();
                   // SlideLeft();
                    if (t0 >= arivTime)
                    {                     
                        AK1();//выполнение первого действия                      
                    }
                    if (t0>=prepTime)
                    {
                        AK2();//выполнение обработки в канале
                       // SlideLeft();
                    }
                    if (signalCounter+OutSignalCounter >0)
                    {
                        AK3(); //установка в очередь перед компьютером
                    }
                    if (t0>prepTimeComp)
                    {
                        logTable.Rows.Add(Convert.ToString(t0), Convert.ToString(min), Convert.ToString(prepSignal));
                    } 
                }
        }
        async void tmr_Tick(object sender, EventArgs e)
        {
            Count();
            if(signalCounter >= 100)
            {
               signalCounter = 0;
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
