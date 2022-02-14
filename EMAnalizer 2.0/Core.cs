using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilesManager;

namespace Core
{
    public class PDS
    {


        /*Esta función es la encargada de realizar el filtrado Butterworth de cuarto
         orden bidireccional a las señales Horizontal y Vertical. Los coeficientes fueron
         calculados con el MatLab y se necesitó para una mayor precisión trabajar con
         15 cifras significativas.

         El Objetivo de este filtro es eliminar las frecuencias por debajo de 0,1 Hz y
         por encima de 20, 15, 10 7, 5 Hz en dependencia de la frecuencia de corte
         superior seleccionada. El funcionamiento del filtro radica en filtrar en un
         sentido que le llamaremos sentido directo, luego se invierte la señal y vuelve
         a filtrar, a este filtrado le llamamos filtrado inverso y se vuelve a invertir
         la señal y como resultado se obtiene una señal filtrada sin la demora
         experimentada en un filtro unidirecional*/

        public static float[] Filtro(float[] S, int frecuencia)
        {

            double[,] CoefButt =
             {{4.449635394285306e-003, 1.779854157714123e-002, 2.669781236571184e-002, 1.779854157714123e-002,
               4.449635394285306e-003, -2.407274935349086, 2.374544639908003, -1.091252108524924, 1.951765702745716e-001}, //20

              {1.639841756581995e-003, 6.559367026327978e-003, 9.839050539491967e-003, 6.559367026327978e-003,
               1.639841756581995e-003, -2.802210909947914, 3.073647537099283, -1.541841548081946, 2.966423890358894e-001}, //15

              {3.820209607982711e-004, 1.528083843193084e-003, 2.292125764789627e-003, 1.528083843193084e-003,
               3.820209607982711e-004, -3.199773543322434, 3.904214640388427, -2.145231365023407, 4.469026033301862e-001}, //10

              {1.019132141852550e-004, 4.076528567410198e-004, 6.114792851115297e-004, 4.076528567410198e-004,
               1.019132141852550e-004, -3.439325862924433, 4.469854238000242, -2.598705011300003, 5.698072476511594e-001}, //7

              {2.853825900249463e-005, 1.141530360099785e-004, 1.712295540149678e-004, 1.141530360099785e-004,
               2.853825900249463e-005, -3.599340413145598, 4.876343023982070, -2.945988485827448, 6.694424871350162e-001} };  //5

            double b0, b1, b2, b3, b4, a1, a2, a3, a4;
            //Frecuencia 0>>20Hz 1>>15Hz 2>>10Hz 3>>7Hz 4>>5Hz
            b0 = CoefButt[frecuencia, 0]; b1 = CoefButt[frecuencia, 1];
            b2 = CoefButt[frecuencia, 2]; b3 = CoefButt[frecuencia, 3];
            b4 = CoefButt[frecuencia, 4];
            a1 = CoefButt[frecuencia, 5]; a2 = CoefButt[frecuencia, 6];
            a3 = CoefButt[frecuencia, 7]; a4 = CoefButt[frecuencia, 8];

            float[] Filtrada = new float[S.Length];
            double[] y = new double[S.Length];
            double[] tmp = new double[S.Length];

            //FILTRADO
            //PASO BAJO (SENTIDO DIRECTO)
            /*Estos son los coeficientes iniciales del filtro, deben de calcularse antes
            de comenzar el proceso de filtado, pues ellos se corresponde con las condiciones
            iniciales del mismo*/

            if (S != null)
            {
                y[0] = b0 * S[0];
                y[1] = b0 * S[1] + b1 * S[0] - a1 * y[0];
                y[2] = b0 * S[2] + b1 * S[1] + b2 * S[0] - a1 * y[1] - a2 * y[0];
                y[3] = b0 * S[3] + b1 * S[2] + b2 * S[1] + b3 * S[0] - a1 * y[2] - a2 * y[1] - a3 * y[0];

                for (int i = 4; i < S.Length; i++)
                {
                    y[i] = b0 * S[i] + b1 * S[i - 1] + b2 * S[i - 2] + b3 * S[i - 3] + b4 * S[i - 4] - a1 * y[i - 1] - a2 * y[i - 2] - a3 * y[i - 3] - a4 * y[i - 4];
                }

                for (int i = 0; i < y.Length; i++)
                {
                    tmp[i] = y[y.Length - i - 1];
                }


                y[0] = b0 * tmp[0];
                y[1] = b0 * tmp[1] + b1 * tmp[0] - a1 * y[0];
                y[2] = b0 * tmp[2] + b1 * tmp[1] + b2 * tmp[0] - a1 * y[1] - a2 * y[0];
                y[3] = b0 * tmp[3] + b1 * tmp[2] + b2 * tmp[1] + b3 * tmp[0] - a1 * y[2] - a2 * y[1] - a3 * y[0];

                for (int i = 4; i < tmp.Length; i++)
                {
                    y[i] = b0 * tmp[i] + b1 * tmp[i - 1] + b2 * tmp[i - 2] + b3 * tmp[i - 3] + b4 * tmp[i - 4] - a1 * y[i - 1] - a2 * y[i - 2] - a3 * y[i - 3] - a4 * y[i - 4];
                }

                for (int i = 0; i < y.Length; i++)
                {
                    tmp[i] = y[y.Length - i - 1];
                }
                //Paso alto 0.01 Hz
                y[0] = 0.9959995364449638 * tmp[0];
                y[1] = 0.9959995364449638 * tmp[1] - 3.983998145779855 * tmp[0] + 3.991983031580642 * y[0];
                y[2] = 0.9959995364449638 * tmp[2] - 3.983998145779855 * tmp[1] + 5.975997218669782 * tmp[0] + 3.991983031580642 * y[1] - 5.975981215005247 * y[0];
                y[3] = 0.9959995364449638 * tmp[3] - 3.983998145779855 * tmp[2] + 5.975997218669782 * tmp[1] - 3.983998145779855 * tmp[0] + 3.991983031580642 * y[2] - 5.975981215005247 * y[1] + 3.976013259934948 * y[0];

                for (int i = 4; i < tmp.Length; i++)
                {
                    y[i] = 0.9959995364449638 * tmp[i] - 3.983998145779855 * tmp[i - 1] + 5.975997218669782 * tmp[i - 2] - 3.983998145779855 * tmp[i - 3] + 0.9959995364449638 * tmp[i - 4] + 3.991983031580642 * y[i - 1] - 5.975981215005247 * y[i - 2] + 3.976013259934948 * y[i - 3] - 0.9920150765985827 * y[i - 4];
                }

                for (int i = 0; i < y.Length; i++)
                {
                    tmp[i] = y[y.Length - i - 1];
                }

                y[0] = 0.9959995364449638 * tmp[0];
                y[1] = 0.9959995364449638 * tmp[1] - 3.983998145779855 * tmp[0] + 3.991983031580642 * y[0];
                y[2] = 0.9959995364449638 * tmp[2] - 3.983998145779855 * tmp[1] + 5.975997218669782 * tmp[0] + 3.991983031580642 * y[1] - 5.975981215005247 * y[0];
                y[3] = 0.9959995364449638 * tmp[3] - 3.983998145779855 * tmp[2] + 5.975997218669782 * tmp[1] - 3.983998145779855 * tmp[0] + 3.991983031580642 * y[2] - 5.975981215005247 * y[1] + 3.976013259934948 * y[0];

                for (int i = 4; i < tmp.Length; i++)
                {
                    y[i] = 0.9959995364449638 * tmp[i] - 3.983998145779855 * tmp[i - 1] + 5.975997218669782 * tmp[i - 2] - 3.983998145779855 * tmp[i - 3] + 0.9959995364449638 * tmp[i - 4] + 3.991983031580642 * y[i - 1] - 5.975981215005247 * y[i - 2] + 3.976013259934948 * y[i - 3] - 0.9920150765985827 * y[i - 4];
                }

                for (int i = 0; i < y.Length; i++)
                {
                    tmp[i] = y[y.Length - i - 1];
                }

            }
            else return S;

            for (int i = 0; i < y.Length; i++)
            {
                Filtrada[i] = (float)tmp[i];
            }

            return Filtrada;
        }

        
        /* This function returns the first derivate of the array (signal) received as parameter*/
        public static float[] Derivate(float[] S)
        {
            float[] SDerivada = new float[S.Length];

            for (int i = 1; i < S.Length; i++)
            {
                SDerivada[i] = S[i] - S[i - 1];
            }
            SDerivada[0] = SDerivada[1];
            return SDerivada;
        }

		
        /* This function perfoms the sacade detection*/
        public static int[] SacadeDet(float[] Signal, float[] Stimulus)
        {
            float[] DSignal = Derivate(Signal);
            float[] DStimulus = Derivate(Stimulus);
            int cont = 0;
            int[] PMaxDStimulus;
            int[] Sacades;
            int PMaxDSignal = 0;
            int pto, PMinDS = 0;

            for (int i = 0; i < DStimulus.Length; i++)
            {
                if (DStimulus[i] != 0) cont++;
            }

            PMaxDStimulus = new int[cont];
            Sacades = new int[cont * 2];

            cont = 0;
            for (int i = 0; i < DStimulus.Length; i++)
            {
                if (DStimulus[i] != 0)
                {
                    PMaxDStimulus[cont] = i;
                    cont++;
                }

            }

            for (int i = 0; i < PMaxDStimulus.Length - 1; i++)
            {
                if (DStimulus[PMaxDStimulus[i]] > 0)
                {
                    PMaxDSignal = PMaxDStimulus[i];
                    for (int j = PMaxDStimulus[i]; j < PMaxDStimulus[i + 1]; j++)
                    {
                        if (DSignal[j] > DSignal[PMaxDSignal]) PMaxDSignal = j;
                    }

                    Sacades[i * 2] = MAreaTriangulo(Signal, PMaxDStimulus[i], PMaxDSignal);

                    PMinDS = PMaxDSignal;
                    /*pto = (int) (PMaxDE[i + 1] - PMaxDE[i]) / 2;
                    pto = pto + PMaxDE[i];*/
                    pto = PMaxDStimulus[i + 1]; //determinar
                    for (int j = PMaxDSignal; j < pto; j++)
                    {
                        if (DSignal[PMinDS] > DSignal[j] && DSignal[j] > 0) PMinDS = j;
                    }
                    Sacades[i * 2 + 1] = MAreaTriangulo(Signal, PMaxDSignal, PMinDS + 5);
                }
                else
                {
                    PMaxDSignal = PMaxDStimulus[i];
                    for (int j = PMaxDStimulus[i]; j < PMaxDStimulus[i + 1]; j++)
                    {
                        if (DSignal[j] < DSignal[PMaxDSignal]) PMaxDSignal = j;
                    }
                    Sacades[i * 2] = MAreaTriangulo(Signal, PMaxDStimulus[i], PMaxDSignal);

                    PMinDS = PMaxDSignal;
                    /*pto = (int)(PMaxDE[i + 1] - PMaxDE[i]) / 2;
                    pto = pto + PMaxDE[i];*/
                    pto = PMaxDStimulus[i + 1];   //determinar                 
                    for (int j = PMaxDSignal; j < pto; j++)
                    {
                        if (DSignal[PMinDS] < DSignal[j] && DSignal[j] < 0) PMinDS = j;
                    }
                    Sacades[i * 2 + 1] = MAreaTriangulo(Signal, PMaxDSignal, PMinDS + 5);
                }
            }

            return Sacades;
        }

        static int MAreaTriangulo(float[] S, int inicio, int fin)
        {
            double la, lb, lc;
            int index = inicio;
            double SP, AreaT, Area = 0;
            //longitud lado fijo
            la = Math.Sqrt((fin - inicio) * (fin - inicio) + (S[fin] - S[inicio]) * (S[fin] - S[inicio]));

            for (int j = inicio; j < fin; j++)
            {
                //Longitud del pto en desde al punto movil (en j)
                lb = Math.Sqrt((j - inicio) * (j - inicio) + (S[j] - S[inicio]) * (S[j] - S[inicio]));
                //Longitud de pto móvil al medio
                lc = Math.Sqrt((fin - j) * (fin - j) + (S[fin] - S[j]) * (S[fin] - S[j]));
                SP = (la + lb + lc) / 2; //Semiperímetro
                AreaT = Math.Sqrt(SP * (SP - la) * (SP - lb) * (SP - lc));
                if (AreaT > Area) { index = j; Area = AreaT; }
            }

            return index;
        }

    }

    public class Test_T
    {
        public string[] NomPrueba;
        public int CantPruebas;
        public float[][] SHorizontal;
        public float[][] SVertical;
        public float[][] SEstimulo;
        public float[][] Tiempo;        
        private int[][] Sacadas;
        private float[][] SacadasY;
        private float[][] SacadasT;
        //Fin de sacada
        public int[][] SacadasF;
        public float[][] SacadasYF;
        public float[][] SacadasTF;
        //Inicio de sacada
        public int[][] SacadasI;
        public float[][] SacadasYI;
        public float[][] SacadasTI;

        //Amplitud de sacadas
        public float[][] ASacadas;

        //Latencia (ms)
        public float[][] Latencia;
        //Cambios ?sacadas en el estimulo
        public int[][] CE;

        public float Fs;
        public int indfh = 2; //Filtro  fh=10 Hz 
        public float Calibracion;
        public float AngCal = 0; //Angulo de calibracion plg=33, csv= 30;  

        public Test_T(string direccion)
        {
            //opcion para los PLG
            if (direccion.Contains(".inf") || direccion.Contains(".INF"))
            {
                PLG plg = new PLG(@direccion);

                AngCal = 30;//ver
                //Fs = plg.FrecMuestreo;
                Fs = 200;
                
                plg.RSignals[0] = PDS.Filtro(plg.RSignals[0], indfh); 
                plg.RSignals[1] = PDS.Filtro(plg.RSignals[1], indfh); 
                MRK2Estimulo(plg.Marcas, plg.IDMarcas, plg); //aqui se distribuyen las señales
                
                //calibracion sacadica
                int cantcal=0;
                for(int ii=0;ii<NomPrueba.Length;ii++){
                    if (NomPrueba[ii].Contains("Calibración")) { cantcal++; }
                }

                if (cantcal == 2)
                {
                    Calibracion = DetCalibracion(SHorizontal[0], SEstimulo[0], SHorizontal[CantPruebas - 1], SEstimulo[CantPruebas - 1]);
                }

                if (cantcal == 1)
                {
                    Calibracion = DetCalibracion(SHorizontal[0], SEstimulo[0]);
                }

                
            }
            //opcion para los CSV
            if (direccion.Contains(".csv") || direccion.Contains(".CSV"))
            {
                
                CSV csv = new CSV(@direccion);
                
                AngCal = 30;
                Fs = (float)204.8;

                CantPruebas = csv.NomPruebas.Length;
                NomPrueba = csv.NomPruebas;
                int CalInd1, CalInd2;
                CalInd1 = -1; CalInd2 = -1;

                SHorizontal = new float[CantPruebas][];
                SVertical = new float[CantPruebas][];
                SEstimulo = csv.SignalsE;
                Tiempo = csv.Tiempo;              
                
                //calibracion sacadica
                for (int i = 0; i < CantPruebas; i++){
                    SHorizontal[i] = PDS.Filtro(csv.SignalsH[i], indfh);  
                    SVertical[i] = PDS.Filtro(csv.SignalsV[i], indfh);
                    if (NomPrueba[i] == "Calibración 30º")
                    {
                        if (CalInd1 == -1) { CalInd1 = i; }
                        else { CalInd2 = i; }
                    }
                }

                Calibracion = DetCalibracion(SHorizontal[CalInd1], SEstimulo[CalInd1], SHorizontal[CalInd2], SEstimulo[CalInd2]);
                                
            }

            //comun en lo adelante
            if (Calibracion < 0) { Calibracion = Calibracion * (-1); }

            Sacadas = new int[CantPruebas][];
            SacadasY = new float[CantPruebas][];
            SacadasT = new float[CantPruebas][];
            CE = new int[CantPruebas][];
            
            for (int i = 0; i < CantPruebas; i++)
            {
                //Ajuste de la señal a grados
                for (int j = 0; j < SHorizontal[i].Length; j++)
                {
                    SHorizontal[i][j] = SHorizontal[i][j] * (Calibracion);
                    SVertical[i][j] = SVertical[i][j] * (Calibracion);
                }

                //Asignación de los puntos de sacadas
                Sacadas[i] = PDS.SacadeDet(SHorizontal[i], SEstimulo[i]);
                CE[i] = PDS.SacadeDet(SEstimulo[i], SEstimulo[i]);

                SacadasY[i] = new float[Sacadas[i].Length];
                SacadasT[i] = new float[Sacadas[i].Length];
                for (int j = 0; j < Sacadas[i].Length; j++)
                {
                    SacadasY[i][j] = SHorizontal[i][(Sacadas[i][j])];
                    SacadasT[i][j] = Tiempo[i][(Sacadas[i][j])];
                }

            }

            //Asignacion de puntos de sacadas pares e impares
            int cont=0;
                      
            SacadasI = new int[CantPruebas][];
            SacadasYI = new float[CantPruebas][];
            SacadasTI = new float[CantPruebas][];

            SacadasF = new int[CantPruebas][];
            SacadasYF = new float[CantPruebas][];
            SacadasTF = new float[CantPruebas][];

            ASacadas = new float[CantPruebas][];
            Latencia = new float[CantPruebas][];

            for (int i = 0; i < CantPruebas; i++) {
                for (int j = 0; j < Sacadas[i].Length; j = j + 2)
                {                    
                    cont++;
                }

                SacadasI[i] = new int[cont];
                SacadasYI[i] = new float[cont];
                SacadasTI[i] = new float[cont];
                Latencia[i] = new float[cont];
                cont = 0;

                for (int j = 0; j < Sacadas[i].Length; j = j + 2) {
                    SacadasI[i][cont] = Sacadas[i][j];
                    SacadasYI[i][cont] = SacadasY[i][j];
                    SacadasTI[i][cont] = SacadasT[i][j];
                    Latencia[i][cont] = (SacadasI[i][cont] - CE[i][j]) * 1000 / Fs ; //ms
                    cont++;
                }
                cont = 0;

                for (int j = 1; j < Sacadas[i].Length; j = j + 2)
                {
                    cont++;
                }

                SacadasF[i] = new int[cont];
                SacadasYF[i] = new float[cont];
                SacadasTF[i] = new float[cont];
                
                cont = 0;

                for (int j = 1; j < Sacadas[i].Length; j = j + 2)
                {
                    SacadasF[i][cont] = Sacadas[i][j];
                    SacadasYF[i][cont] = SacadasY[i][j];
                    SacadasTF[i][cont] = SacadasT[i][j];                    
                    cont++;
                }
                cont = 0;
                ASacadas[i] = new float[(int)SacadasYF[i].Length];
                for (int j = 1; j < SacadasYF[i].Length; j++ )
                {
                    ASacadas[i][j] = SacadasYF[i][j] - SacadasYI[i][j];
                    
                }
                cont = 0;
            }

            
        }

        /*Este metodo se encarga de con las marcas, delimitar las pruebas
         y crear la señal de estimulo*/
        private void MRK2Estimulo(int[] Marcas, byte[] IDMarcas, PLG plg)
        {
            byte MarGhost = 125;  //Offset añadido por el Track Walker (0x7D)
            byte MarBase = 10;   //Base para las marcas de ángulo (10-22)
            byte MarBaseX = 30;   //Base para las marcas de ángulo extendidas (30-42)
            byte MarCalibr = 50;   //Calibración
            byte MarMovRam = 51;   //Movimiento Salto-Rampa //ver pq creo que es sacadico
            byte MarMovSin = 52;   //Movimiento Sinusoidal-Salto
            byte MarPausa = 5;   //Pausa en la estimulación
            byte MarOculta = 6;   //Ocultar estímulo
            byte MarMuestr = 7;   //Mostrar estímulo
            int[] TmpM = new int[Marcas.Length];
            int[] LimPru;
            int[] indLimPru;
            int contPru = 0;
            int cont1, cont = 0;
            int grado = 0;
            bool copiar = false;


            for (int i = 1; i < Marcas.Length - 1; i++)
            {
                TmpM[i] = IDMarcas[i] - MarGhost;
                //TmpM[i] == MarMovRam || TmpM[i] == MarMovSin || TmpM[i] == MarCalibr
                if (TmpM[i] == MarMovRam || TmpM[i] == MarMovSin || TmpM[i] == MarCalibr) { contPru++; }
            }
            //contPru--;
            CantPruebas = contPru;
            SHorizontal = new float[contPru][];
            SVertical = new float[contPru][];
            SEstimulo = new float[contPru][];
            NomPrueba = new string[contPru];
            Tiempo = new float[contPru][];
            LimPru = new int[contPru + 1];
            indLimPru = new int[contPru + 1];
            contPru = 0;

            //variables para determinar el tipo de prueba
            bool calibracionINI = true;
            bool repli10 = false;
            bool repli20 = false;
            bool repli30 = false;
            bool repli60 = false;
            bool repliale = false;

            //bucle para determinar la cantidad y el tipo de pruebas
            for (int i = 1; i < Marcas.Length - 1; i++)
            {
                if (TmpM[i] == MarCalibr)
                {
                    LimPru[contPru] = Marcas[i];
                    indLimPru[contPru] = i;

                    //deteccion de prueba de calibracion
                    if (calibracionINI == true)
                    {
                        calibracionINI = false;
                        NomPrueba[contPru] = "Calibración inicial 30º";
                    }
                    else {
                        NomPrueba[contPru] = "Calibración final 30º";    
                    }
                   

                    contPru++;
                }

                if (TmpM[i] == MarMovRam)
                {
                    LimPru[contPru] = Marcas[i];
                    indLimPru[contPru] = i;
                    int grad1=Math.Abs(DetGrado(TmpM[i + 2], MarBaseX));
                    int grad2=Math.Abs(DetGrado(TmpM[i + 5], MarBaseX));
                    int grad3 = Math.Abs(DetGrado(TmpM[i + 3], MarBaseX));

                    //deteccion 10 g
                    if (grad1 == 5 && grad2 == 5)
                    {
                        if (repli10 == false)
                        {
                            repli10 = true;
                            NomPrueba[contPru] = "Prueba 10º";
                        }
                        else
                        {
                            repli10 = false;
                            NomPrueba[contPru] = "Réplica 10º";
                        }
                    }
                    //deteccion 20g
                    if (grad1 == 10 && grad2 == 10)
                    {
                        if (repli20 == false)
                        {
                            repli20 = true;
                            NomPrueba[contPru] = "Prueba 20º";
                        }
                        else
                        {
                            repli20 = false;
                            NomPrueba[contPru] = "Réplica 20º";
                        }
                    }
                    //deteccion 30g
                    if (grad1 == 15 && grad2 == 15)
                    {
                        if (repli30 == false)
                        {
                            repli30 = true;
                            NomPrueba[contPru] = "Prueba 30º";
                        }
                        else
                        {
                            repli30 = false;
                            NomPrueba[contPru] = "Réplica 30º";
                        }
                    }
                    //deteccion 60g
                    if (grad1 == 30 && grad2 == 30)
                    {
                        if (repli60 == false)
                        {
                            repli60 = true;
                            NomPrueba[contPru] = "Prueba 60º";
                        }
                        else
                        {
                            repli60 = false;
                            NomPrueba[contPru] = "Réplica 60º";
                        }
                    }
                    //deteccion de prueba aleatoria
                    if (grad1 != grad2 || grad3 != grad2 || grad1 != grad3)
                    {
                        if (repliale == false)
                        {
                            repliale = true;
                            NomPrueba[contPru] = "Prueba aleatoria";
                        }
                        else
                        {
                            repliale = false;
                            NomPrueba[contPru] = "Réplica aleatoria";
                        }
                    }

                    contPru++;
                }

            }

            indLimPru[CantPruebas] = Marcas.Length - 3;
            LimPru[CantPruebas] = Marcas[indLimPru[CantPruebas]];

            cont1 = 1;
            for (int i = 0; i < CantPruebas; i++)
            {
                cont = 0;
                SHorizontal[i] = new float[(Marcas[indLimPru[i + 1]-1] - Marcas[indLimPru[i]+1])];
                SVertical[i] = new float[(Marcas[indLimPru[i + 1]-1] - Marcas[indLimPru[i]+1])];
                SEstimulo[i] = new float[(Marcas[indLimPru[i + 1]-1] - Marcas[indLimPru[i]+1])];
                Tiempo[i] = new float[(Marcas[indLimPru[i + 1]-1] - Marcas[indLimPru[i]+1])];

                for (int j = LimPru[i]; j < LimPru[i + 1]; j++)
                {

                    if (Marcas[cont1+1] == j)
                    {
                        grado = DetGrado(TmpM[cont1+1], MarBaseX);
                    }
                    if ((Marcas[indLimPru[i] + 1] <= j) && (Marcas[indLimPru[i + 1]-1] > j))
                    {
                        copiar = true;
                    }
                    else { copiar = false; }



                    if (copiar)
                    {
                        SHorizontal[i][cont] = plg.RSignals[0][j];
                        SVertical[i][cont] = plg.RSignals[1][j];
                        Tiempo[i][cont] = plg.Tiempo[j];
                        SEstimulo[i][cont] = grado;
                        cont++;
                    }

                    if (j == ((Marcas[cont1 + 2]) - 1)) { 
                        cont1++;
                    }
                }
            }

        }

        private int DetGrado(int idmark, int MarBaseX)
        {
            int grado;
            switch (idmark - MarBaseX)
            {
                case 0: grado = -30;
                    break;
                case 1: grado = -25;
                    break;
                case 2: grado = -20;
                    break;
                case 3: grado = -15;
                    break;
                case 4: grado = -10;
                    break;
                case 5: grado = -5;
                    break;
                case 6: grado = 0;
                    break;
                case 7: grado = +5;
                    break;
                case 8: grado = +10;
                    break;
                case 9: grado = +15;
                    break;
                case 10: grado = +20;
                    break;
                case 11: grado = +25;
                    break;
                case 12: grado = +30;
                    break;
                default: grado = -1000;
                    break;
            }
            return grado;
        }

        //Esta funcion devuelve el valor estimado de calibracción en grados
        /*
        private float DetCalibracion(float[] Cal1, float[] Est1, float[] Cal2, float[] Est2)
        {
            
            int[] sacadas1, sacadas2;
            int total1, total2;
            float Cali1, Cali2;
            sacadas1=PDS.DetectaSac(Cal1, Est1);
            sacadas2 = PDS.DetectaSac(Cal2, Est2);

            total1=sacadas1.Length/2;// /2 pq hay inicio y fin
            total2=sacadas2.Length/2;
            

            Cali1=0;
            for (int i = 2; i < sacadas1.Length - 2; i=i+2) {
                Cali1 = Cali1 + Math.Abs(AngCal/(Cal1[sacadas1[i]]- Cal1[sacadas1[i + 1]]) );
            }
            Cali1 = Cali1 / total1;

            Cali2 = 0;
            for (int i = 2; i < sacadas2.Length - 2; i = i + 2)
            {
                Cali2 = Cali2 + Math.Abs( AngCal/(Cal2[sacadas2[i]] - Cal2[sacadas2[i + 1]]));
            }
            Cali2 = Cali2 / total2;

            return ((Cali1 + Cali2) / 2);
        }*/

        //variante2
        private float DetCalibracion(float[] Cal1, float[] Est1, float[] Cal2, float[] Est2)
        {

            int[] sacadas1, sacadas2;
            int total1, total2;
            float Cali1, Cali2;
            sacadas1 = PDS.SacadeDet(Cal1, Est1);
            sacadas2 = PDS.SacadeDet(Cal2, Est2);

            total1 = sacadas1.Length / 2;// /2 pq hay inicio y fin
            total2 = sacadas2.Length / 2;


            Cali1 = 0;
            for (int i = 2; i < sacadas1.Length - 2; i = i + 2)
            {
                Cali1 = Cali1 + Math.Abs((Cal1[sacadas1[i]] - Cal1[sacadas1[i + 1]]));
            }
            Cali1 = Cali1 / total1;

            Cali2 = 0;
            for (int i = 2; i < sacadas2.Length - 2; i = i + 2)
            {
                Cali2 = Cali2 + Math.Abs((Cal2[sacadas2[i]] - Cal2[sacadas2[i + 1]]));
            }
            Cali2 = Cali2 / total2;

            return (30/((Cali1 + Cali2) / 2));
        }

        //Este metodo es igual al anterior pero solo utiliza una calibracion
        private float DetCalibracion(float[] Cal1, float[] Est1)
        {

            int[] sacadas1;
            int total1;
            float Cali1;
            sacadas1 = PDS.SacadeDet(Cal1, Est1);
            

            total1 = sacadas1.Length / 2;
            


            Cali1 = 0;
            for (int i = 2; i < sacadas1.Length - 2; i = i + 2)
            {
                Cali1 = Cali1 + Math.Abs(AngCal / (Cal1[sacadas1[i]] - Cal1[sacadas1[i + 1]]));
            }
            Cali1 = Cali1 / total1;

            

            return (Cali1 );
        }
    }

    public class Statistics {

        //Retorna la media del arreglo (no se considera la primera sacada pq normalmente
        //contiena la mitad de la amplitud real)
        public static float Media(float[] ASac) {
            float media = 0;
            for (int i = 1; i < ASac.Length; i++) {
                media = media + ASac[i];
            }
            media = media / (ASac.Length - 1);
            return media;
        }

        //Desviacion estandart (empieza en la segunda sacada igual, mismas razones)
        public static float DesvStd(float[] ASac) {
            double Desviacion = 0;
            float media = Media(ASac);
            for (int i = 1; i < ASac.Length; i++) {
                Desviacion = Math.Pow((ASac[i] - media), 2);
            }
            Desviacion = Math.Sqrt(Desviacion / (ASac.Length - 2));
            return (float) Desviacion;
        }

        //Desviacion de un Pto con respecto a la media
        public static float Desv(float ASac, float[] S)
        {
            double Desviacion = 0;
            float media = Media(S);

            Desviacion = ASac - media;
            
            return (float)Desviacion;
        }
    }

    public class Point_T
    {
        static public int X = 0;
        static public float Y = 0;
        static public int Pos = -1;
        static public bool ini = false;
        static public bool ptoSel = false;
        static public bool primera = true;

        public static void inicia() {
            X = 0;
            Y = 0;
            Pos = -1;
            ini = false;
            ptoSel = false;
            primera = true;
        }

    }
}
