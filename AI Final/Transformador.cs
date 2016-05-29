using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Final
{
    public class Transformador
    {
        public List<int> binario;

        public Transformador(string palabra)
        {
            binario = new List<int>();
            //Console.WriteLine("Ingrese una letra");
            //string bi = Convert.ToString(Console.ReadLine());
            int j = palabra.Length;
            int ascii = 0;
            foreach (char letra in palabra)
            {
                ascii = Encoding.GetEncoding(437).GetBytes(palabra)[j - 1];
                int resultado = ascii;
                int conti = 0;
                while (resultado != 0)
                {

                    if (resultado % 2 == 0)
                    {
                        Console.WriteLine("Entro un 0");
                        binario.Insert(0, 0);
                    }
                    else if (resultado % 2 != 0)
                    {
                        Console.WriteLine("Entro un 1");
                        binario.Insert(0, 1);
                    }
                    resultado = (resultado / 2);
                    Console.WriteLine(resultado);
                    conti++;
                }
                while (conti < 8)
                {
                    binario.Insert(0, 0);
                    conti++;
                }
                conti = 0;
                j--;
            }
            //Console.Write("En Binario es: ");

            /*int cont = binario.Count;
            int contEspacios = 0;

            for (int i = 0; i < cont; i++)
            {
                Console.Write(binario.ElementAt(i));
                contEspacios++;
                if (contEspacios == 7)
                {
                    Console.Write(" ");
                    contEspacios = 0;
                    
                }
            }
            Console.ReadLine();*/
        }
    }
}
