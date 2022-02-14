using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using PDS;

namespace EMAnalizer_2._0
{
       
    public partial class MainForm : Form
    {
        Pruebas P;

        bool EliminaP = false;
        bool AgregaP = false;
        bool AgregaP1 = true;
        bool MueveP = false;

        


        int ZoomX = 2400;
        double ZoomY = double.NaN;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //openFileDialog1.InitialDirectory = "c:\\" ;
            openFileDialog1.Filter = "Todos los archivos soportados (*.inf; *.csv)|*.inf; *.csv|Archivos MEDICID (*.inf)|*.inf|Archivos OTOSCREEN (.csv)|*.csv";
            openFileDialog1.ShowDialog();

            bool dibujar = true;
            int mostrar = 1;

           /* try
            {
                P = new Pruebas(@openFileDialog1.FileName);
            }

            catch (Exception ex)
            {
                MessageBox.Show("El fichero que intenta abrir no es una prueba sacadica o esta corrupto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dibujar = false; 
            }*/

            P = new Pruebas(@openFileDialog1.FileName);

            if (openFileDialog1.FileName == "" || P == null) dibujar = false;
            if (openFileDialog1.FileName.Contains(".csv") || openFileDialog1.FileName.Contains(".CVS")) {
                mostrar = 2;
            }

            if (dibujar)
            {
                               
                toolStripComboBox1.Items.Clear();
                                

                for (int i = 0; i < P.NomPrueba.Length; i++)
                {
                    toolStripComboBox1.Items.Add(P.NomPrueba[i]);
                }
                toolStripComboBox1.SelectedIndex = mostrar;
                //Al cambiar el numero del combobox el tiene una funcion que grafica al pasar esto
                
            }
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                chart1.Width = MainForm.ActiveForm.Size.Width - 34;
                chart1.Height = MainForm.ActiveForm.Size.Height - 94;
            }
            catch (Exception ex) {
            }
            
             
        }

        private void muevePuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            abrirToolStripMenuItem_Click( sender,  e);
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {

            
            int i = toolStripComboBox1.SelectedIndex;            

            chart1.Series["Señal Horizontal"].Points.DataBindY(P.SHorizontal[i]);
            if (mostrarSeñalVerticalToolStripMenuItem.Checked)
            {
                chart1.Series["Señal Vertical"].Points.DataBindY(P.SVertical[i]);
            }
            else { chart1.Series["Señal Vertical"].Points.Clear(); }
            chart1.Series["Estímulo"].Points.DataBindY(P.SEstimulo[i]);
            chart1.Series["Inicio de sácada"].Points.DataBindXY(P.SacadasI[i], P.SacadasYI[i]);
            chart1.Series["Fin de sácada"].Points.DataBindXY(P.SacadasF[i], P.SacadasYF[i]);
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.ScaleView.Size = ZoomX;
            chart1.ChartAreas[0].AxisY.ScaleView.Size = ZoomY;
            chart1.ChartAreas[0].AxisX.ScaleView.Position = 0;
                  
        }

        private void mostrarSeñalVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarSeñalVerticalToolStripMenuItem.Checked == true) { mostrarSeñalVerticalToolStripMenuItem.Checked = false; }
            else { mostrarSeñalVerticalToolStripMenuItem.Checked = true; }
            toolStripComboBox1_TextChanged(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "" && toolStripComboBox1.SelectedIndex < (P.CantPruebas -1))
            {
                toolStripComboBox1.SelectedIndex++;
                //Al cambiar el numero del combobox el tiene una funcion que grafica al pasar esto
                
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "" && toolStripComboBox1.SelectedIndex>0)
            {
                toolStripComboBox1.SelectedIndex--;
                //Al cambiar el numero del combobox el tiene una funcion que grafica al pasar esto
                
            }
        }

        private void pruebaSiguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton7_Click(sender, e);
        }

        private void pruebaAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton6_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Size = ZoomX;
            chart1.ChartAreas[0].AxisY.ScaleView.Size = ZoomY;            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(chart1.ChartAreas[0].AxisX.ScaleView.Position, chart1.ChartAreas[0].AxisX.ScaleView.Size / 2, chart1.ChartAreas[0].AxisX.ScaleView.SizeType);
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(chart1.ChartAreas[0].AxisY.ScaleView.Position, chart1.ChartAreas[0].AxisY.ScaleView.Size / 2, chart1.ChartAreas[0].AxisY.ScaleView.SizeType);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(chart1.ChartAreas[0].AxisX.ScaleView.Position, chart1.ChartAreas[0].AxisX.ScaleView.Size * 2, chart1.ChartAreas[0].AxisX.ScaleView.SizeType);
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(chart1.ChartAreas[0].AxisY.ScaleView.Position, chart1.ChartAreas[0].AxisY.ScaleView.Size * 2, chart1.ChartAreas[0].AxisY.ScaleView.SizeType);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            
            if (P == null)
            {
                MessageBox.Show("No hay datos que mostar, cargue una prueba.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Diagramas_estadisticos f = new Diagramas_estadisticos(P);
                f.ShowDialog();
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (P != null)
            {
                if (EliminaP == false && AgregaP == false && MueveP == false)
                {
                    EliminaP = true;
                    chart1.Cursor = Cursors.Hand;
                    chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                    chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
                }
                else
                {
                    EliminaP = false;
                    chart1.Cursor = Cursors.Default;
                    chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                    chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("No se puede realizar esta operación, cargue una prueba.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
             if (P != null)
            {
                if (EliminaP == false && AgregaP == false && MueveP == false)
                {
                    AgregaP = true;
                    chart1.Cursor = Cursors.Hand;
                    chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                    chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
                }
                else {
                    AgregaP = false;
                    chart1.Cursor = Cursors.Default;
                    chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                    chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                }
             }
             else {
                MessageBox.Show("No se puede realizar esta operación, cargue una prueba.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
             if (P != null)
            {
             if (EliminaP == false && AgregaP == false && MueveP == false)
                {
                 MueveP = true;
                 chart1.Cursor = Cursors.Hand;
                 chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                 chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
                }
                else
                {
                   MueveP = false;
                   chart1.Cursor = Cursors.Default;
                   chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                   chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                }
            }
             else
             {
                 MessageBox.Show("No se puede realizar esta operación, cargue una prueba.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            double Xe = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            double Ye = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
            
            double X;
            double[]Y;
            int pos = -1;
            bool ini = true;

            int ind = toolStripComboBox1.SelectedIndex; 
            
            

            
            if (EliminaP ) {
                for (int i = 0; i < chart1.Series["Inicio de sácada"].Points.Count; i++)
                {
                    X = chart1.Series["Inicio de sácada"].Points[i].XValue;
                    Y = chart1.Series["Inicio de sácada"].Points[i].YValues;
                    if (X >= Xe - 10 && X <= Xe + 10 && Y[0] >= Ye - 0.8 && Y[0] <= Ye + 0.8)
                    {
                        pos = i;
                        ini = true;
                    }
                }

                for (int i = 0; i < chart1.Series["Fin de sácada"].Points.Count; i++)
                {
                    X = chart1.Series["Fin de sácada"].Points[i].XValue;
                    Y = chart1.Series["Fin de sácada"].Points[i].YValues;
                    if (X >= Xe - 10 && X <= Xe + 10 && Y[0] >= Ye - 0.8 && Y[0] <= Ye + 0.8)
                    {
                        pos = i;
                        ini = false;
                    }
                }
                if (pos != -1){
                    chart1.Series["Inicio de sácada"].Points.RemoveAt(pos);
                    chart1.Series["Fin de sácada"].Points.RemoveAt(pos);
                }

                //Salva en los arregloa que contienen los puntos
                P.SacadasI[ind] = new int[chart1.Series["Inicio de sácada"].Points.Count];
                P.SacadasF[ind] = new int[chart1.Series["Fin de sácada"].Points.Count];
                P.SacadasYI[ind] = new float[chart1.Series["Inicio de sácada"].Points.Count];
                P.SacadasYF[ind] = new float[chart1.Series["Fin de sácada"].Points.Count];
                P.SacadasTI[ind] = new float[chart1.Series["Inicio de sácada"].Points.Count];
                P.SacadasTF[ind] = new float[chart1.Series["Fin de sácada"].Points.Count];

                for (int i = 0; i < P.SacadasI[ind].Length; i++) {
                    P.SacadasI[ind][i] = (int)chart1.Series["Inicio de sácada"].Points[i].XValue;
                    P.SacadasF[ind][i] = (int)chart1.Series["Fin de sácada"].Points[i].XValue;
                    P.SacadasYI[ind][i] = (float) chart1.Series["Inicio de sácada"].Points[i].YValues[0];
                    P.SacadasYF[ind][i] = (float) chart1.Series["Fin de sácada"].Points[i].YValues[0];
                    P.SacadasTI[ind][i] = (float)chart1.Series["Inicio de sácada"].Points[i].XValue/P.Fs;
                    P.SacadasTF[ind][i] = (float)chart1.Series["Fin de sácada"].Points[i].XValue / P.Fs;
                }
                
                chart1.Cursor = Cursors.Default;
                EliminaP=false;                
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                
                
            }

            //Agregar una sacada (primero un pto y despues otro)
            //agregar inteligencia en esta opcion que agrege sobre la señal
            if (AgregaP) {

                int X1 = 0;
                int X2 = 0;
                int[] tmpS;
                bool tranc = false;
                if (AgregaP1)
                { //pto inicio
                    chart1.Series["Inicio de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                    AgregaP1 = false;
                    X1 = (int)Xe;

                    Array.Resize(ref P.SacadasI[ind], chart1.Series["Inicio de sácada"].Points.Count);

                    tmpS = new int[chart1.Series["Inicio de sácada"].Points.Count];

                    P.SacadasI[ind].CopyTo(tmpS, 0);
                    tranc = false;

                    for (int i = 0; i < P.SacadasI[ind].Length - 1; i++)
                    {
                        if (tranc == false)
                        {
                            if (tmpS[i] < X1 && tmpS[i + 1] > X1)
                            {
                                P.SacadasI[ind][i] = tmpS[i];
                                P.SacadasI[ind][i + 1] = X1;
                                tranc = true;
                            }
                            else
                            {
                                P.SacadasI[ind][i] = tmpS[i];
                            }
                        }
                        else
                        {
                            P.SacadasI[ind][i + 1] = tmpS[i ];
                        }
                    }
                }
                else { //Pto final
                    chart1.Series["Fin de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                    AgregaP1 = true;
                    AgregaP = false;
                    chart1.Cursor = Cursors.Default;
                    chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                    chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                   
                    X2 = (int)Xe;

                    Array.Resize(ref P.SacadasF[ind], chart1.Series["Fin de sácada"].Points.Count);
                    P.SacadasYI[ind] = new float[chart1.Series["Inicio de sácada"].Points.Count];
                    P.SacadasYF[ind] = new float[chart1.Series["Fin de sácada"].Points.Count];
                    P.SacadasTI[ind] = new float[chart1.Series["Inicio de sácada"].Points.Count];
                    P.SacadasTF[ind] = new float[chart1.Series["Fin de sácada"].Points.Count];

                    tmpS = new int[chart1.Series["Fin de sácada"].Points.Count];
                    P.SacadasF[ind].CopyTo(tmpS, 0);
                    tranc = false;

                    for (int i = 0; i < P.SacadasF[ind].Length - 1; i++)
                    {
                        if (tranc == false)
                        {
                            if (tmpS[i] < X2 && tmpS[i + 1] > X2)
                            {
                                P.SacadasF[ind][i] = tmpS[i];
                                P.SacadasF[ind][i + 1] = X2;
                                tranc = true;
                            }
                            else
                            {
                                P.SacadasF[ind][i] = tmpS[i];
                            }
                        }
                        else
                        {
                            P.SacadasF[ind][i + 1] = tmpS[i];
                        }
                    }

                    for (int i = 0; i < P.SacadasI[ind].Length; i++)
                    {
                        P.SacadasYI[ind][i] = P.SHorizontal[ind][P.SacadasI[ind][i]];
                        P.SacadasYF[ind][i] = P.SHorizontal[ind][P.SacadasF[ind][i]];
                        P.SacadasTI[ind][i] = (float)P.SacadasI[ind][i] / P.Fs;
                        P.SacadasTF[ind][i] = (float)P.SacadasF[ind][i] / P.Fs;
                    }

                    pos = 1;
                }                
            }

            if (pos >= 0) {

                //Recalculo de la latencia
                P.Latencia[ind] = new float[P.SacadasI[ind].Length];
                int ltmp;
                for (int i = 0; i < P.SacadasI[ind].Length; i++)
                {
                    P.Latencia[ind][i] = 1000000;
                    for (int j = 0; j < P.CE[ind].Length; j++)
                    {
                        ltmp = P.SacadasI[ind][i] - P.CE[ind][j];
                        if (ltmp < P.Latencia[ind][i] && ltmp > 0)
                        {
                            P.Latencia[ind][i] = P.SacadasI[ind][i] - P.CE[ind][j];
                        }
                    }

                }

                //Recalculo de la amplitud de las sacadas
                P.ASacadas[ind] = new float[P.SacadasI[ind].Length];
                for (int i = 0; i < P.SacadasI[ind].Length; i++)
                {
                    P.ASacadas[ind][i] = P.SacadasYF[ind][i] - P.SacadasYI[ind][i];
                }
            }


        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (P == null)
            {
                MessageBox.Show("No hay datos que mostar, cargue una prueba.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Tables f = new Tables(P);
                f.ShowDialog();
            }
        }

        private void adicionaPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton10_Click(sender, e);
        }

        private void eliminaPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton9_Click(sender, e);
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MueveP) {

                double Xe = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                double Ye = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                double X;
                double[] Y;
                int pos = -1;
                bool ini = true; // bandera de inicio de sacada

                int ind = toolStripComboBox1.SelectedIndex; 

                for (int i = 0; i < chart1.Series["Inicio de sácada"].Points.Count; i++)
                {
                    X = chart1.Series["Inicio de sácada"].Points[i].XValue;
                    Y = chart1.Series["Inicio de sácada"].Points[i].YValues;
                    if (X >= Xe - 10 && X <= Xe + 10 && Y[0] >= Ye - 0.8 && Y[0] <= Ye + 0.8)
                    {
                        pos = i;
                        ini = true;
                        Pto.X = P.SacadasI[ind][pos];
                        Pto.Y = P.SacadasYI[ind][pos];
                    }
                }

                for (int i = 0; i < chart1.Series["Fin de sácada"].Points.Count; i++)
                {
                    X = chart1.Series["Fin de sácada"].Points[i].XValue;
                    Y = chart1.Series["Fin de sácada"].Points[i].YValues;
                    if (X >= Xe - 10 && X <= Xe + 10 && Y[0] >= Ye - 0.8 && Y[0] <= Ye + 0.8)
                    {
                        pos = i;
                        ini = false;
                        Pto.X = P.SacadasF[ind][pos];
                        Pto.Y = P.SacadasYF[ind][pos];
                    }
                }

                Pto.Pos = pos;
                Pto.ini = ini;

                Pto.ptoSel = true;                
                Pto.X = (int)Xe;
                Pto.Y = P.SHorizontal[ind][(int)Xe];
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {

            if (MueveP && Pto.ptoSel==true && Pto.Pos != -1)
            {
                double Xe = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                int ind = toolStripComboBox1.SelectedIndex;

                if (Pto.primera)//primera vez que se mueve el punto
                {
                    Pto.primera = false;
                    if (Pto.ini == true)
                    {
                        if (Pto.Pos == 0)
                        {
                            if (Xe < P.SacadasF[ind][Pto.Pos] && Xe > 0)//condicion para la primera sacada
                            {
                                chart1.Series["Inicio de sácada"].Points.RemoveAt(Pto.Pos);
                                chart1.Series["Inicio de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                                Pto.X = (int)Xe;
                                Pto.Y = P.SHorizontal[ind][(int)Xe];
                            }
                        }
                        else
                        {
                            if (Xe > P.SacadasF[ind][Pto.Pos - 1] && Xe < P.SacadasF[ind][Pto.Pos])
                            {
                                chart1.Series["Inicio de sácada"].Points.RemoveAt(Pto.Pos);
                                chart1.Series["Inicio de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                                Pto.X = (int)Xe;
                                Pto.Y = P.SHorizontal[ind][(int)Xe];
                            }
                        }
                    }
                    else
                    {
                        if (Xe > P.SacadasI[ind][Pto.Pos] && Xe < P.SacadasI[ind][Pto.Pos + 1])
                        {
                            chart1.Series["Fin de sácada"].Points.RemoveAt(Pto.Pos);                            
                            chart1.Series["Fin de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                            Pto.X = (int)Xe;
                            Pto.Y = P.SHorizontal[ind][(int)Xe];
                        }
                    }
                    
                }
                else //demas veces
                {
                    if (Pto.ini == true)
                    {
                        if (Pto.Pos == 0)
                        {
                            if (Xe < P.SacadasF[ind][Pto.Pos] && Xe>0)//condicion para la primera sacada
                            {
                                chart1.Series["Inicio de sácada"].Points.RemoveAt(0);
                                chart1.Series["Inicio de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                                Pto.X = (int)Xe;
                                Pto.Y = P.SHorizontal[ind][(int)Xe];
                            }
                        }
                        else
                        {
                            if (Xe > P.SacadasF[ind][Pto.Pos - 1] && Xe < P.SacadasF[ind][Pto.Pos])
                            {
                                chart1.Series["Inicio de sácada"].Points.RemoveAt(0);
                                chart1.Series["Inicio de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                                Pto.X = (int)Xe;
                                Pto.Y = P.SHorizontal[ind][(int)Xe];
                            }
                        }
                    }
                    else
                    {
                        if (Xe > P.SacadasI[ind][Pto.Pos] && Xe < P.SacadasI[ind][Pto.Pos + 1])
                        {
                            chart1.Series["Fin de sácada"].Points.RemoveAt(0);
                            chart1.Series["Fin de sácada"].Points.InsertXY(0, Xe, P.SHorizontal[ind][(int)Xe]);
                            Pto.X = (int)Xe;
                            Pto.Y = P.SHorizontal[ind][(int)Xe];
                        }
                    }
                  
                

                }
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (MueveP && Pto.ptoSel == true && Pto.Pos != -1)
            {
                Pto.ptoSel = false;
                Pto.primera = true;
                double Xe = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                int ind = toolStripComboBox1.SelectedIndex;

                if (Pto.ini == true)
                {
                    P.SacadasI[ind][Pto.Pos] = Pto.X;
                    P.SacadasYI[ind][Pto.Pos] = P.SHorizontal[ind][Pto.X];
                    P.SacadasTI[ind][Pto.Pos] = (float)Pto.X / P.Fs;
                }
                else
                {
                    P.SacadasF[ind][Pto.Pos] = Pto.X;
                    P.SacadasYF[ind][Pto.Pos] = P.SHorizontal[ind][Pto.X];
                    P.SacadasTF[ind][Pto.Pos] = (float)Pto.X / P.Fs;
                }

                //Repintar todo
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();
                chart1.Series[4].Points.Clear();

                Repinta();
                
                chart1.Cursor = Cursors.Default;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                MueveP = false;
                Pto.inicia();
                
            }
        }

        private void Repinta()
        {
            int i = toolStripComboBox1.SelectedIndex;

            chart1.Series["Señal Horizontal"].Points.DataBindY(P.SHorizontal[i]);
            if (mostrarSeñalVerticalToolStripMenuItem.Checked)
            {
                chart1.Series["Señal Vertical"].Points.DataBindY(P.SVertical[i]);
            }
            else { chart1.Series["Señal Vertical"].Points.Clear(); }
            chart1.Series["Estímulo"].Points.DataBindY(P.SEstimulo[i]);
            chart1.Series["Inicio de sácada"].Points.DataBindXY(P.SacadasI[i], P.SacadasYI[i]);
            chart1.Series["Fin de sácada"].Points.DataBindXY(P.SacadasF[i], P.SacadasYF[i]);            

        }
         
        
        void AcercaDeEMAnalizerToolStripMenuItemClick(object sender, EventArgs e)
        {
        	MessageBox.Show("EMAnalyzer 2.0 es un software para el procesamiento y analisys de señales electro-oculográficas", "Acerca de EMAnalyzer 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    
}
