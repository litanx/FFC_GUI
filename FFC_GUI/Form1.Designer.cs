namespace FFC_GUI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOPENCLOSE = new System.Windows.Forms.Button();
            this.cBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Enable_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Mass_textBox = new System.Windows.Forms.TextBox();
            this.Damping_textBox = new System.Windows.Forms.TextBox();
            this.Friction_textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.AxisX.Interval = 50D;
            chartArea4.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea4.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.MajorGrid.Interval = 100D;
            chartArea4.AxisX.MajorTickMark.Interval = 10D;
            chartArea4.AxisX.MajorTickMark.IntervalOffset = -10D;
            chartArea4.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea4.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea4.AxisX.Maximum = 100D;
            chartArea4.AxisX.Minimum = -100D;
            chartArea4.AxisX.MinorGrid.Enabled = true;
            chartArea4.AxisX.MinorGrid.Interval = 10D;
            chartArea4.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea4.AxisX.ScaleView.Zoomable = false;
            chartArea4.AxisY.Interval = 50D;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.MajorGrid.Interval = 100D;
            chartArea4.AxisY.MajorTickMark.Interval = 10D;
            chartArea4.AxisY.Maximum = 100D;
            chartArea4.AxisY.Minimum = -100D;
            chartArea4.AxisY.MinorGrid.Enabled = true;
            chartArea4.AxisY.MinorGrid.Interval = 10D;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea4.AxisY.ScaleView.Zoomable = false;
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(158, 10);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsVisibleInLegend = false;
            series4.MarkerSize = 6;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "Series1";
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(613, 377);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chart1_KeyDown);
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
            // 
            // btnOPENCLOSE
            // 
            this.btnOPENCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOPENCLOSE.Location = new System.Drawing.Point(714, 388);
            this.btnOPENCLOSE.Margin = new System.Windows.Forms.Padding(2);
            this.btnOPENCLOSE.Name = "btnOPENCLOSE";
            this.btnOPENCLOSE.Size = new System.Drawing.Size(57, 26);
            this.btnOPENCLOSE.TabIndex = 3;
            this.btnOPENCLOSE.Text = "OPEN";
            this.btnOPENCLOSE.UseVisualStyleBackColor = true;
            this.btnOPENCLOSE.Click += new System.EventHandler(this.btnOPENCLOSE_Click);
            this.btnOPENCLOSE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cBoxCOMPort_MouseClick);
            // 
            // cBoxCOMPort
            // 
            this.cBoxCOMPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxCOMPort.FormattingEnabled = true;
            this.cBoxCOMPort.Location = new System.Drawing.Point(619, 392);
            this.cBoxCOMPort.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxCOMPort.Name = "cBoxCOMPort";
            this.cBoxCOMPort.Size = new System.Drawing.Size(92, 21);
            this.cBoxCOMPort.TabIndex = 2;
            this.cBoxCOMPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cBoxCOMPort_MouseClick);
            // 
            // Enable_btn
            // 
            this.Enable_btn.Location = new System.Drawing.Point(9, 10);
            this.Enable_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Enable_btn.Name = "Enable_btn";
            this.Enable_btn.Size = new System.Drawing.Size(138, 31);
            this.Enable_btn.TabIndex = 4;
            this.Enable_btn.Text = "Enable";
            this.Enable_btn.UseVisualStyleBackColor = true;
            this.Enable_btn.Click += new System.EventHandler(this.Enable_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mass";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Daping";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Friction";
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar1.Location = new System.Drawing.Point(9, 137);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(135, 45);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Mass_textBox
            // 
            this.Mass_textBox.Location = new System.Drawing.Point(13, 59);
            this.Mass_textBox.Name = "Mass_textBox";
            this.Mass_textBox.Size = new System.Drawing.Size(71, 20);
            this.Mass_textBox.TabIndex = 12;
            this.Mass_textBox.Text = "1";
            this.Mass_textBox.TextChanged += new System.EventHandler(this.Mass_textBox_TextChanged);
            this.Mass_textBox.Enter += new System.EventHandler(this.Mass_textBox_Enter);
            // 
            // Damping_textBox
            // 
            this.Damping_textBox.Location = new System.Drawing.Point(13, 85);
            this.Damping_textBox.Name = "Damping_textBox";
            this.Damping_textBox.Size = new System.Drawing.Size(71, 20);
            this.Damping_textBox.TabIndex = 13;
            this.Damping_textBox.Text = "10";
            this.Damping_textBox.TextChanged += new System.EventHandler(this.Damping_textBox_TextChanged);
            this.Damping_textBox.Enter += new System.EventHandler(this.Damping_textBox_Enter);
            // 
            // Friction_textBox
            // 
            this.Friction_textBox.Location = new System.Drawing.Point(13, 111);
            this.Friction_textBox.Name = "Friction_textBox";
            this.Friction_textBox.Size = new System.Drawing.Size(71, 20);
            this.Friction_textBox.TabIndex = 14;
            this.Friction_textBox.Text = "1";
            this.Friction_textBox.TextChanged += new System.EventHandler(this.Friction_textBox_TextChanged);
            this.Friction_textBox.Enter += new System.EventHandler(this.Friction_textBox_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 423);
            this.Controls.Add(this.Friction_textBox);
            this.Controls.Add(this.Damping_textBox);
            this.Controls.Add(this.Mass_textBox);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Enable_btn);
            this.Controls.Add(this.btnOPENCLOSE);
            this.Controls.Add(this.cBoxCOMPort);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "FFC GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnOPENCLOSE;
        private System.Windows.Forms.ComboBox cBoxCOMPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button Enable_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox Mass_textBox;
        private System.Windows.Forms.TextBox Damping_textBox;
        private System.Windows.Forms.TextBox Friction_textBox;
    }
}

