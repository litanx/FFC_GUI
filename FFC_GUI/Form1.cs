using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FFC_GUI
{
    public partial class Form1 : Form
    {

        string[] ports;
        string sDataIn; // Serial Input Data packets

        /* Chart control */
        DataPoint curPoint = null;      // Variable used for chart point drag function
        HitTestResult hit = null;

        int tBox_Cursor = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Serial Port combo box update */
            ports = SerialPort.GetPortNames();
            cBoxCOMPort.Items.AddRange(ports);
            if(ports.Length > 0) cBoxCOMPort.SelectedIndex = 0;


            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 100;
            chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 10;
            chart1.ChartAreas[0].AxisX.Interval = 50;
            chart1.ChartAreas[0].AxisX.Minimum = -100;
            chart1.ChartAreas[0].AxisX.Maximum = 100;

            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 100;
            chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 10;
            chart1.ChartAreas[0].AxisY.Interval = 50;
            chart1.ChartAreas[0].AxisY.Minimum = -100;
            chart1.ChartAreas[0].AxisY.Maximum = 100;

            /* Populalte initial graph with default points */
            chart1.Series["Series1"].Points.AddXY(-90, -100);
            chart1.Series["Series1"].Points.AddXY(-90, 0);
            chart1.Series["Series1"].Points.AddXY(-50, 0);
            chart1.Series["Series1"].Points.AddXY(-0.5, -20);
            chart1.Series["Series1"].Points.AddXY(0.5, 20);
            chart1.Series["Series1"].Points.AddXY(50, 0);
            chart1.Series["Series1"].Points.AddXY(90, 0);
            chart1.Series["Series1"].Points.AddXY(90, 100);

            chart1.Series["Series1"].Points[0].MarkerSize = 0;
            chart1.Series["Series1"].Points.Last().MarkerSize = 0;


        }


        private void cBoxCOMPort_MouseClick(object sender, MouseEventArgs e)
        {
            ports = SerialPort.GetPortNames();

            cBoxCOMPort.Items.Clear();
            cBoxCOMPort.Items.AddRange(ports);
        }

        private void btnOPENCLOSE_Click(object sender, EventArgs e)
        {
         
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                if (!serialPort1.IsOpen)
                {
                    Console.WriteLine("COM Port Closed");
                    btnOPENCLOSE.Text = "OPEN";
                }
            }
            else
            {
                try
                {
                    serialPort1.PortName = cBoxCOMPort.Text;
                    serialPort1.BaudRate = 115200;
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Parity = Parity.None;
                    serialPort1.Open();

                    if (serialPort1.IsOpen)
                    {
                        Console.WriteLine("COM Port Opened");
                        btnOPENCLOSE.Text = "CLOSE";

                        /* Here I can trigger a startup set of commands such as read FW version etc */
                        // this.Invoke(new EventHandler(commsFirstRead)); 
                    }
                    else
                    {
                        Console.WriteLine("Unable to open Port");
                        btnOPENCLOSE.Text = "OPEN";
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("Error: " + err);
                }
            }
            
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            sDataIn = sDataIn += serialPort1.ReadExisting();    // add incoming chunk of data

            if (sDataIn.EndsWith("\r\n") == true)
            {
                this.Invoke(new EventHandler(dataPacketParse));
                sDataIn = "";
            }
        }

        private void dataPacketParse(object sender, EventArgs e)
        {

            float val_0, val_1; // ComboBox
            string[] commands = sDataIn.Split('\n');    //Splits commands $103=10\r\n


            foreach (var i in commands)
            {
                char[] delimiterChars = { ',', '=', '\t', '\r', '\n' };
                string[] words = i.Split(delimiterChars);

                if (words.Length < 2) break;

                if (words[0].Contains("cmd") == true) //position and force cmd=1.23,4.0\n
                {
                    //if (float.TryParse(words[1].ToString(), out float n) == true) tBoxOutPower.Text = words[1].ToString();
                    float.TryParse(words[1], out val_0);
                    float.TryParse(words[2], out val_1);


                    Point cursorPoint = new Point(10, 10);

                    chart1.ChartAreas[0].CursorX.Position = val_0;
                    chart1.ChartAreas[0].CursorY.Position = val_1;


                    Console.WriteLine("Plot: " + val_0 + "," + val_1);

                }

            }
        }

        private void move_currentPoint(double dx, double dy) {


            if (hit.PointIndex == 1)
            {
                /* First point of the graph */
                if ((dx < chart1.Series["Series1"].Points[2].XValue) && (dx >= chart1.ChartAreas[0].AxisX.Minimum))
                    curPoint.XValue = dx;
                chart1.Series["Series1"].Points[0].XValue = dx;
            }
            else if (hit.PointIndex == (chart1.Series["Series1"].Points.LongCount() - 2))
            {
                /* Last point of the graph*/
                if ((dx > chart1.Series["Series1"].Points[hit.PointIndex - 1].XValue) && (dx <= chart1.ChartAreas[0].AxisX.Maximum))
                    curPoint.XValue = dx;
                chart1.Series["Series1"].Points[hit.PointIndex + 1].XValue = dx;
            }
            else
            {
                /* Sample is between two points */
                if ((dx > chart1.Series["Series1"].Points[hit.PointIndex - 1].XValue) && (dx < chart1.Series["Series1"].Points[hit.PointIndex + 1].XValue))
                    curPoint.XValue = dx;
            }

            if ((dy >= chart1.ChartAreas[0].AxisY.Minimum) && (dy <= chart1.ChartAreas[0].AxisY.Maximum))
                curPoint.YValues[0] = dy;
        }


        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                ChartArea ca = chart1.ChartAreas[0];
                Axis ax = ca.AxisX;
                Axis ay = ca.AxisY;

                if (curPoint != null)
                {
                    Series s = hit.Series;
                    double dx = 0;
                    double dy = 0;

                    try
                    {
                        dx = ax.PixelPositionToValue(e.X);
                    }
                    catch (ArgumentException x) {
                        return;
                    }

                    try
                    {
                        dy = ay.PixelPositionToValue(e.Y);
                    }
                    catch (ArgumentException x) {
                        return;
                    }

                    move_currentPoint(dx, dy);
                }
            }
        }

        private void transmit_Characteristics() {


            string cmd = "cmap=";


            for (int i = 1; i < chart1.Series["Series1"].Points.Count-1; i++)
            {
                // Append the X and Y values of each data point
                //cmapBuilder.Append(series.Points[i].XValue);
                cmd += chart1.Series["Series1"].Points[i].XValue.ToString("F5");
                //cmapBuilder.Append(",");
                cmd += (",");
                //cmapBuilder.Append(series.Points[i].YValues[0]);
                cmd += chart1.Series["Series1"].Points[i].YValues[0].ToString("F5");

                if (i < chart1.Series["Series1"].Points.Count - 1)
                {
                    cmd += (",");
                }
            }

            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.WriteLine(cmd);
                    Console.WriteLine(cmd);

                }
                catch (Exception err)
                {
                    Console.WriteLine("Error: " + err);
                }
            };

        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {

            if (curPoint != null)      /* De-select Point */
            {
                curPoint.Color = Color.Empty; /* Restore color if changed */
                curPoint.MarkerSize = 6;
                curPoint = null;
            }

            hit = chart1.HitTest(e.X, e.Y);

            /* Make sure that it´s not the last or the firts point the one selected */
            if (hit.PointIndex > 0 && hit.PointIndex < (chart1.Series["Series1"].Points.LongCount() - 1))        /* Select a Point */
            {
                try
                {
                    curPoint = hit.Series.Points[hit.PointIndex];
                }
                catch (Exception err)
                {
                    Console.WriteLine("Error: " + err);
                }
                
                //curPoint.Color = Color.Red;       /* Highlight point color    */
                curPoint.MarkerSize = 10;           /* Highlight point          */
            }
            else 
            {
                /* transmit new characteristics to the controller */
                //this.Invoke(new EventHandler(transmit_Characteristics));
                transmit_Characteristics();

            }

            chart1.Focus();

        }

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                ChartArea ca = chart1.ChartAreas[0];
                Axis ax = ca.AxisX;
                Axis ay = ca.AxisY;

                /* Create a new point in the chart */
                chart1.Series["Series1"].Points.AddXY(ax.PixelPositionToValue(e.X), ay.PixelPositionToValue(e.Y));
                //chart1.Series["Series1"].OrderBy(Points <= Points.Y);

                // Sort the points by X value
                var sortedPoints = chart1.Series["Series1"].Points
                    .OrderBy(p => p.XValue)
                    .ToList();

                // Clear and re-add the points in sorted order
                chart1.Series["Series1"].Points.Clear();
                foreach (var point in sortedPoints)
                {
                    chart1.Series["Series1"].Points.AddXY(point.XValue, point.YValues[0]);
                }

                chart1.Series["Series1"].Points[0].MarkerSize = 0;
                chart1.Series["Series1"].Points.Last().MarkerSize = 0;
            }
        }

        private void chart1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (hit.PointIndex >= 0 && chart1.Series["Series1"].Points.Count > 2)        /* Point still selected */
                {
                    chart1.Series["Series1"].Points.RemoveAt(hit.PointIndex);
                    chart1.ResetAutoValues();


                    transmit_Characteristics();
                    e.Handled = true; // Prevent focus change
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                
                move_currentPoint(curPoint.XValue + 1, curPoint.YValues[0]);
                e.Handled = true; // Prevent focus change
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
            }
            else if (e.KeyCode == Keys.Left)
            {
            }
            else if (e.KeyCode == Keys.Right)
            {
            }
        }

        private void Enable_btn_Click(object sender, EventArgs e)
        {
            // Change the button's text
            if (Enable_btn.Text == "Enable")
            {
                Enable_btn.Text = "Disable";

            }
            else 
            {
                Enable_btn.Text = "Enable";
            }
        }

       

        private void Mass_textBox_Leave(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.WriteLine("mass=" + Mass_textBox.Text);
                    Console.WriteLine("mass=" + Mass_textBox.Text);
                    
                }
                catch (Exception err)
                {
                    Console.WriteLine("Error: " + err);
                }
            };
        }

        private void Mass_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                this.Invoke(new EventHandler(Mass_textBox_Leave));
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Damping_textBox_Leave(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.WriteLine("damp=" + Damping_textBox.Text);
                    Console.WriteLine("damp=" + Damping_textBox.Text);

                }
                catch (Exception err)
                {
                    Console.WriteLine("Error: " + err);
                }
            };
        }

        private void Damping_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Invoke(new EventHandler(Damping_textBox_Leave));
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void PosMax_tbox_Leave(object sender, EventArgs e)
        {
                          
            float x = (float)Convert.ToDouble(PosMax_tbox.Text);
            chart1.ChartAreas[0].AxisX.Maximum = x+1;

        }

        private void PosMax_tbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Invoke(new EventHandler(PosMax_tbox_Leave));
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void PosMin_tbox_Leave(object sender, EventArgs e)
        {
            float x = (float)Convert.ToDouble(PosMin_tbox.Text);
            chart1.ChartAreas[0].AxisX.Minimum = x-1;
              
        }

        private void PosMin_tbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Invoke(new EventHandler(PosMin_tbox_Leave));
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Friction_textBox_Leave(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.WriteLine("frcn=" + Friction_textBox.Text);
                    Console.WriteLine("frcn=" + Friction_textBox.Text);

                }
                catch (Exception err)
                {
                    Console.WriteLine("Error: " + err);
                }
            };
        }

        private void Friction_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Invoke(new EventHandler(Friction_textBox_Leave));
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    } 
}

