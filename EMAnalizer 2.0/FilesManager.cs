using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/*************************************************
 * Programador: Francisco Perdigon Romero 
 * Tutor: Dr. Carlos R. Vázquez Seisdedos
 * Este código permite la entrada de datos
 * de los archivos que fueron generados con
 * los equipos MEDICID y OTOSCREEN
*************************************************/

namespace FilesManager
{
    public class PLG
    {
        public int CantCanales;
        public int CantPuntos;
        public float FrecMuestreo;
        public float[][] Signals;
        public float[][] RSignals;
        public float[] Tiempo;
        public int[] Marcas; 
        public byte[] IDMarcas;
        public float[] Ganancia;
        public float[] HighCut;
        public float[] LowCut;

        private float[] Cal;
        private float[] DC;
        


        public PLG(string direccion) //direccion debe contener la direccion del .inf
        {
            readINF(@direccion);
            readCDC(@direccion);            

            Signals = new float[CantCanales][];
            for (int i = 0; i < CantCanales; i++) Signals[i] = new float[CantPuntos];
            string direccion1 = direccion.Replace(".inf", ".plg");
            FileStream inputStream = File.OpenRead(@direccion1);
            BinaryReader r = new BinaryReader(inputStream);
            for (int i = 0; i < CantPuntos; i++)
            {
                for (int j = 0; j < CantCanales; j++)
                {
                    Signals[j][i] = r.ReadInt16();
                    Signals[j][i] = Signals[j][i] * Cal[j] - DC[j];
                }
            }

            //creacion de arreglo tiempo            
            Tiempo = new float[CantPuntos];
            for (int i = 0; i < CantPuntos; i++) { Tiempo[i] = i / FrecMuestreo; }

            RSignals = Signals;

            /*
            //Los canales son no diferenciales, la señal de los ojos si, 
            //para convertir la senal en diferencial se resta una de otra en canales
            //sucesivos
            RSignals = new float[CantCanales / 2][];
            for (int i = 0; i < CantCanales / 2; i++) RSignals[i] = new float[CantPuntos];

            for (int i = 0; i < CantCanales / 2; i++)
            {
                for (int j = 0; j < CantPuntos; j++)
                {
                    RSignals[i][j] = Signals[(i * 2) + 1][j] - Signals[i * 2][j];
                    //RSignals[i][j] = Signals[i * 2][j] - Signals[(i * 2) + 1][j];  
                }
            }*/

            readMKR(@direccion);
        }

        //Esta función realiza la lectura del archivo .inf y extrae 
        //parametros importantes del mismo
        private void readINF(string direccion)
        {

            FileInfo INFfile = new FileInfo(@direccion);
            StreamReader st = INFfile.OpenText();
            string text;
            int i = 0;

            do
            {
                text = st.ReadLine();
                i++;
            } while (text != null);
            st.Close();


            st = INFfile.OpenText();
            String[] INF = new string[i];

            i = 0;
            do
            {
                INF[i] = st.ReadLine();
                i++;
            } while (INF[i - 1] != null);

            st.Close();

            //Busqueda Cant Canales
            for (i = 0; i < INF.Length; i++)
            {
                if (INF[i].Contains("PLGNC")) break;
            }

            string[] partes = INF[i].Split(new Char[] { ' ' });
            CantCanales = int.Parse(partes[3]);

            //Busqueda Cant Puntos
            for (i = 0; i < INF.Length; i++)
            {
                if (INF[i].Contains("PLGNS")) break;
            }
            partes = INF[i].Split(new Char[] { ' ' });
            CantPuntos = int.Parse(partes[3]);

           /* 
            //ESTOS PARAMETROS (NO SON IMPRESCINDIBLES) ESTAN DANDO ERROR EN LOS NUEVOS REGISTROS
            //(BUSCAR SOLUCION)
            
            //Busqueda Frec de Muestreo
            for (i = 0; i < INF.Length; i++)
            {
                if (INF[i].Contains("PLGSR(Hz)")) break;
            }

            partes = INF[i].Split(new Char[] { ' ' });
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            FrecMuestreo = float.Parse(partes[partes.Length - 1], nfi);

            //Busqueda Ganancia
            for (i = 0; i < INF.Length; i++)
            {
                if (INF[i].Contains("Gains")) break;
            }
            Ganancia = new float[CantCanales];
            partes = INF[i].Split(new Char[] { ' ' });
            for (i = 0; i < CantCanales; i++)
            {
                Ganancia[i] = float.Parse(partes[i + 3], nfi);
            }

            //Busqueda Frecuencia de corte alta
            for (i = 0; i < INF.Length; i++)
            {
                if (INF[i].Contains("HCut(Hz)")) break;
            }
            HighCut = new float[CantCanales];
            partes = INF[i].Split(new Char[] { ' ' });
            for (i = 0; i < CantCanales; i++)
            {
                HighCut[i] = float.Parse(partes[i + 3], nfi);
            }

            //Busqueda Frecuencia de corte baja
            for (i = 0; i < INF.Length; i++)
            {
                if (INF[i].Contains("LCut(Hz)")) break;
            }
            LowCut = new float[CantCanales];
            partes = INF[i].Split(new Char[] { ' ' });
            for (i = 0; i < CantCanales; i++)
            {
                LowCut[i] = float.Parse(partes[i + 3], nfi);
            }
            */
        }

        //Esta función realiza la lectura del archivo .cdc para extraer
        //el valor para la conversion a microvoltios
        private void readCDC(string direccion) {
            Cal = new float[CantCanales];
            DC = new float[CantCanales];

            direccion = direccion.Replace(".inf", ".cdc");
            FileStream inputStream = File.OpenRead(@direccion);
            BinaryReader r = new BinaryReader(inputStream);

            for (int i = 0; i < CantCanales; i++) {
                Cal[i] = r.ReadSingle()/10;
                DC[i] = r.ReadSingle()/10;
            }

            r.Close();
        }
        
        //Esta función realiza la lectura del archivo .mkr
        //permite leer las marcas para luego determinar
        //los angulos del la señal de estimulo
        private void readMKR(string direccion)
        {            
            int i=0;
            long tam=0;
            int[] Marcas1=new int [CantPuntos];
            byte[] IDMarcas1 = new byte[CantPuntos];         
            

            direccion = direccion.Replace(".inf", ".mrk");
            FileStream inputStream = File.OpenRead(@direccion);
            BinaryReader r = new BinaryReader(inputStream);

            tam = r.BaseStream.Length;
            //cada vez que se leen las marcas se leen 5 bytes
            for(int j=0;j<tam;j=j+5){                
                IDMarcas1[i] = r.ReadByte();                
                Marcas1[i] = r.ReadInt32();
                i++;
            } 
            r.Close();

            Marcas=new int [i];
            IDMarcas = new byte[i];           

            for(int j=0;j<i;j++){                
                IDMarcas[j] = IDMarcas1[j];                
                Marcas[j] = Marcas1[j];                
            } 
            
            
            }            
            
        }


    public class CSV
    {
        //variables para el trabajo inerno
        bool horizontal = false;
        bool vertical = false;
        bool estimulo = false;
        int H = 0;
        int CantPru = 0; //Cantidad de pruebas
        int[] longitudPru; //Longitud d las pruebas 
        float Zeit = 0;
        int Points = 0;
        float Angulo = 0;

        //Variablews publicas que aportan informacion
        public float[][] SignalsH;
        public float[][] SignalsV;
        public float[][] SignalsE;
        public float[][] Tiempo;

        public string[] NomPruebas;

        public CSV(string direccion)
        {

            prelectura(direccion);

            SignalsH = new float[CantPru][];
            SignalsV = new float[CantPru][];
            SignalsE = new float[CantPru][];
            Tiempo = new float[CantPru][];

            for (int i = 0; i < CantPru; i++)
            {
                SignalsH[i] = new float[longitudPru[i]];
                SignalsV[i] = new float[longitudPru[i]];
                SignalsE[i] = new float[longitudPru[i]];
                Tiempo[i] = new float[longitudPru[i]];
            }

            FileInfo CSVfile = new FileInfo(@direccion);
            StreamReader st = CSVfile.OpenText();
            string text = "";
            string[] tmp;
            int np = 0;
            int index = 0;
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            NomPruebas = new string[CantPru];
            double x;
            int alR = 0;

            while (text != null)
            {
                text = st.ReadLine();
                if (text == null)
                {
                    break;
                }
                else if (text.Contains("Sequenz"))
                {

                    text = text.Replace("Sequenz", "");
                    text = text.Replace("\t", "");
                    NomPruebas[np] = text;
                    np = np + 1;
                    H = 0;
                    horizontal = false;
                    vertical = false;
                    estimulo = false;
                }
                else if (text.Contains("Channel"))
                {
                    index = 0;
                    tmp = text.Split(new Char[] { ' ', '\t' });
                    if (tmp[1].Contains("Horizontal"))
                    {
                        H = H + 1;
                        if (H == 1) { horizontal = true; estimulo = false; vertical = false; }
                        if (H == 2) { estimulo = true; horizontal = false; vertical = false; }
                    }
                    if (tmp[1].Contains("Vertical") || tmp[1].Contains("Vertikal"))
                    {
                        vertical = true; horizontal = false; estimulo = false;
                    }
                }
                else if (text.Contains("OKN angle"))
                {
                    tmp = text.Split(new Char[] { ' ', '\t' });
                    if (tmp[1] == "angle")
                    {
                        Angulo = float.Parse(tmp[2], nfi);
                        if (NomPruebas[np - 1].Contains("Calibration ver")) {
                            NomPruebas[np - 1] = "Calibración vertical " + Angulo + "º";
                        }
                        if (NomPruebas[np - 1].Contains("Calibration")){
                            NomPruebas[np - 1] = "Calibración " + Angulo + "º";
                        }
                        if(NomPruebas[np -1].Contains("Test")) { NomPruebas[np - 1] = "Prueba " + Angulo + "º"; }

                        if (np > 2)
                        {                            
                            if (NomPruebas[np-1] == NomPruebas[np - 2]) { NomPruebas[np-1] = NomPruebas[np-2] + " Réplica"; }
                            if (NomPruebas[np - 1] == NomPruebas[np - 3]) { NomPruebas[np - 1] = "Prueba aleatoria"; alR = np +1; }
                            if (alR == np) { NomPruebas[np - 1] = "Prueba aleatoria Réplica";  }
                        }
                    }
                    
                }
                else if (text.Contains("Zeit"))
                {
                    tmp = text.Split(new Char[] { ' ', '\t' });
                    Zeit = float.Parse(tmp[1], nfi);
                }
                else if (text.Contains("Points"))
                {

                    tmp = text.Split(new Char[] { ' ', '\t' });
                    Points = int.Parse(tmp[1]);
                    for (int i = 0; i < Points; i++)
                    {
                        text = st.ReadLine();
                        tmp = text.Split(new Char[] { ' ', '\t' });
                        if (horizontal)
                        {
                            SignalsH[np - 1][index * Points + i] = (float) double.Parse(tmp[1], nfi);
                            x = index * Points;
                            x = x + i;
                            Tiempo[np - 1][index * Points + i] = (float) x / Points;
                        }
                        if (vertical) { SignalsV[np - 1][index * Points + i] = (float) double.Parse(tmp[1], nfi); }
                        if (estimulo) { SignalsE[np - 1][index * Points + i] = (float)double.Parse(tmp[1], nfi)/10; }
                    }

                    index = index + 1;
                }

            } while (text != null) ;
        }

        void prelectura(string direccion)
        {
            FileInfo CSVfile = new FileInfo(@direccion);
            StreamReader st = CSVfile.OpenText();
            string text = "";
            int i = 0;
            int[] temp = new int[1000];
            string[] tmp;

            while (text != null)
            {
                text = st.ReadLine();
                if (text == null)
                {
                    break;
                }
                else if (text.Contains("Sequenz"))
                {
                    CantPru++;
                    i = 0;
                }
                else if (text.Contains("Channel"))
                {
                    i++;
                }
                else if (text.Contains("Points") && i == 1)
                {
                    tmp = text.Split(new Char[] { ' ', '\t' });
                    temp[CantPru - 1] = temp[CantPru - 1] + int.Parse(tmp[1]);
                }
            }
            st.Close();
            longitudPru = new int[CantPru];
            for (int j = 0; j < CantPru; j++)
            {
                longitudPru[j] = temp[j];
            }
        }


    }
}
