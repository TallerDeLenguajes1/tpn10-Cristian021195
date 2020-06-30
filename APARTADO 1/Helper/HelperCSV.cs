using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Linq;

namespace Inmobiliaria.Helper
{
    static public class HelperCSV
    {
        public static void EscribirCSV(string ruta, string archivo, List<Propiedad> propiedades, char caracter) {
            FileStream MiArchivo = new FileStream(ruta + archivo, FileMode.Open);
            StreamReader LecturaMiArchivo = new StreamReader(MiArchivo);
            List<string> _fila = new List<string>();

            foreach (Propiedad _p in propiedades) {
                _fila.Add(_p._id.ToString() + caracter + _p._tipoDePropiedad + caracter + _p._tipoDeOperacion + caracter + _p._tamanio.ToString() + caracter + _p._banios.ToString()+ caracter + _p._habitaciones.ToString()+ caracter + _p._domicilio+ caracter + _p._precio+ caracter + _p._estado.ToString());
            }
            MiArchivo.Close();

            File.WriteAllLines(ruta + archivo, _fila);
        }
        public static List<Propiedad> LeerCSV(string ruta, string archivo, char caracter)
        {
            FileStream MiArchivo = new FileStream(ruta + archivo, FileMode.Open, FileAccess.Read);
            StreamReader LecturaMiArchivo = new StreamReader(MiArchivo);
            List<Propiedad> propiedades = new List<Propiedad>();

            string Linea = "";
            while ((Linea = LecturaMiArchivo.ReadLine()) != null) {
                Propiedad aux = new Propiedad();
                string[] fila = Linea.Split(caracter);
                
                
                aux._id = Convert.ToInt32(fila[0]);
                aux._tipoDePropiedad = fila[1];
                aux._tipoDeOperacion = fila[2];
                aux._tamanio = float.Parse(fila[3]);
                aux._banios= Convert.ToInt32(fila[4]);
                aux._habitaciones = Convert.ToInt32(fila[5]);
                aux._domicilio = fila[6];
                aux._precio= Convert.ToInt32(fila[7]);
                if (fila[8] == "True")
                {
                    aux._estado = true;
                }
                else {
                    aux._estado = false;
                }
                propiedades.Add(aux);
            }
            MiArchivo.Close();
            /*
                private int id;
                private string tipoDePropiedad;
                private string tipoDeOperacion;
                private float tamanio;
                private int banios;
                private int habitaciones;
                private string domicilio;
                private int precio;
                private bool estado;
             */
            return propiedades;
        }
        public static List<string[]> LeerBaseCSV(string ruta, string archivo, char caracter)
        {
            
            FileStream MiArchivo = new FileStream(ruta + archivo, FileMode.Open, FileAccess.Read);
            StreamReader LecturaMiArchivo = new StreamReader(MiArchivo);
            List<string[]> listado = new List<string[]>();
            string Linea = "";
            while ((Linea = LecturaMiArchivo.ReadLine()) != null)
            {
                string[] fila = Linea.Split(caracter);
                listado.Add(fila);
            }
            return listado;
        }
    }
}
