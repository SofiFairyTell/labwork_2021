
namespace lw_sm_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.route = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.signal = new System.Windows.Forms.PictureBox();
            this.grProperties = new System.Windows.Forms.GroupBox();
            this.lbComp1 = new System.Windows.Forms.Label();
            this.lbComp2 = new System.Windows.Forms.Label();
            this.lbComp3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signal)).BeginInit();
            this.grProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::lw_sm_1.Properties.Resources.comp;
            this.pictureBox1.Location = new System.Drawing.Point(446, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::lw_sm_1.Properties.Resources.comp;
            this.pictureBox2.Location = new System.Drawing.Point(446, 142);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 92);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::lw_sm_1.Properties.Resources.comp;
            this.pictureBox3.Location = new System.Drawing.Point(446, 281);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(138, 84);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // route
            // 
            this.route.AutoSize = true;
            this.route.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.route.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.route.Location = new System.Drawing.Point(170, 155);
            this.route.Name = "route";
            this.route.Size = new System.Drawing.Size(153, 65);
            this.route.TabIndex = 3;
            this.route.Text = "канал";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(26, 104);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(153, 40);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // signal
            // 
            this.signal.Location = new System.Drawing.Point(55, 170);
            this.signal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signal.Name = "signal";
            this.signal.Size = new System.Drawing.Size(37, 36);
            this.signal.TabIndex = 5;
            this.signal.TabStop = false;
            // 
            // grProperties
            // 
            this.grProperties.Controls.Add(this.btnStart);
            this.grProperties.Location = new System.Drawing.Point(615, 13);
            this.grProperties.Name = "grProperties";
            this.grProperties.Size = new System.Drawing.Size(200, 161);
            this.grProperties.TabIndex = 6;
            this.grProperties.TabStop = false;
            this.grProperties.Text = "Параметры моделирования";
            // 
            // lbComp1
            // 
            this.lbComp1.AutoSize = true;
            this.lbComp1.Location = new System.Drawing.Point(395, 57);
            this.lbComp1.Name = "lbComp1";
            this.lbComp1.Size = new System.Drawing.Size(38, 15);
            this.lbComp1.TabIndex = 7;
            this.lbComp1.Text = "label1";
            // 
            // lbComp2
            // 
            this.lbComp2.AutoSize = true;
            this.lbComp2.Location = new System.Drawing.Point(395, 170);
            this.lbComp2.Name = "lbComp2";
            this.lbComp2.Size = new System.Drawing.Size(38, 15);
            this.lbComp2.TabIndex = 8;
            this.lbComp2.Text = "label1";
            // 
            // lbComp3
            // 
            this.lbComp3.AutoSize = true;
            this.lbComp3.Location = new System.Drawing.Point(395, 315);
            this.lbComp3.Name = "lbComp3";
            this.lbComp3.Size = new System.Drawing.Size(38, 15);
            this.lbComp3.TabIndex = 9;
            this.lbComp3.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 398);
            this.Controls.Add(this.lbComp3);
            this.Controls.Add(this.lbComp2);
            this.Controls.Add(this.lbComp1);
            this.Controls.Add(this.grProperties);
            this.Controls.Add(this.signal);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.route);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signal)).EndInit();
            this.grProperties.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label route;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox signal;
        private System.Windows.Forms.GroupBox grProperties;
        private System.Windows.Forms.Label lbComp1;
        private System.Windows.Forms.Label lbComp2;
        private System.Windows.Forms.Label lbComp3;
    }
}