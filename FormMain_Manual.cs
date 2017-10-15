using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace parus
{
    public partial class FormMain : Form
    {
        // Заполнение списка выбора именами ионограмм.
        private void fill_listboxIonograms(object sender)
        {
            System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(Properties.Settings.Default.settingsWorkingDirectory);
            System.IO.FileInfo[] FI = DI.GetFiles("*.ion");

            listBoxIonograms.Items.Clear();
            for (int i = 0; i < FI.Length; ++i)
                listBoxIonograms.Items.Add(FI[i].Name);
            listBoxIonograms.SelectedIndex = 0;
            listBoxIonograms.Focus();
        }
    }
}
