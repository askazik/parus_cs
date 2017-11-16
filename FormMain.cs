using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using System.IO;

namespace parus
{
    public partial class FormMain : Form
    {
        IonogramReader curIonogram = null; // информация о текущей ионограмме

        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemOpenDir_Click(object sender, EventArgs e)
        {
            string curDir = Properties.Settings.Default.settingsWorkingDirectory;

            if (!String.IsNullOrEmpty(curDir))
                folderBrowserDialog.SelectedPath = curDir;
            else
                curDir = System.IO.Directory.GetCurrentDirectory();
            folderBrowserDialog.SelectedPath = curDir;
            
            // Update the working directory if the user clicks OK 
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                curDir = folderBrowserDialog.SelectedPath;

            // Попробуем поменять путь
            fill_listboxIonograms(curDir);
        }

        // Заполнение списка выбора именами ионограмм.
        private void fill_listboxIonograms(string curDir)
        {
            System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(curDir);
            System.IO.FileInfo[] FI = DI.GetFiles("*.ion");

            if (FI.Length > 0)
            {
                Properties.Settings.Default.settingsWorkingDirectory = curDir;
                Properties.Settings.Default.Save();
                toolStripStatusLabelDirectory.Text = "Папка :" + curDir;

                listBoxIonograms.Items.Clear();
                for (int i = 0; i < FI.Length; ++i)
                    listBoxIonograms.Items.Add(FI[i].Name);
                listBoxIonograms.SelectedIndex = listBoxIonograms.Items.Count-1;
                listBoxIonograms.Focus();
            }
            else
            {
                // Displays the MessageBox.
                DialogResult result = MessageBox.Show(
                    "В выбранной папке " + curDir + 
                    " отсутствуют файлы ионограмм *.ion. Выберите для работы другую папку!",
                    "Отсутствуют ионограммы!", MessageBoxButtons.OK);
            }
        }

        private void toolStripMenuItemOpenFile_Click(object sender, EventArgs e)
        {
            string curDir = Properties.Settings.Default.settingsWorkingDirectory;

            if (!String.IsNullOrEmpty(curDir))
                openFileDialog.InitialDirectory = curDir;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {

        }

        private void chartIonogram_Paint(object sender, PaintEventArgs e)
        {
            if (listBoxIonograms.Items.Count > 0)
            {
                string ionname = Properties.Settings.Default.settingsWorkingDirectory + "\\";

                if (curIonogram == null)
                {
                    ionname = Properties.Settings.Default.settingsWorkingDirectory + "\\" + this.listBoxIonograms.Items[0].ToString();
                    curIonogram = new IonogramReader(ionname);
                }

                //Point loc = chartIonogram.Location;
                //Size siz = chartIonogram.Size;
                //Padding mar = chartIonogram.Margin;
                //ElementPosition posChart = chartIonogram.ChartAreas[0].InnerPlotPosition;
                //e.Graphics.DrawImage(curIonogram.Bitmap_O, mar.Left + loc.X + siz.Width * posChart.X/100, mar.Top + loc.Y + siz.Height * posChart.Y/100);

                ChartArea a = chartIonogram.ChartAreas[0];
                int x1 = (int)a.AxisX.ValueToPixelPosition(a.AxisX.Minimum) + a.AxisX.LineWidth;
                int x2 = (int)a.AxisX.ValueToPixelPosition(a.AxisX.Maximum) - a.AxisX.LineWidth;
                int y1 = (int)a.AxisY.ValueToPixelPosition(a.AxisY.Maximum) + a.AxisY.LineWidth;
                int y2 = (int)a.AxisY.ValueToPixelPosition(a.AxisY.Minimum) - a.AxisY.LineWidth;

                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                if (curIonogram.Bitmap_O != null)
                    e.Graphics.DrawImage(curIonogram.Bitmap_O, new Rectangle(x1, y1, x2 - x1, y2 - y1));
            }
        }

        private void listBoxIonograms_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            string ionname = Properties.Settings.Default.settingsWorkingDirectory + "\\" + listbox.SelectedItem.ToString();
            curIonogram = new IonogramReader(ionname);

            chartIonogram.Invalidate();

            chartIonogram.Titles["TitleTimeIonogram"].Text = curIonogram.TimeString;
            chartIonogram.ChartAreas["ChartAreaIonogram"].AxisX.Minimum = curIonogram.Header.freq_min/1000.0;
            chartIonogram.ChartAreas["ChartAreaIonogram"].AxisX.Maximum = curIonogram.Header.freq_max/1000.0;
            chartIonogram.ChartAreas["ChartAreaIonogram"].AxisX.Interval = 1;

            chartIonogram.ChartAreas["ChartAreaIonogram"].AxisY.Minimum = (int)(curIonogram.Header.height_min/1000.0);
            chartIonogram.ChartAreas["ChartAreaIonogram"].AxisY.Maximum = (int)(curIonogram.Header.height_min +
                curIonogram.Header.height_step * (curIonogram.Header.count_height-1))/1000.0;
            chartIonogram.ChartAreas["ChartAreaIonogram"].AxisY.Interval = 100.0;
         }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string curDir = Properties.Settings.Default.settingsWorkingDirectory;
            if (Directory.Exists(curDir))
                fill_listboxIonograms(curDir); // попробуем заполнить список ионограмм
        }

        private void toolStripButtonChangeDir_Click(object sender, EventArgs e)
        {
            toolStripMenuItemOpenDir_Click(sender, e);
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            string curDir = Properties.Settings.Default.settingsWorkingDirectory;

            // Попробуем поменять путь
            fill_listboxIonograms(curDir);
        }

    }
}
