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
        private void fill_listboxIonograms()
        {
            System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(Properties.Settings.Default.settingsWorkingDirectory);
            System.IO.FileInfo[] FI = DI.GetFiles("*.ion");

            if (FI.Length > 0)
            {
                listBoxIonograms.Items.Clear();
                for (int i = 0; i < FI.Length; ++i)
                    listBoxIonograms.Items.Add(FI[i].Name);
                listBoxIonograms.SelectedIndex = 0;
                listBoxIonograms.Focus();
            }
            else
            {
                DialogResult result = MessageBox.Show(this, "В выбранной папке отсутствуют файлы ионограмм. Выберите другую папку.", "Поиск рабочей папки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    this.toolStripMenuItemOpenDir_Click(null, null);
                }
            }
        }
    }
}
