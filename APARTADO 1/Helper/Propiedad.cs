using System;
using System.Collections.Generic;
using System.Text;

namespace Inmobiliaria.Helper
{
    public class Propiedad
    {
        private int id;
        private string tipoDePropiedad;
        private string tipoDeOperacion;
        private float tamanio;
        private int banios;
        private int habitaciones;
        private string domicilio;
        private int precio;
        private bool estado;

        public int _id { get => id; set => id = value; }
        public string _tipoDePropiedad { get => tipoDePropiedad; set => tipoDePropiedad = value; }
        public string _tipoDeOperacion { get => tipoDeOperacion; set => tipoDeOperacion = value; }
        public float _tamanio { get => tamanio; set => tamanio = value; }
        public int _banios { get => banios; set => banios = value; }
        public int _habitaciones { get => habitaciones; set => habitaciones = value; }
        public string _domicilio { get => domicilio; set => domicilio = value; }
        public int _precio { get => precio; set => precio = value; }
        public bool _estado { get => estado; set => estado = value; }

        public float ValorDelInmueble()
        {
            float valor = 0.0f;
            if (_tipoDeOperacion == "Venta") {
                valor = ((_precio + 10000) * 1.21f) * 1.1f;
            } else if (_tipoDeOperacion == "Alquiler") {
                valor = (_precio * 1.2f) * 1.05f;
            }
            return valor;
        }
        /*public Propiedad(int id, string tipoDePropiedad, string tipoDeOperacion, float tamanio, int banios, int habitaciones, string domicilio, int precio, bool estado) {
            id = _id;
            tipoDePropiedad = _tipoDePropiedad;
            tipoDeOperacion = _tipoDeOperacion;
            tamanio = _tamanio;
            banios = _banios;
            habitaciones = _habitaciones;
            domicilio = _domicilio;
            precio = _precio;
            estado = _estado;
        }
        public static List<Propiedad> conversorAObjeto(List<string[]> Filas) {
            
        }*/


    }
}
