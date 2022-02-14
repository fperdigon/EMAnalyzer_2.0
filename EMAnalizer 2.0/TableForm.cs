using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMAnalizer_2._0
{
    public partial class TableForm : Form
    {        

        public TableForm(Pruebas P)
        {
            InitializeComponent();


            int i = 2;//poner numero corecto
			dataGridView1.ColumnCount = P.ASacadas[i].Length - 1;            

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =  new Font(dataGridView1.Font, FontStyle.Bold);           

            dataGridView1.AutoSizeRowsMode =  DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;         

            //aqui se rellena con un for para la cantidad de sacadas
            dataGridView1.Columns[0].Name = "Parametros";
            int AmEst = 10;
            
            for (int j = 1; j < P.ASacadas[i].Length-1 ; j++)
            {
                dataGridView1.Columns[j].Name = j.ToString();
            }
            string[] row1 = new string[P.ASacadas[i].Length];
            row1[0] = "Amplitud (°)";
            string[] row2 = new string[P.ASacadas[i].Length];
            row2[0] = "Desviación (°)";
            string[] row3 = new string[P.ASacadas[i].Length];
            row3[0] = "Velocidad (°/seg)";
            string[] row4 = new string[P.ASacadas[i].Length];
            row4[0] = "Latencia (ms)";
            
            for (int j = 1; j < P.ASacadas[i].Length-1 ; j++)
            {
                row1[j] = Math.Abs(P.ASacadas[i][j]).ToString();
                row2[j] = (Math.Abs(P.ASacadas[i][j]) - AmEst).ToString();
                row3[j] = Math.Abs((P.ASacadas[i][j] * P.Fs) / (P.SacadasF[i][j] - P.SacadasI[i][j])).ToString();
                row4[j] = P.Latencia[i][j].ToString();
            }           
           
            //para dar estilo
            dataGridView1.Columns[4].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Italic);           
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Dock = DockStyle.Fill;           

            //llenado de la tabla
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            dataGridView1.Rows.Add(row4);


            //TABLA 2

            i = 2;//poner numero corecto  
            //numero de columnas
            dataGridView2.ColumnCount = P.ASacadas[i].Length - 1;

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView2.GridColor = Color.Black;
            dataGridView2.RowHeadersVisible = false;

            //aqui se rellena con un for para la cantidad de sacadas
            dataGridView2.Columns[0].Name = "Parametros";
            AmEst = 20;

            for (int j = 1; j < P.ASacadas[i].Length - 1; j++)
            {
                dataGridView2.Columns[j].Name = j.ToString();
            }
            
            row1[0] = "Amplitud (°)";
            
            row2[0] = "Desviación (°)";
            
            row3[0] = "Velocidad (°/seg)";
            
            row4[0] = "Latencia (ms)";

            for (int j = 1; j < P.ASacadas[i].Length - 1; j++)
            {
                row1[j] = Math.Abs(P.ASacadas[i][j]).ToString();
                row2[j] = (Math.Abs(P.ASacadas[i][j]) - AmEst).ToString();
                row3[j] = Math.Abs((P.ASacadas[i][j] * P.Fs) / (P.SacadasF[i][j] - P.SacadasI[i][j])).ToString();
                row4[j] = P.Latencia[i][j].ToString();
            }

            //para dar estilo
            dataGridView2.Columns[4].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Italic);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.Dock = DockStyle.Fill;

            //llenado de la tabla
            dataGridView2.Rows.Add(row1);
            dataGridView2.Rows.Add(row2);
            dataGridView2.Rows.Add(row3);
            dataGridView2.Rows.Add(row4);

            //TABLA 3

            i = 3;//poner numero corecto  
            //numero de columnas
            dataGridView3.ColumnCount = P.ASacadas[i].Length - 1;

            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView3.GridColor = Color.Black;
            dataGridView3.RowHeadersVisible = false;

            //aqui se rellena con un for para la cantidad de sacadas
            dataGridView3.Columns[0].Name = "Parametros";
            AmEst = 30;

            for (int j = 1; j < P.ASacadas[i].Length - 1; j++)
            {
                dataGridView3.Columns[j].Name = j.ToString();
            }

            row1[0] = "Amplitud (°)";

            row2[0] = "Desviación (°)";

            row3[0] = "Velocidad (°/seg)";

            row4[0] = "Latencia (ms)";

            for (int j = 1; j < P.ASacadas[i].Length - 1; j++)
            {
                row1[j] = Math.Abs(P.ASacadas[i][j]).ToString();
                row2[j] = (Math.Abs(P.ASacadas[i][j]) - AmEst).ToString();
                row3[j] = Math.Abs((P.ASacadas[i][j] * P.Fs) / (P.SacadasF[i][j] - P.SacadasI[i][j])).ToString();
                row4[j] = P.Latencia[i][j].ToString();
            }

            //para dar estilo
            dataGridView3.Columns[4].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Italic);
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
            dataGridView3.Dock = DockStyle.Fill;

            //llenado de la tabla
            dataGridView3.Rows.Add(row1);
            dataGridView3.Rows.Add(row2);
            dataGridView3.Rows.Add(row3);
            dataGridView3.Rows.Add(row4);

            //TABLA 4

            i = 4;//poner numero corecto  
            //numero de columnas
            dataGridView4.ColumnCount = P.ASacadas[i].Length - 1;

            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView4.GridColor = Color.Black;
            dataGridView4.RowHeadersVisible = false;

            //aqui se rellena con un for para la cantidad de sacadas
            dataGridView4.Columns[0].Name = "Parametros";
            AmEst = 60;

            for (int j = 1; j < P.ASacadas[i].Length - 1; j++)
            {
                dataGridView4.Columns[j].Name = j.ToString();
            }

            row1[0] = "Amplitud (°)";

            row2[0] = "Desviación (°)";

            row3[0] = "Velocidad (°/seg)";

            row4[0] = "Latencia (ms)";

            for (int j = 1; j < P.ASacadas[i].Length - 1; j++)
            {
                row1[j] = Math.Abs(P.ASacadas[i][j]).ToString();
                row2[j] = (Math.Abs(P.ASacadas[i][j]) - AmEst).ToString();
                row3[j] = Math.Abs((P.ASacadas[i][j] * P.Fs) / (P.SacadasF[i][j] - P.SacadasI[i][j])).ToString();
                row4[j] = P.Latencia[i][j].ToString();
            }

            //para dar estilo
            dataGridView4.Columns[4].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Italic);
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.MultiSelect = false;
            dataGridView4.Dock = DockStyle.Fill;

            //llenado de la tabla
            dataGridView4.Rows.Add(row1);
            dataGridView4.Rows.Add(row2);
            dataGridView4.Rows.Add(row3);
            dataGridView4.Rows.Add(row4);
            
        }

        private void Tablas_Load(object sender, EventArgs e)
        {

        }
    }
}
