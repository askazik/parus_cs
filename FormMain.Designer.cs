﻿namespace parus
{
    partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 0D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageIonogram = new System.Windows.Forms.TabPage();
            this.chartIonogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelIonogramFiles = new System.Windows.Forms.Panel();
            this.listBoxIonograms = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelpContent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDirectory = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl.SuspendLayout();
            this.tabPageIonogram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIonogram)).BeginInit();
            this.panelIonogramFiles.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageIonogram);
            this.tabControl.Controls.Add(this.tabPageParameters);
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(798, 386);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageIonogram
            // 
            this.tabPageIonogram.Controls.Add(this.chartIonogram);
            this.tabPageIonogram.Controls.Add(this.panelIonogramFiles);
            this.tabPageIonogram.Location = new System.Drawing.Point(4, 22);
            this.tabPageIonogram.Name = "tabPageIonogram";
            this.tabPageIonogram.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIonogram.Size = new System.Drawing.Size(790, 360);
            this.tabPageIonogram.TabIndex = 0;
            this.tabPageIonogram.Text = "Ионограмма";
            this.tabPageIonogram.UseVisualStyleBackColor = true;
            // 
            // chartIonogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chartIonogram.ChartAreas.Add(chartArea1);
            this.chartIonogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartIonogram.Location = new System.Drawing.Point(3, 3);
            this.chartIonogram.Name = "chartIonogram";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            this.chartIonogram.Series.Add(series1);
            this.chartIonogram.Size = new System.Drawing.Size(596, 354);
            this.chartIonogram.TabIndex = 5;
            this.chartIonogram.Text = "chart1";
            // 
            // panelIonogramFiles
            // 
            this.panelIonogramFiles.Controls.Add(this.listBoxIonograms);
            this.panelIonogramFiles.Controls.Add(this.label1);
            this.panelIonogramFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelIonogramFiles.Location = new System.Drawing.Point(599, 3);
            this.panelIonogramFiles.Name = "panelIonogramFiles";
            this.panelIonogramFiles.Size = new System.Drawing.Size(188, 354);
            this.panelIonogramFiles.TabIndex = 0;
            // 
            // listBoxIonograms
            // 
            this.listBoxIonograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxIonograms.FormattingEnabled = true;
            this.listBoxIonograms.Location = new System.Drawing.Point(0, 13);
            this.listBoxIonograms.Margin = new System.Windows.Forms.Padding(10);
            this.listBoxIonograms.Name = "listBoxIonograms";
            this.listBoxIonograms.Size = new System.Drawing.Size(188, 341);
            this.listBoxIonograms.TabIndex = 1;
            this.listBoxIonograms.Click += new System.EventHandler(this.listBoxIonograms_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ионограммы в рабочей папке";
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameters.Size = new System.Drawing.Size(790, 360);
            this.tabPageParameters.TabIndex = 1;
            this.tabPageParameters.Text = "Параметры";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(798, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenFile,
            this.toolStripMenuItemOpenDir,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItemFile.Text = "Файл";
            // 
            // toolStripMenuItemOpenFile
            // 
            this.toolStripMenuItemOpenFile.Name = "toolStripMenuItemOpenFile";
            this.toolStripMenuItemOpenFile.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemOpenFile.Text = "Открыть файл...";
            this.toolStripMenuItemOpenFile.Click += new System.EventHandler(this.toolStripMenuItemOpenFile_Click);
            // 
            // toolStripMenuItemOpenDir
            // 
            this.toolStripMenuItemOpenDir.Name = "toolStripMenuItemOpenDir";
            this.toolStripMenuItemOpenDir.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemOpenDir.Text = "Рабочая папка...";
            this.toolStripMenuItemOpenDir.Click += new System.EventHandler(this.toolStripMenuItemOpenDir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemExit.Text = "Выход";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHelpContent,
            this.toolStripMenuItemHelpAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(65, 20);
            this.toolStripMenuItemHelp.Text = "Справка";
            // 
            // toolStripMenuItemHelpContent
            // 
            this.toolStripMenuItemHelpContent.Name = "toolStripMenuItemHelpContent";
            this.toolStripMenuItemHelpContent.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.toolStripMenuItemHelpContent.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemHelpContent.Text = "Содержание";
            // 
            // toolStripMenuItemHelpAbout
            // 
            this.toolStripMenuItemHelpAbout.Name = "toolStripMenuItemHelpAbout";
            this.toolStripMenuItemHelpAbout.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemHelpAbout.Text = "О программе";
            this.toolStripMenuItemHelpAbout.Click += new System.EventHandler(this.toolStripMenuItemHelpAbout_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Рабочая папка";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Ионограммы (*.ion)|*.ion|Амплитуды (*.frq)|*.frq|Все файлы (*.*)|*.*";
            this.openFileDialog.Title = "Открыть файл";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDirectory});
            this.statusStrip.Location = new System.Drawing.Point(0, 413);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(798, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDirectory
            // 
            this.toolStripStatusLabelDirectory.Name = "toolStripStatusLabelDirectory";
            this.toolStripStatusLabelDirectory.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabelDirectory.Text = "Папка: ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 435);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "Интерфейс к ионозонду \"Парус\" НИИФ ЮФУ";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.tabControl.ResumeLayout(false);
            this.tabPageIonogram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIonogram)).EndInit();
            this.panelIonogramFiles.ResumeLayout(false);
            this.panelIonogramFiles.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageIonogram;
        private System.Windows.Forms.TabPage tabPageParameters;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpContent;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpAbout;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDirectory;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIonogram;
        private System.Windows.Forms.Panel panelIonogramFiles;
        private System.Windows.Forms.ListBox listBoxIonograms;
        private System.Windows.Forms.Label label1;
    }
}
