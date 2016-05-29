using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace AI_Final
{
    public partial class Form1 : Form
    {

        
        private Graphics graphics;
        private SpeechRecognitionEngine escuchar = new SpeechRecognitionEngine();
        RedNeuronal neural;
        int x, y;
        private bool ready, drawn;
        Rectangle rectangle;
        Color color;
        int forma;
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            neural = new RedNeuronal();
            ready = drawn = false;
            x = 300; 
            y = 100;
            color = Color.SteelBlue;
            forma = 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            rectangle = new Rectangle(100, 100, 200, 300);
            Brush colores = new SolidBrush(Color.Chocolate);
            graphics.FillRectangle(colores, rectangle);
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            //graphics.Clear(Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rectangle = new Rectangle(200, 200, 200, 300);
            Brush colores = new SolidBrush(Color.SteelBlue);
            graphics.FillEllipse(colores, rectangle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            List<string> cadenas = neural.entrenar();
            foreach(string cadena in cadenas){
                this.richTextBox1.Text += cadena + "\n";
            }
            this.ready = true;
        }

        public void lector(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit palabra in e.Result.Words)
            {
                listBox1.Items.Add(palabra.Text); 
                if(ready)
                {
                    Transformador tr = new Transformador(palabra.Text);
                    List<double> lista = new List<double>();
                    string Binario = "";
                    int cont = 0;
                    for (int i = 0; i < tr.binario.Count; i++)
                    {
                        Binario += tr.binario.ElementAt(i);
                        cont++;
                    }
                    if(Binario.Length <= 72)
                    {
                        if (Binario.Length < 72)
                        {
                            while (Binario.Length <= 72)
                            {
                                Binario += 0;
                            }
                        }
                        
                        char[] entradaNeural = Binario.ToCharArray();
                        for (int i = 0; i < entradaNeural.Length; i++)
                        {
                            lista.Add(Double.Parse(entradaNeural[i].ToString()));
                        }
                        lista = neural.calcularEntrada(lista.ToArray());
                        seleccionarRespuesta(lista);

                    }
                }

                
            }
        }

        private void seleccionarRespuesta(List<double> salida)
        {
            int response = -1;
            for(int i = 0; i < salida.Count; i++)
            {
                if (salida[i] > 0.8)
                {
                    response = i;
                    break;
                }
            }
            //this.listBox1.Items.Add(response);
            switch (response)
            {
                case 0:
                    desplazarIzquierda();
                    break;
                case 1:
                    desplazarDerecha();
                    break;
                case 2:
                    desplazarArriba();
                    break;
                case 3:
                    desplazarAbajo();
                    break;
                case 4:
                    dibujarCuadrado();
                    break;
                case 5:
                    dibujarCirculo();
                    break;
                case 6:
                    dibujarElipse();
                    break;
                case 7: 
                    cambiarRojo();
                    break;
                case 8:
                    cambiarVerde();
                    break;
                case 9:
                    cambiarAzul();
                    break;
                case 10:
                    cambiarAmarillo();
                    break;
                case 11:
                    cambiarNegro();
                    break;                   

            }

        }

        private void dibujarElipse()
        {
            graphics.Clear(Color.White);
            drawn = true;
            rectangle = new Rectangle(x,  y, 200, 300);
            Brush colores = new SolidBrush(color);
            graphics.FillEllipse(colores, rectangle);
            this.forma = 2;
        }

        private void dibujarCuadrado()
        {
            graphics.Clear(Color.White);
            drawn = true;
            rectangle = new Rectangle(x, y, 200, 200);
            Brush colores = new SolidBrush(color);
            graphics.FillRectangle(colores, rectangle);
            this.forma = 1;
        }

        private void dibujarCirculo()
        {
            graphics.Clear(Color.White);
            drawn = true;
            rectangle = new Rectangle(x, y, 200, 200);
            Brush colores = new SolidBrush(color);
            graphics.FillEllipse(colores, rectangle);
            this.forma = 3;
        }

        private void seleccionarForma()
        {
            switch(this.forma)
            {
                case 1: 
                    dibujarCuadrado();
                    break;
                case 2:
                    dibujarElipse();
                    break;
                case 3:
                    dibujarCirculo();
                    break;
                default:
                    break;
            }       
        }

        

        private void desplazarIzquierda()
        {
            if(drawn)
            {
                if (x - 10 > 15) 
                {
                    x -= 10;
                    seleccionarForma();
                }

            }
        }

        private void desplazarDerecha()
        {
            if (drawn)
            {
                if (x + 10 < 800)
                {
                    x += 10;
                    seleccionarForma();
                }

            }
        }

        private void desplazarArriba()
        {
            if (drawn)
            {
                if (y - 10 > 15)
                {
                    y -= 10;
                    seleccionarForma();
                }

            }
        }

        private void desplazarAbajo()
        {
            if (drawn)
            {
                if (y + 10 < 500)
                {
                    y += 10;
                    seleccionarForma();
                }

            }
        }

        private void cambiarAzul()
        {
            if (drawn)
            {
                color = Color.LightSteelBlue;
                seleccionarForma();
            }
            
        }

        private void cambiarAmarillo()
        {
            if (drawn)
            {
                color = Color.Yellow;
                seleccionarForma();
            }

        }

        private void cambiarNegro()
        {
            if (drawn)
            {
                color = Color.Black;
                seleccionarForma();
            }

        }

        private void cambiarVerde()
        {
            if (drawn)
            {
                color = Color.LawnGreen;
                seleccionarForma();
            }

        }

        private void cambiarRojo()
        {
            if (drawn)
            {
                color = Color.Red;
                seleccionarForma();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                escuchar.SetInputToDefaultAudioDevice();
                escuchar.LoadGrammar(new DictationGrammar());
                escuchar.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(lector);
                escuchar.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Hubo un error");
            }
        }
    }
}
