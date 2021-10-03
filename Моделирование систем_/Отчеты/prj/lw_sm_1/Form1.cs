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
        int arivTime = 0, prepTime = 0, checkTime = 0;

        public Form1()
        {
            InitializeComponent();  
            tmr.Interval = 1000;          
            tmr.Tick += new EventHandler(tmr_Tick);
            route.Text = signalCounter.ToString();
        }

        private void DrawSignal()
        {
            Bitmap mybit = new Bitmap(signal.Width, signal.Height);
            Graphics g = Graphics.FromImage(mybit);
            SolidBrush grBrush = new SolidBrush(Color.Green);
            g.FillRectangle(grBrush,0,0, signal.Width, signal.Height);
            signal.Image = mybit;
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

        private void AK1()
        {
            arivTime = t0 + t1;
            signalCounter++;
        }
        private void AK2()
        {
            prepTime = t0 + t2;
            OutSignalCounter++;
        }

        private void AK3()
        {
            //compList.Sort();
            for (int i = 0; i < N; i++)
            {
                if(compList[i].capacity <= 4)
                {
                    compList[i].capacity -= 1; //если емкость
                    checkTime = t0 + t3;
                    lbComp1.Text = compList[i].capacity.ToString();
                }
                if (compList[i].capacity ==0)
                {
                    compList[i].capacity = 4;
                }
            }

        }
        void tmr_Tick(object sender, EventArgs e)
        {
            if (t0 >= arivTime)
            {
                AK1();//выполнение первого действия
            }
            if (t0>=prepTime)
            {
                AK2();//выполнение обработки в канале
            }
            if (emptyComp)
            {
                AK3(); //установка в очередь перед компьютером
            }
            //signalCounter += sign;
            route.Text = signalCounter.ToString();
            if (signalCounter == max)
            {
                signal.Location = new Point(signal.Location.X - 100, signal.Location.Y);
                tmr.Enabled = !tmr.Enabled; //старт/стоп
            }
            else
            {
                
                if (signal.Location.X <= 120)
                {
                   signal.Location = new Point(signal.Location.X + 10, signal.Location.Y);
                }
                else
                {
                    signal.Location = new Point(signal.Location.X, signal.Location.Y-10);
                }
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
