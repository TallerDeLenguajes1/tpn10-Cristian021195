using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;


namespace MorseSound
{
    class Program
    {
        static void Main(string[] args)
        {
            int cond =0;
            string input="";
            string ruta = @"B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\bin\Debug\TXT\";
            int Indice = 0;
            List<string> morse = new List<string>();
            do {
                Console.WriteLine("(1) CONVERTIR TEXTO A MORSE: \n(2) GENERAR TXT: \n(3) GENERAR MP3: \n(4) MOSTRAR CONTENIDO /TXT/: \n(0) SALIR: ");
                cond = Convert.ToInt32(Console.ReadLine());

                if (cond == 1) {
                    Console.WriteLine("TEXTO: ");
                    input = Console.ReadLine();
                    input = TraductorAMorse.traduccion(input);
                    Console.WriteLine(input);
                    //funcion 1
                }
                else if(cond == 2){ //B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\bin\Debug\TXT
                    GeneradorTXT.generar(input);
                }
                else if (cond == 3)
                { //B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\bin\Debug\TXT
                    Console.WriteLine("Ingrese el indice del listado para convertir dicho codigo morse a audio: ");
                    Indice = Convert.ToInt32(Console.ReadLine());
                    GeneradorMP3.crearAudio(Indice, morse);
                }
                else if (cond == 4)
                { //B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\bin\Debug\TXT
                    morse = mostrar(ruta);
                }

            } while (cond != 0);
            
        }
        public static List<string> mostrar(string ruta) {
            Console.Clear();
            string[] archivos;
            archivos = Directory.GetFiles(ruta);
            List<string> listado = new List<string>();
            int cont = 0;
            foreach (string e in archivos) {
                Console.WriteLine("({0}) - {1}",cont,e);
                cont++;
            }
            listado = Directory.GetFiles(ruta).ToList();
            return listado;
        }
    }
}
