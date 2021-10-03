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
        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(10, 10, 100, 100));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Bitmap mybit = new Bitmap(signal.Width, signal.Height);
            Graphics g = Graphics.FromImage(mybit);
            SolidBrush grBrush = new SolidBrush(Color.Green);
            g.FillRectangle(grBrush,0,0, signal.Width, signal.Height);
            tmr.Enabled = !tmr.Enabled; //старт/стоп
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            labelValue += sign;
            route.Text = labelValue.ToString();
            if (labelValue == max || labelValue == min)
            {
                sign *= -1;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
