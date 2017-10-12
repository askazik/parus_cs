using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace parus
{
    public partial class FormMain : Form
    {
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
            
            Properties.Settings.Default.settingsWorkingDirectory = curDir;
            Properties.Settings.Default.Save();

            toolStripStatusLabelDirectory.Text = "Папка :" + curDir;
            fill_listboxIonograms(sender);
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
            toolStripStatusLabelDirectory.Text = "Папка: " + Properties.Settings.Default.settingsWorkingDirectory;
            fill_listboxIonograms(sender);
        }

        private void chartIonogram_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBoxIonograms_Click(object sender, EventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            string ionname = Properties.Settings.Default.settingsWorkingDirectory + "\\" + listbox.SelectedItem.ToString();
            IonogramReader curIonogram = new IonogramReader(ionname);
        }
    }
}
