using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace EMAnalizer_2._0
{
    public partial class StatisticalDiagramsForm : Form
    {
        Test_T P;
        public StatisticalDiagramsForm()
        {
            InitializeComponent();
        }
        public StatisticalDiagramsForm(Test_T p)
        {
            InitializeComponent();
            P = p;
            
            //Dibujo de lineas
            //primer diagrama
            chart1.Series[1].Points.DataBindXY(new int[3] { -63, 0, 63 }, new double[3] { 50.4, 0, 50.4 });
            chart1.Series[0].Points.DataBindXY(new int[3] { -63, 0, 63 }, new double[3] { 75.6,0, 75.6 });
            
            //segundo diagrama
            //chart2.Series[1].Points.DataBindXY(new int[13] { -68,-54, -40,-30, -20, -12, 0, 12, 20, 30, 40, 54, 68 }, new double[13] { 480, 430, 375, 320, 240, 150, 0, 150, 240, 320, 375, 430, 480 });
            chart2.Series[0].Points.DataBindXY(new int[13] { -68, -54, -40, -30, -20, -12, 0, 12, 20, 30, 40, 54, 68 }, new double[13] { 380, 330, 275, 220, 140, 50, -100, 50, 140, 220, 275, 330, 380 });
            //tercer diagrama
            chart3.Series[0].Points.DataBindXY(new int[3] { -63, 0, 63 }, new double[3] { 8.4, 0, 8.4 });
            chart3.Series[1].Points.DataBindXY(new int[3] { -63, 0, 63 }, new double[3] { -8.4, 0, -8.4 });
            
            //cuarto diagrama
            chart4.Series[0].Points.DataBindXY(new int[3] { -63, 0, 63 }, new double[3] {275, 200, 275 });
            


            float AmEst;
            for (int i = 1; i < P.CantPruebas -1; i++) { 
                for (int j = 1; j < P.ASacadas[i].Length-1; j++) {

                    
                    AmEst= P.SEstimulo[i][(P.SacadasI[i][j])] - P.SEstimulo[i][(P.SacadasI[i][j-1])];
                    if (AmEst == 0 && j>1) {
                        AmEst = P.SEstimulo[i][(P.SacadasI[i][j])] - P.SEstimulo[i][(P.SacadasI[i][j - 2])];
                    }

                    if (AmEst == 0 && j <= 1)
                    {
                        AmEst = P.SEstimulo[i][(P.SacadasI[i][j])]*2;
                    }

                    //Amplitud de las sacadas
                    chart1.Series[2].Points.InsertXY(0, AmEst, Math.Abs(P.ASacadas[i][j]));          
                    //Velocidad sacadica
                    chart2.Series[1].Points.InsertXY(0, AmEst, Math.Abs((P.ASacadas[i][j] * P.Fs) / (P.SacadasF[i][j] - P.SacadasI[i][j]))); 
                    //Desviacion
                    chart3.Series[2].Points.InsertXY(0, AmEst, P.ASacadas[i][j] - AmEst);
                    //Latencia
                    chart4.Series[1].Points.InsertXY(0, AmEst, P.Latencia[i][j]); 
                }
            }

            
        }
               

        
    }
}
