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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOPENCLOSE = new System.Windows.Forms.Button();
            this.cBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Enable_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Mass_textBox = new System.Windows.Forms.TextBox();
            this.Damping_textBox = new System.Windows.Forms.TextBox();
            this.Friction_textBox = new System.Windows.Forms.TextBox();
            this.PosMax_tbox = new System.Windows.Forms.TextBox();
            this.PosMin_tbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.Interval = 50D;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.MajorGrid.Interval = 100D;
            chartArea2.AxisX.MajorTickMark.Interval = 10D;
            chartArea2.AxisX.MajorTickMark.IntervalOffset = -10D;
            chartArea2.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.Maximum = 100D;
            chartArea2.AxisX.Minimum = -100D;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.Interval = 10D;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.ScaleView.Zoomable = false;
            chartArea2.AxisY.Interval = 50D;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.MajorGrid.Interval = 100D;
            chartArea2.AxisY.MajorTickMark.Interval = 10D;
            chartArea2.AxisY.Maximum = 100D;
            chartArea2.AxisY.Minimum = -100D;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.Interval = 10D;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.ScaleView.Zoomable = false;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(211, 12);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.MarkerSize = 6;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Series1";
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series2";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(817, 464);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chart1_KeyDown);
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // btnOPENCLOSE
            // 
            this.btnOPENCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOPENCLOSE.Location = new System.Drawing.Point(952, 478);
            this.btnOPENCLOSE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOPENCLOSE.Name = "btnOPENCLOSE";
            this.btnOPENCLOSE.Size = new System.Drawing.Size(76, 32);
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
            this.cBoxCOMPort.Location = new System.Drawing.Point(825, 482);
            this.cBoxCOMPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxCOMPort.Name = "cBoxCOMPort";
            this.cBoxCOMPort.Size = new System.Drawing.Size(121, 24);
            this.cBoxCOMPort.TabIndex = 2;
            this.cBoxCOMPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cBoxCOMPort_MouseClick);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Enable_btn
            // 
            this.Enable_btn.Location = new System.Drawing.Point(12, 12);
            this.Enable_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Enable_btn.Name = "Enable_btn";
            this.Enable_btn.Size = new System.Drawing.Size(184, 38);
            this.Enable_btn.TabIndex = 4;
            this.Enable_btn.Text = "Enable";
            this.Enable_btn.UseVisualStyleBackColor = true;
            this.Enable_btn.Click += new System.EventHandler(this.Enable_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mass";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Daping";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Friction";
            // 
            // Mass_textBox
            // 
            this.Mass_textBox.Location = new System.Drawing.Point(17, 73);
            this.Mass_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.Mass_textBox.Name = "Mass_textBox";
            this.Mass_textBox.Size = new System.Drawing.Size(93, 22);
            this.Mass_textBox.TabIndex = 12;
            this.Mass_textBox.Text = "1";
            this.Mass_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mass_textBox_KeyDown);
            this.Mass_textBox.Leave += new System.EventHandler(this.Mass_textBox_Leave);
            // 
            // Damping_textBox
            // 
            this.Damping_textBox.Location = new System.Drawing.Point(17, 105);
            this.Damping_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.Damping_textBox.Name = "Damping_textBox";
            this.Damping_textBox.Size = new System.Drawing.Size(93, 22);
            this.Damping_textBox.TabIndex = 13;
            this.Damping_textBox.Text = "10";
            this.Damping_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Damping_textBox_KeyDown);
            this.Damping_textBox.Leave += new System.EventHandler(this.Damping_textBox_Leave);
            // 
            // Friction_textBox
            // 
            this.Friction_textBox.Location = new System.Drawing.Point(17, 137);
            this.Friction_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.Friction_textBox.Name = "Friction_textBox";
            this.Friction_textBox.Size = new System.Drawing.Size(93, 22);
            this.Friction_textBox.TabIndex = 14;
            this.Friction_textBox.Text = "1";
            // 
            // PosMax_tbox
            // 
            this.PosMax_tbox.Location = new System.Drawing.Point(17, 340);
            this.PosMax_tbox.Margin = new System.Windows.Forms.Padding(4);
            this.PosMax_tbox.Name = "PosMax_tbox";
            this.PosMax_tbox.Size = new System.Drawing.Size(93, 22);
            this.PosMax_tbox.TabIndex = 15;
            this.PosMax_tbox.Text = "100";
            this.PosMax_tbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PosMax_tbox_KeyDown);
            this.PosMax_tbox.Leave += new System.EventHandler(this.PosMax_tbox_Leave);
            // 
            // PosMin_tbox
            // 
            this.PosMin_tbox.Location = new System.Drawing.Point(17, 370);
            this.PosMin_tbox.Margin = new System.Windows.Forms.Padding(4);
            this.PosMin_tbox.Name = "PosMin_tbox";
            this.PosMin_tbox.Size = new System.Drawing.Size(93, 22);
            this.PosMin_tbox.TabIndex = 16;
            this.PosMin_tbox.Text = "-100";
            this.PosMin_tbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PosMin_tbox_KeyDown);
            this.PosMin_tbox.Leave += new System.EventHandler(this.PosMin_tbox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "PosMax";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "PosMin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 521);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PosMin_tbox);
            this.Controls.Add(this.PosMax_tbox);
            this.Controls.Add(this.Friction_textBox);
            this.Controls.Add(this.Damping_textBox);
            this.Controls.Add(this.Mass_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Enable_btn);
            this.Controls.Add(this.btnOPENCLOSE);
            this.Controls.Add(this.cBoxCOMPort);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "FFC GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.TextBox Mass_textBox;
        private System.Windows.Forms.TextBox Damping_textBox;
        private System.Windows.Forms.TextBox Friction_textBox;
        private System.Windows.Forms.TextBox PosMax_tbox;
        private System.Windows.Forms.TextBox PosMin_tbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

