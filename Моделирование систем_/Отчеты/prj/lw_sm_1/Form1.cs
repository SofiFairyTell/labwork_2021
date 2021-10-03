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
       Timer tmr = new Timer();
       int sign = 1;
       //счетчик канала
       int min = 0, max = 1000, signalCounter = 0;

      //для детерминированной СМО
        int t0 = 0, N = 3, t1 = 10, t2 = 10, t3 = 33, Е = 4; 
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
            DrawSignal();
            tmr.Enabled = !tmr.Enabled; //старт/стоп
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            signalCounter += sign;
            route.Text = signalCounter.ToString();
            if (signalCounter == max || signalCounter == min)
            {
                sign *= -1;
                signal.Location = new Point(signal.Location.X - 100, signal.Location.Y);
            }
            else
            {
                signal.Location = new Point(signal.Location.X + 100, signal.Location.Y);
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
