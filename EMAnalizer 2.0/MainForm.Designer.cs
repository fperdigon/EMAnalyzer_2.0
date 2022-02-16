namespace EMAnalizer_2._0
{
    partial class MainForm
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
        	System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        	System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
        	System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
        	System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
        	System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
        	System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.eliminaPuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.adicionaPuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.muevePuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ejeXEnTiempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mostrarSeñalVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.navegaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.pruebaSiguienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.pruebaAnteriorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.calibraciónAutomáticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.administrarColoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ayudaDelEMAnalizer20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.acercaDeEMAnalizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
        	this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this.menuStrip1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
        	this.toolStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// menuStrip1
        	// 
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.archivoToolStripMenuItem,
        	        	        	this.ediciónToolStripMenuItem,
        	        	        	this.verToolStripMenuItem,
        	        	        	this.navegaciónToolStripMenuItem,
        	        	        	this.opcionesToolStripMenuItem,
        	        	        	this.ayudaToolStripMenuItem});
        	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip1.Name = "menuStrip1";
        	this.menuStrip1.Size = new System.Drawing.Size(992, 24);
        	this.menuStrip1.TabIndex = 0;
        	this.menuStrip1.Text = "menuStrip1";
        	// 
        	// archivoToolStripMenuItem
        	// 
        	this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.abrirToolStripMenuItem,
        	        	        	this.saveToolStripMenuItem});
        	this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
        	this.archivoToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        	this.archivoToolStripMenuItem.Text = "File";
        	this.archivoToolStripMenuItem.Click += new System.EventHandler(this.ArchivoToolStripMenuItemClick);
        	// 
        	// abrirToolStripMenuItem
        	// 
        	this.abrirToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.Open;
        	this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
        	this.abrirToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
        	this.abrirToolStripMenuItem.Text = "Open";
        	this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
        	// 
        	// saveToolStripMenuItem
        	// 
        	this.saveToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.Save;
        	this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        	this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
        	this.saveToolStripMenuItem.Text = "Save";
        	// 
        	// ediciónToolStripMenuItem
        	// 
        	this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.eliminaPuntoToolStripMenuItem,
        	        	        	this.adicionaPuntoToolStripMenuItem,
        	        	        	this.muevePuntoToolStripMenuItem});
        	this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
        	this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
        	this.ediciónToolStripMenuItem.Text = "Edit";
        	// 
        	// eliminaPuntoToolStripMenuItem
        	// 
        	this.eliminaPuntoToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.DelSaccade;
        	this.eliminaPuntoToolStripMenuItem.Name = "eliminaPuntoToolStripMenuItem";
        	this.eliminaPuntoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.eliminaPuntoToolStripMenuItem.Text = "Delete sacade";
        	this.eliminaPuntoToolStripMenuItem.Click += new System.EventHandler(this.eliminaPuntoToolStripMenuItem_Click);
        	// 
        	// adicionaPuntoToolStripMenuItem
        	// 
        	this.adicionaPuntoToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.AddSaccade;
        	this.adicionaPuntoToolStripMenuItem.Name = "adicionaPuntoToolStripMenuItem";
        	this.adicionaPuntoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.adicionaPuntoToolStripMenuItem.Text = "Insert sacade";
        	this.adicionaPuntoToolStripMenuItem.Click += new System.EventHandler(this.adicionaPuntoToolStripMenuItem_Click);
        	// 
        	// muevePuntoToolStripMenuItem
        	// 
        	this.muevePuntoToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.MovePoint;
        	this.muevePuntoToolStripMenuItem.Name = "muevePuntoToolStripMenuItem";
        	this.muevePuntoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.muevePuntoToolStripMenuItem.Text = "Move Point";
        	this.muevePuntoToolStripMenuItem.Click += new System.EventHandler(this.muevePuntoToolStripMenuItem_Click);
        	// 
        	// verToolStripMenuItem
        	// 
        	this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.ejeXEnTiempoToolStripMenuItem,
        	        	        	this.mostrarSeñalVerticalToolStripMenuItem});
        	this.verToolStripMenuItem.Name = "verToolStripMenuItem";
        	this.verToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.verToolStripMenuItem.Text = "View";
        	// 
        	// ejeXEnTiempoToolStripMenuItem
        	// 
        	this.ejeXEnTiempoToolStripMenuItem.Name = "ejeXEnTiempoToolStripMenuItem";
        	this.ejeXEnTiempoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.ejeXEnTiempoToolStripMenuItem.Text = "X Axis in seconds";
        	// 
        	// mostrarSeñalVerticalToolStripMenuItem
        	// 
        	this.mostrarSeñalVerticalToolStripMenuItem.Name = "mostrarSeñalVerticalToolStripMenuItem";
        	this.mostrarSeñalVerticalToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.mostrarSeñalVerticalToolStripMenuItem.Text = "Show vertical signal";
        	this.mostrarSeñalVerticalToolStripMenuItem.Click += new System.EventHandler(this.mostrarSeñalVerticalToolStripMenuItem_Click);
        	// 
        	// navegaciónToolStripMenuItem
        	// 
        	this.navegaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.pruebaSiguienteToolStripMenuItem,
        	        	        	this.pruebaAnteriorToolStripMenuItem});
        	this.navegaciónToolStripMenuItem.Name = "navegaciónToolStripMenuItem";
        	this.navegaciónToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
        	this.navegaciónToolStripMenuItem.Text = "Navigation";
        	// 
        	// pruebaSiguienteToolStripMenuItem
        	// 
        	this.pruebaSiguienteToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.Forward;
        	this.pruebaSiguienteToolStripMenuItem.Name = "pruebaSiguienteToolStripMenuItem";
        	this.pruebaSiguienteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.pruebaSiguienteToolStripMenuItem.Text = "Next Test";
        	this.pruebaSiguienteToolStripMenuItem.Click += new System.EventHandler(this.pruebaSiguienteToolStripMenuItem_Click);
        	// 
        	// pruebaAnteriorToolStripMenuItem
        	// 
        	this.pruebaAnteriorToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.Back;
        	this.pruebaAnteriorToolStripMenuItem.Name = "pruebaAnteriorToolStripMenuItem";
        	this.pruebaAnteriorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.pruebaAnteriorToolStripMenuItem.Text = "Previous test";
        	this.pruebaAnteriorToolStripMenuItem.Click += new System.EventHandler(this.pruebaAnteriorToolStripMenuItem_Click);
        	// 
        	// opcionesToolStripMenuItem
        	// 
        	this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.calibraciónAutomáticaToolStripMenuItem,
        	        	        	this.administrarColoresToolStripMenuItem});
        	this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
        	this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
        	this.opcionesToolStripMenuItem.Text = "Options";
        	// 
        	// calibraciónAutomáticaToolStripMenuItem
        	// 
        	this.calibraciónAutomáticaToolStripMenuItem.Checked = true;
        	this.calibraciónAutomáticaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.calibraciónAutomáticaToolStripMenuItem.Name = "calibraciónAutomáticaToolStripMenuItem";
        	this.calibraciónAutomáticaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
        	this.calibraciónAutomáticaToolStripMenuItem.Text = "Automatic calibration";
        	// 
        	// administrarColoresToolStripMenuItem
        	// 
        	this.administrarColoresToolStripMenuItem.Name = "administrarColoresToolStripMenuItem";
        	this.administrarColoresToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
        	this.administrarColoresToolStripMenuItem.Text = "Colors Administration";
        	// 
        	// ayudaToolStripMenuItem
        	// 
        	this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.ayudaDelEMAnalizer20ToolStripMenuItem,
        	        	        	this.acercaDeEMAnalizerToolStripMenuItem});
        	this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
        	this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.ayudaToolStripMenuItem.Text = "Help";
        	// 
        	// ayudaDelEMAnalizer20ToolStripMenuItem
        	// 
        	this.ayudaDelEMAnalizer20ToolStripMenuItem.Image = global::EMAnalizer_2._0.Properties.Resources.Help;
        	this.ayudaDelEMAnalizer20ToolStripMenuItem.Name = "ayudaDelEMAnalizer20ToolStripMenuItem";
        	this.ayudaDelEMAnalizer20ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.ayudaDelEMAnalizer20ToolStripMenuItem.Text = "Help EMAnalizer 2.0";
        	// 
        	// acercaDeEMAnalizerToolStripMenuItem
        	// 
        	this.acercaDeEMAnalizerToolStripMenuItem.Name = "acercaDeEMAnalizerToolStripMenuItem";
        	this.acercaDeEMAnalizerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.acercaDeEMAnalizerToolStripMenuItem.Text = "About EMAnalizer 2.0";
        	this.acercaDeEMAnalizerToolStripMenuItem.Click += new System.EventHandler(this.AcercaDeEMAnalizerToolStripMenuItemClick);
        	// 
        	// chart1
        	// 
        	chartArea1.AxisX.MajorGrid.Enabled = false;
        	chartArea1.AxisX.Minimum = 0D;
        	chartArea1.AxisX.ScaleView.Position = 0D;
        	chartArea1.AxisX.ScaleView.Size = 2400D;
        	chartArea1.AxisX.ScaleView.SmallScrollSize = 2400D;
        	chartArea1.AxisY.MajorGrid.Enabled = false;
        	chartArea1.CursorX.IsUserSelectionEnabled = true;
        	chartArea1.CursorY.IsUserSelectionEnabled = true;
        	chartArea1.Name = "ChartArea1";
        	this.chart1.ChartAreas.Add(chartArea1);
        	this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
        	legend1.Name = "Legend1";
        	this.chart1.Legends.Add(legend1);
        	this.chart1.Location = new System.Drawing.Point(12, 55);
        	this.chart1.Name = "chart1";
        	series1.ChartArea = "ChartArea1";
        	series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        	series1.Legend = "Legend1";
        	series1.Name = "Horizontal signal";
        	series2.ChartArea = "ChartArea1";
        	series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        	series2.Color = System.Drawing.Color.Lime;
        	series2.Legend = "Legend1";
        	series2.Name = "Vertical signal";
        	series3.BorderWidth = 2;
        	series3.ChartArea = "ChartArea1";
        	series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        	series3.Color = System.Drawing.Color.Orange;
        	series3.Legend = "Legend1";
        	series3.Name = "Stimulus";
        	series4.ChartArea = "ChartArea1";
        	series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        	series4.Color = System.Drawing.Color.Red;
        	series4.Legend = "Legend1";
        	series4.MarkerSize = 8;
        	series4.Name = "Sacade start";
        	series5.ChartArea = "ChartArea1";
        	series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        	series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	series5.Legend = "Legend1";
        	series5.MarkerSize = 8;
        	series5.Name = "Sacade end";
        	this.chart1.Series.Add(series1);
        	this.chart1.Series.Add(series2);
        	this.chart1.Series.Add(series3);
        	this.chart1.Series.Add(series4);
        	this.chart1.Series.Add(series5);
        	this.chart1.Size = new System.Drawing.Size(968, 300);
        	this.chart1.TabIndex = 1;
        	this.chart1.Text = "chart1";
        	this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
        	this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
        	this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
        	this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripButton1,
        	        	        	this.toolStripButton2,
        	        	        	this.toolStripSeparator1,
        	        	        	this.toolStripButton3,
        	        	        	this.toolStripButton4,
        	        	        	this.toolStripButton5,
        	        	        	this.toolStripSeparator2,
        	        	        	this.toolStripComboBox1,
        	        	        	this.toolStripButton6,
        	        	        	this.toolStripButton7,
        	        	        	this.toolStripSeparator3,
        	        	        	this.toolStripButton9,
        	        	        	this.toolStripButton10,
        	        	        	this.toolStripButton11,
        	        	        	this.toolStripSeparator4,
        	        	        	this.toolStripButton12,
        	        	        	this.toolStripButton13,
        	        	        	this.toolStripSeparator5,
        	        	        	this.toolStripButton8});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 24);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(992, 25);
        	this.toolStrip1.TabIndex = 2;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// toolStripButton1
        	// 
        	this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton1.Image = global::EMAnalizer_2._0.Properties.Resources.Open;
        	this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton1.Name = "toolStripButton1";
        	this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton1.Text = "toolStripButton1";
        	this.toolStripButton1.ToolTipText = "Open a file";
        	this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
        	// 
        	// toolStripButton2
        	// 
        	this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton2.Image = global::EMAnalizer_2._0.Properties.Resources.Save;
        	this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton2.Name = "toolStripButton2";
        	this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton2.Text = "toolStripButton2";
        	this.toolStripButton2.ToolTipText = "Save in *.ema format";
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripButton3
        	// 
        	this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton3.Image = global::EMAnalizer_2._0.Properties.Resources.ZoomIn;
        	this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton3.Name = "toolStripButton3";
        	this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton3.Text = "toolStripButton3";
        	this.toolStripButton3.ToolTipText = "Zoom in";
        	this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
        	// 
        	// toolStripButton4
        	// 
        	this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton4.Image = global::EMAnalizer_2._0.Properties.Resources.ZoomOut;
        	this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton4.Name = "toolStripButton4";
        	this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton4.Text = "toolStripButton4";
        	this.toolStripButton4.ToolTipText = "Zoom out";
        	this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
        	// 
        	// toolStripButton5
        	// 
        	this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton5.Image = global::EMAnalizer_2._0.Properties.Resources.ZoomReset;
        	this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton5.Name = "toolStripButton5";
        	this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton5.Text = "toolStripButton5";
        	this.toolStripButton5.ToolTipText = "Reset Zoom";
        	this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripComboBox1
        	// 
        	this.toolStripComboBox1.MergeIndex = 1;
        	this.toolStripComboBox1.Name = "toolStripComboBox1";
        	this.toolStripComboBox1.Size = new System.Drawing.Size(150, 25);
        	this.toolStripComboBox1.ToolTipText = "Select test";
        	this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
        	// 
        	// toolStripButton6
        	// 
        	this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton6.Image = global::EMAnalizer_2._0.Properties.Resources.Back;
        	this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton6.Name = "toolStripButton6";
        	this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton6.Text = "toolStripButton6";
        	this.toolStripButton6.ToolTipText = "Previous test";
        	this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
        	// 
        	// toolStripButton7
        	// 
        	this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton7.Image = global::EMAnalizer_2._0.Properties.Resources.Forward;
        	this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton7.Name = "toolStripButton7";
        	this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton7.Text = "toolStripButton7";
        	this.toolStripButton7.ToolTipText = "Next Test";
        	this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
        	// 
        	// toolStripSeparator3
        	// 
        	this.toolStripSeparator3.Name = "toolStripSeparator3";
        	this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripButton9
        	// 
        	this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton9.Image = global::EMAnalizer_2._0.Properties.Resources.DelSaccade;
        	this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton9.Name = "toolStripButton9";
        	this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton9.Text = "toolStripButton9";
        	this.toolStripButton9.ToolTipText = "Delete sacade";
        	this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
        	// 
        	// toolStripButton10
        	// 
        	this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton10.Image = global::EMAnalizer_2._0.Properties.Resources.AddSaccade;
        	this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton10.Name = "toolStripButton10";
        	this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton10.Text = "toolStripButton10";
        	this.toolStripButton10.ToolTipText = "Insert sacade";
        	this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
        	// 
        	// toolStripButton11
        	// 
        	this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton11.Image = global::EMAnalizer_2._0.Properties.Resources.MovePoint;
        	this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton11.Name = "toolStripButton11";
        	this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton11.Text = "toolStripButton11";
        	this.toolStripButton11.ToolTipText = "Move point";
        	this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
        	// 
        	// toolStripSeparator4
        	// 
        	this.toolStripSeparator4.Name = "toolStripSeparator4";
        	this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripButton12
        	// 
        	this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton12.Image = global::EMAnalizer_2._0.Properties.Resources.Statistical;
        	this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton12.Name = "toolStripButton12";
        	this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton12.Text = "Open statistical diagrams";
        	this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
        	// 
        	// toolStripButton13
        	// 
        	this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton13.Image = global::EMAnalizer_2._0.Properties.Resources.Tables;
        	this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton13.Name = "toolStripButton13";
        	this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton13.Text = "Open statistical tables";
        	this.toolStripButton13.ToolTipText = "Open statistical tables";
        	this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
        	// 
        	// toolStripSeparator5
        	// 
        	this.toolStripSeparator5.Name = "toolStripSeparator5";
        	this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
        	// 
        	// toolStripButton8
        	// 
        	this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButton8.Image = global::EMAnalizer_2._0.Properties.Resources.Help;
        	this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton8.Name = "toolStripButton8";
        	this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
        	this.toolStripButton8.Text = "Help";
        	this.toolStripButton8.ToolTipText = "Help";
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(992, 367);
        	this.Controls.Add(this.toolStrip1);
        	this.Controls.Add(this.chart1);
        	this.Controls.Add(this.menuStrip1);
        	this.Icon = global::EMAnalizer_2._0.Properties.Resources.EMA;
        	this.MainMenuStrip = this.menuStrip1;
        	this.Name = "MainForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "EMAnalyzer 2.0";
        	this.Load += new System.EventHandler(this.MainFormLoad);
        	this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muevePuntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionaPuntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaPuntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navegaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pruebaSiguienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pruebaAnteriorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaDelEMAnalizer20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeEMAnalizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem ejeXEnTiempoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarSeñalVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibraciónAutomáticaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarColoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        
        void MainFormLoad(object sender, System.EventArgs e)
        {
        	
        }
    }
}

