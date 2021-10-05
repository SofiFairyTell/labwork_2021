
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
            this.tbT3 = new System.Windows.Forms.TextBox();
            this.lbT3 = new System.Windows.Forms.Label();
            this.tbT2 = new System.Windows.Forms.TextBox();
            this.lbT2 = new System.Windows.Forms.Label();
            this.tbT1 = new System.Windows.Forms.TextBox();
            this.lbT1 = new System.Windows.Forms.Label();
            this.tbNumComp = new System.Windows.Forms.TextBox();
            this.lbNumComp = new System.Windows.Forms.Label();
            this.lbComp1 = new System.Windows.Forms.Label();
            this.lbComp2 = new System.Windows.Forms.Label();
            this.lbComp3 = new System.Windows.Forms.Label();
            this.logTable = new System.Windows.Forms.DataGridView();
            this.TimePrep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrepSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbModel = new System.Windows.Forms.TabControl();
            this.tabModel = new System.Windows.Forms.TabPage();
            this.tabData = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signal)).BeginInit();
            this.grProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logTable)).BeginInit();
            this.tbModel.SuspendLayout();
            this.tabModel.SuspendLayout();
            this.tabData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::lw_sm_1.Properties.Resources.comp;
            this.pictureBox1.Location = new System.Drawing.Point(310, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::lw_sm_1.Properties.Resources.comp;
            this.pictureBox2.Location = new System.Drawing.Point(310, 141);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 92);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::lw_sm_1.Properties.Resources.comp;
            this.pictureBox3.Location = new System.Drawing.Point(310, 248);
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
            this.route.Location = new System.Drawing.Point(58, 124);
            this.route.Name = "route";
            this.route.Size = new System.Drawing.Size(153, 65);
            this.route.TabIndex = 3;
            this.route.Text = "канал";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(28, 292);
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
            this.signal.BackColor = System.Drawing.Color.Maroon;
            this.signal.Location = new System.Drawing.Point(6, 141);
            this.signal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signal.Name = "signal";
            this.signal.Size = new System.Drawing.Size(37, 36);
            this.signal.TabIndex = 5;
            this.signal.TabStop = false;
            // 
            // grProperties
            // 
            this.grProperties.Controls.Add(this.tbT3);
            this.grProperties.Controls.Add(this.lbT3);
            this.grProperties.Controls.Add(this.tbT2);
            this.grProperties.Controls.Add(this.lbT2);
            this.grProperties.Controls.Add(this.tbT1);
            this.grProperties.Controls.Add(this.lbT1);
            this.grProperties.Controls.Add(this.tbNumComp);
            this.grProperties.Controls.Add(this.lbNumComp);
            this.grProperties.Controls.Add(this.btnStart);
            this.grProperties.Location = new System.Drawing.Point(620, 46);
            this.grProperties.Name = "grProperties";
            this.grProperties.Size = new System.Drawing.Size(227, 347);
            this.grProperties.TabIndex = 6;
            this.grProperties.TabStop = false;
            this.grProperties.Text = "Параметры моделирования";
            // 
            // tbT3
            // 
            this.tbT3.Location = new System.Drawing.Point(111, 183);
            this.tbT3.Name = "tbT3";
            this.tbT3.Size = new System.Drawing.Size(100, 23);
            this.tbT3.TabIndex = 12;
            // 
            // lbT3
            // 
            this.lbT3.AutoSize = true;
            this.lbT3.Location = new System.Drawing.Point(7, 191);
            this.lbT3.Name = "lbT3";
            this.lbT3.Size = new System.Drawing.Size(17, 15);
            this.lbT3.TabIndex = 11;
            this.lbT3.Text = "t3";
            // 
            // tbT2
            // 
            this.tbT2.Location = new System.Drawing.Point(111, 139);
            this.tbT2.Name = "tbT2";
            this.tbT2.Size = new System.Drawing.Size(100, 23);
            this.tbT2.TabIndex = 10;
            // 
            // lbT2
            // 
            this.lbT2.AutoSize = true;
            this.lbT2.Location = new System.Drawing.Point(7, 142);
            this.lbT2.Name = "lbT2";
            this.lbT2.Size = new System.Drawing.Size(17, 15);
            this.lbT2.TabIndex = 9;
            this.lbT2.Text = "t2";
            // 
            // tbT1
            // 
            this.tbT1.Location = new System.Drawing.Point(111, 100);
            this.tbT1.Name = "tbT1";
            this.tbT1.Size = new System.Drawing.Size(100, 23);
            this.tbT1.TabIndex = 8;
            // 
            // lbT1
            // 
            this.lbT1.AutoSize = true;
            this.lbT1.Location = new System.Drawing.Point(7, 103);
            this.lbT1.Name = "lbT1";
            this.lbT1.Size = new System.Drawing.Size(17, 15);
            this.lbT1.TabIndex = 7;
            this.lbT1.Text = "t1";
            // 
            // tbNumComp
            // 
            this.tbNumComp.Location = new System.Drawing.Point(111, 56);
            this.tbNumComp.Name = "tbNumComp";
            this.tbNumComp.Size = new System.Drawing.Size(100, 23);
            this.tbNumComp.TabIndex = 6;
            // 
            // lbNumComp
            // 
            this.lbNumComp.AutoSize = true;
            this.lbNumComp.Location = new System.Drawing.Point(7, 56);
            this.lbNumComp.Name = "lbNumComp";
            this.lbNumComp.Size = new System.Drawing.Size(97, 15);
            this.lbNumComp.TabIndex = 5;
            this.lbNumComp.Text = "N_компьютеров";
            // 
            // lbComp1
            // 
            this.lbComp1.AutoSize = true;
            this.lbComp1.Location = new System.Drawing.Point(249, 58);
            this.lbComp1.Name = "lbComp1";
            this.lbComp1.Size = new System.Drawing.Size(38, 15);
            this.lbComp1.TabIndex = 7;
            this.lbComp1.Text = "label1";
            // 
            // lbComp2
            // 
            this.lbComp2.AutoSize = true;
            this.lbComp2.Location = new System.Drawing.Point(249, 162);
            this.lbComp2.Name = "lbComp2";
            this.lbComp2.Size = new System.Drawing.Size(38, 15);
            this.lbComp2.TabIndex = 8;
            this.lbComp2.Text = "label1";
            // 
            // lbComp3
            // 
            this.lbComp3.AutoSize = true;
            this.lbComp3.Location = new System.Drawing.Point(249, 282);
            this.lbComp3.Name = "lbComp3";
            this.lbComp3.Size = new System.Drawing.Size(38, 15);
            this.lbComp3.TabIndex = 9;
            this.lbComp3.Text = "label1";
            // 
            // logTable
            // 
            this.logTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimePrep,
            this.NumComp,
            this.PrepSign,
            this.ActionData});
            this.logTable.Location = new System.Drawing.Point(6, 6);
            this.logTable.Name = "logTable";
            this.logTable.RowTemplate.Height = 25;
            this.logTable.Size = new System.Drawing.Size(581, 337);
            this.logTable.TabIndex = 10;
            // 
            // TimePrep
            // 
            this.TimePrep.HeaderText = "t0";
            this.TimePrep.Name = "TimePrep";
            // 
            // NumComp
            // 
            this.NumComp.HeaderText = "№ЭВМ";
            this.NumComp.Name = "NumComp";
            // 
            // PrepSign
            // 
            this.PrepSign.HeaderText = "Обр.сигналов";
            this.PrepSign.Name = "PrepSign";
            // 
            // ActionData
            // 
            this.ActionData.HeaderText = "Вып.действие";
            this.ActionData.Name = "ActionData";
            // 
            // tbModel
            // 
            this.tbModel.Controls.Add(this.tabModel);
            this.tbModel.Controls.Add(this.tabData);
            this.tbModel.Location = new System.Drawing.Point(13, 22);
            this.tbModel.Name = "tbModel";
            this.tbModel.SelectedIndex = 0;
            this.tbModel.Size = new System.Drawing.Size(601, 377);
            this.tbModel.TabIndex = 11;
            // 
            // tabModel
            // 
            this.tabModel.Controls.Add(this.signal);
            this.tabModel.Controls.Add(this.route);
            this.tabModel.Controls.Add(this.lbComp1);
            this.tabModel.Controls.Add(this.pictureBox3);
            this.tabModel.Controls.Add(this.lbComp3);
            this.tabModel.Controls.Add(this.pictureBox2);
            this.tabModel.Controls.Add(this.lbComp2);
            this.tabModel.Controls.Add(this.pictureBox1);
            this.tabModel.Location = new System.Drawing.Point(4, 24);
            this.tabModel.Name = "tabModel";
            this.tabModel.Padding = new System.Windows.Forms.Padding(3);
            this.tabModel.Size = new System.Drawing.Size(593, 349);
            this.tabModel.TabIndex = 0;
            this.tabModel.Text = "Модель";
            this.tabModel.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.logTable);
            this.tabData.Location = new System.Drawing.Point(4, 24);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(593, 349);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Данные";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 405);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.grProperties);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signal)).EndInit();
            this.grProperties.ResumeLayout(false);
            this.grProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logTable)).EndInit();
            this.tbModel.ResumeLayout(false);
            this.tabModel.ResumeLayout(false);
            this.tabModel.PerformLayout();
            this.tabData.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridView logTable;
        private System.Windows.Forms.TextBox tbT3;
        private System.Windows.Forms.Label lbT3;
        private System.Windows.Forms.TextBox tbT2;
        private System.Windows.Forms.Label lbT2;
        private System.Windows.Forms.TextBox tbT1;
        private System.Windows.Forms.Label lbT1;
        private System.Windows.Forms.TextBox tbNumComp;
        private System.Windows.Forms.Label lbNumComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimePrep;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrepSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionData;
        private System.Windows.Forms.TabControl tbModel;
        private System.Windows.Forms.TabPage tabModel;
        private System.Windows.Forms.TabPage tabData;
    }
}