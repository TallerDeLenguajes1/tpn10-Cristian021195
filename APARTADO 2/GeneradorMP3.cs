using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MorseSound
{
    public static class GeneradorMP3
    {
        private static string ruta = @"B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\bin\Debug\MP3\";
        private static string rutaMP3A = @"B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\punto.mp3";
        private static string rutaMP3B= @"B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\raya.mp3";
        private static string rutaMP3C = @"B:\C#\TRABAJOS PRACTICOS\tpn10-2\MorseSound\silence.mp3";
        private static string archivo;
        public static DateTime fecha = DateTime.Now;
        public static string Ruta { get => ruta; set => ruta = value; }
        public static string Archivo { get => fecha.ToString("yyyy-MM-dd-HH-mm-ss") + ".mp3"; set => archivo = value; }

        public static void crearAudio(int indice, List<string> listado) {
            string archivo = listado[indice];
            string texto = "";
            //Console.WriteLine(archivo);
            FileStream file = new FileStream(archivo,FileMode.Open, FileAccess.Read);
            StreamReader lectura = new StreamReader(file);

            texto = lectura.ReadLine();
            file.Close();
            lectura.Close();

            byte[] punto = File.ReadAllBytes(rutaMP3A);
            byte[] raya = File.ReadAllBytes(rutaMP3B);
            byte[] silencio = File.ReadAllBytes(rutaMP3C);

            string[] PalabrasMorse = texto.Split('/');
            foreach (string palabraMorse in PalabrasMorse) {
                char[] letraMorse = palabraMorse.ToCharArray();

                using (FileStream mp3Stream = File.OpenWrite(Ruta+Archivo))
                {
                    foreach (char c in letraMorse)
                    {
                        if (c == '.')
                        {
                            mp3Stream.Write(punto, 0, punto.Length);
                        }
                        else if (c == '-')
                        {
                            mp3Stream.Write(raya, 0, raya.Length);
                        }
                        else {
                            mp3Stream.Write(silencio, 0, silencio.Length);
                        }
                    }
                    mp3Stream.Close();//no hace falta hacer flush, close mismo lo hace
                }

            }
        }
    }
}
