using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MorseSound
{
    public static class GeneradorTXT
    {
        private static string ruta = @"B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\bin\Debug\TXT\";
        private static string archivo;
        public static DateTime fecha = DateTime.Now;
        public static string Ruta { get => ruta; set => ruta = value; }
        public static string Archivo { get => fecha.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"; set => archivo = value; }

        public static void generar(string morse) {
            if (!File.Exists(Ruta+Archivo))
            {
                File.WriteAllText(Ruta + Archivo, morse);
                
            }
        }
    }
}
