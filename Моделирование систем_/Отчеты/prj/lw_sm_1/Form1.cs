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
       int min = 5, max = 10, labelValue = 5;
        
        public Form1()
        {
            InitializeComponent();  
            tmr.Interval = 1000;          
            tmr.Tick += new EventHandler(tmr_Tick);
            route.Text = labelValue.ToString();
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
            labelValue += sign;
            route.Text = labelValue.ToString();
            if (labelValue == max || labelValue == min)
            {
                sign *= -1;
                signal.Location = new Point(signal.Location.X - 10, signal.Location.Y - 10);
            }
            else
            {
                signal.Location = new Point(signal.Location.X + 10, signal.Location.Y + 10);
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
