using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using Inmobiliaria.Helper;
using System.IO;

namespace Inmobiliaria
{
    class Program
    {
        enum TipoDeOperacion {
            Venta = 0,
            Alquiler = 1
        }
        enum TipoDePropiedad
        {
            Departamento = 0,
            Casa = 1,
            Duplex = 2,
            PenthHouse = 3,
            Terreno = 4
        };
        static void Main(string[] args)
        {
            //Console.WriteLine((int)TipoDeOperacion.Venta);   se hace casteo para mostrar valor
            List<Propiedad> propiedades = new List<Propiedad>();


            int op = 0;
            int indice = 0;

            string archivo = "inmueble.csv";
            string archivoBase = "base.csv";
            string ruta = @"B:\C#\TRABAJOS PRACTICOS\tpn10-1\Inmobiliaria\bin\Debug\CSV\";

            do
            {
                Console.WriteLine("\n--- MENU ---\n1 Agregar Propiedad: ");
                Console.WriteLine("2 Eliminar Propiedad: ");
                Console.WriteLine("3 Ver Propiedades Cargadas: ");
                Console.WriteLine("4 Eliminar Todo: ");
                Console.WriteLine("5 Leer BASE CSV: ");
                Console.WriteLine("6 Leer CSV: ");
                Console.WriteLine("7 Generar CSV: ");
                op = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------");
                
                if (op == 1) {
                    propiedades.Add(AgregarPropiedad());
                    Mostrar(propiedades);
                }
                else if (op == 2) {
                    Console.WriteLine("Ingrese indice de propiedad a eliminar: ");
                    indice = Convert.ToInt32(Console.ReadLine());
                    eliminarPropiedad(indice, propiedades);
                    Mostrar(propiedades);
                }
                else if (op == 3)
                {
                    Mostrar(propiedades);
                }
                else if (op == 4)
                {
                    propiedades.Clear();
                    Mostrar(propiedades);
                }
                else if (op == 5)
                {
                    List<string[]> listado = HelperCSV.LeerBaseCSV(ruta, archivoBase, ';');
                    for (int i = 0; i < listado.Count; i++) {
                        propiedades.Add(AgregarPropiedadConBase(listado[i][0], listado[i][1]));
                    }

                }
                else if (op == 6)
                {
                    List<Propiedad> nueva = HelperCSV.LeerCSV(ruta, archivo, ';');
                    Mostrar(nueva);
                }
                else if (op == 7)
                {
                    HelperCSV.EscribirCSV(ruta, archivo, propiedades, ';');
                }
            } while (op != 0);

        }

        public static Propiedad AgregarPropiedad() {
            int tipo = 0;
            var rand = new Random();
            Propiedad PAux = new Propiedad();
            Console.WriteLine("ID: ");
            PAux._id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("OPERACION | 1 VENTA - 2 ALQUILER: ");
            tipo = Convert.ToInt32(Console.ReadLine()) - 1;
            PAux._tipoDeOperacion = ((TipoDeOperacion)tipo).ToString();
            Console.WriteLine("PROPIEDAD | 1 DPTO - 2 CASA - 3 DUPLEX - 4 PENTHHOUSE - 5 TERRENO: ");
            tipo = Convert.ToInt32(Console.ReadLine()) - 1;
            PAux._tipoDePropiedad = ((TipoDePropiedad)tipo).ToString();
            PAux._tamanio = (float)(rand.Next(50, 200) + rand.NextDouble() * 1);
            PAux._banios = rand.Next(1, 5);
            PAux._habitaciones = rand.Next(1, 10);
            Console.WriteLine("DIRECCION: ");
            PAux._domicilio = Console.ReadLine();
            PAux._precio = rand.Next(1000000, 10000000);
            tipo = rand.Next(2);
            if (tipo == 1) { PAux._estado = true; } else { PAux._estado = false; }
            Console.WriteLine("VALOR DEL INMUEBLE: " + PAux.ValorDelInmueble());
            return PAux;
        }
        public static Propiedad AgregarPropiedadConBase(string tipoP, string dir)
        {
            int tipo = 0;
            var rand = new Random();
            Propiedad PAux = new Propiedad();
            Console.WriteLine("ID: ");
            PAux._id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("OPERACION | 1 VENTA - 2 ALQUILER: ");
            tipo = Convert.ToInt32(Console.ReadLine()) - 1;
            PAux._tipoDeOperacion = ((TipoDeOperacion)tipo).ToString();
            PAux._tipoDePropiedad = tipoP;
            PAux._tamanio = (float)(rand.Next(50, 200) + rand.NextDouble() * 1);
            PAux._banios = rand.Next(1, 5);
            PAux._habitaciones = rand.Next(1, 10);
            PAux._domicilio = dir;
            PAux._precio = rand.Next(1000000, 10000000);
            tipo = rand.Next(2);
            if (tipo == 1) { PAux._estado = true; } else { PAux._estado = false; }
            Console.WriteLine("VALOR DEL INMUEBLE: " + PAux.ValorDelInmueble());
            return PAux;
        }
        public static void Mostrar(List<Propiedad> propiedades) {
            Console.Clear();
            int cont = 1;
            foreach (Propiedad elem in propiedades)
            {
                Console.WriteLine("INDICE: {0} | ID: {1}", cont, elem._id);
                Console.WriteLine("OPERACION: " + elem._tipoDeOperacion);
                Console.WriteLine("TIPO: " + elem._tipoDePropiedad);
                Console.WriteLine("TAMANIO: " + elem._tamanio);
                Console.WriteLine("BANIOS: {0} | HABITACIONES:  {1}", elem._banios, elem._habitaciones);
                Console.WriteLine("DIRECCION: " + elem._domicilio);
                Console.WriteLine("PRECIO ESTANDAR: " + elem._precio);
                if (elem._estado) {
                    Console.WriteLine("PROPIEDAD ACTIVA");
                }
                else { Console.WriteLine("PROPIEDAD INACTIVA"); }

                Console.WriteLine("PRECIO INMUEBLE: " + elem.ValorDelInmueble());
                Console.WriteLine("-------------------\n");
                cont++;
            }
        }
        public static void eliminarPropiedad(int indice, List<Propiedad> propiedades){
            propiedades.RemoveAt(indice-1);
        }
    }
}
