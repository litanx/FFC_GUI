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
            chart1.ChartAreas[0].AxisY.Interval = 100;
            chart1.ChartAreas[0].AxisY.Minimum = -100;
            chart1.ChartAreas[0].AxisY.Maximum = 100;

            /* Populalte initial graph with default points */
            chart1.Series["Series1"].Points.AddXY(-70, -70);
            chart1.Series["Series1"].Points.AddXY(0, -10);
            chart1.Series["Series1"].Points.AddXY(0, 10);
            chart1.Series["Series1"].Points.AddXY(70, 70);

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

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
   
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

                    
                    if (hit.PointIndex == 0)    
                    {
                        /* First point of the graph */
                        if((dx < chart1.Series["Series1"].Points[1].XValue) && (dx >= chart1.ChartAreas[0].AxisX.Minimum))
                            curPoint.XValue = dx;
                    }
                    else if (hit.PointIndex == (chart1.Series["Series1"].Points.LongCount()-1) ) 
                    {
                        /* Last point of the graph*/
                        if ((dx > chart1.Series["Series1"].Points[hit.PointIndex-1].XValue) && (dx <= chart1.ChartAreas[0].AxisX.Maximum))
                            curPoint.XValue = dx;
                    }
                    else                        
                    {
                        /* Sample is between two points */
                        if ((dx > chart1.Series["Series1"].Points[hit.PointIndex - 1].XValue) && (dx < chart1.Series["Series1"].Points[hit.PointIndex + 1].XValue))
                            curPoint.XValue = dx;
                    }
                    
                    if((dy >= chart1.ChartAreas[0].AxisY.Minimum) && (dy <= chart1.ChartAreas[0].AxisY.Maximum))
                        curPoint.YValues[0] = dy;   
                }
            }
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

            if (hit.PointIndex >= 0)        /* Select a Point */
            {
                curPoint = hit.Series.Points[hit.PointIndex];
                //curPoint.Color = Color.Red;       /* Highlight point color    */
                curPoint.MarkerSize = 10;           /* Highlight point          */
            }
            else 
            {
                /* transmit new characteristics to the controller */
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
            }
        }

        private void chart1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (hit.PointIndex >= 0)        /* Point still selected */
                {
                    chart1.Series["Series1"].Points.RemoveAt(hit.PointIndex);
                    chart1.ResetAutoValues();
                }
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

        private void Mass_textBox_TextChanged(object sender, EventArgs e)
        {
            tBox_Cursor = 1;

            if (int.TryParse(Mass_textBox.Text, out int value))
            {
                // Ensure the value is within the TrackBar's range
                if (value >= trackBar1.Minimum && value <= trackBar1.Maximum)
                {
                    trackBar1.Value = value; // Set the TrackBar's value
                }
                else
                {
                    MessageBox.Show($"Value must be between {trackBar1.Minimum} and {trackBar1.Maximum}");
                }
            }
            else
            {
                MessageBox.Show("Invalid number entered in Mass_textBox.");
            }
        }

        private void Damping_textBox_TextChanged(object sender, EventArgs e)
        {
            tBox_Cursor = 2;

            if (int.TryParse(Damping_textBox.Text, out int value))
            {
                // Ensure the value is within the TrackBar's range
                if (value >= trackBar1.Minimum && value <= trackBar1.Maximum)
                {
                    trackBar1.Value = value; // Set the TrackBar's value
                }
                else
                {
                    MessageBox.Show($"Value must be between {trackBar1.Minimum} and {trackBar1.Maximum}");
                }
            }
            else
            {
                MessageBox.Show("Invalid number entered in Mass_textBox.");
            }

        }

        private void Friction_textBox_TextChanged(object sender, EventArgs e)
        {
            tBox_Cursor = 3;

            if (int.TryParse(Friction_textBox.Text, out int value))
            {
                // Ensure the value is within the TrackBar's range
                if (value >= trackBar1.Minimum && value <= trackBar1.Maximum)
                {
                    trackBar1.Value = value; // Set the TrackBar's value
                }
                else
                {
                    MessageBox.Show($"Value must be between {trackBar1.Minimum} and {trackBar1.Maximum}");
                }
            }
            else
            {
                MessageBox.Show("Invalid number entered in Mass_textBox.");
            }
        }

        private void Mass_textBox_Enter(object sender, EventArgs e)
        {
            Mass_textBox_TextChanged(Mass_textBox, e);
        }

        private void Damping_textBox_Enter(object sender, EventArgs e)
        {
            Damping_textBox_TextChanged(Mass_textBox, e);

        }

        private void Friction_textBox_Enter(object sender, EventArgs e)
        {
            Friction_textBox_TextChanged(Mass_textBox, e);


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (tBox_Cursor) {

                case 1:
                    Mass_textBox.Text = trackBar1.Value.ToString();
                    break;
                
                case 2:
                    Damping_textBox.Text = trackBar1.Value.ToString();
                    break;
                
                case 3:
                    Friction_textBox.Text = trackBar1.Value.ToString();
                    break;
                
                default:
                    break;
            }
        }
    } 
}

