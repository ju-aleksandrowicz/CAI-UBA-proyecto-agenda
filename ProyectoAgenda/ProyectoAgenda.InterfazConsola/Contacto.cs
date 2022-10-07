using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda.Entidades
{
    public class Contacto
    {
        //constructores: es la forma en la que se crea la instancia de una clase
        public Contacto(string nombre, string apellido, string telefono, string direccion, DateTime fechaNacimiento)
        {
            _nombre = nombre;
            _apellido = apellido;
            _telefono = telefono;
            _direccion = direccion;
            _fechaNacimiento = fechaNacimiento;
            _llamadas = 0;
        }

        //atributos de clase
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _direccion;
        private DateTime _fechaNacimiento;
        private int _llamadas;

        //propiedades (atributos encapsulados)
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public int Llamadas
        {
            get { return _llamadas; }
        }

        //metodos. puede ser funcion si devuelve algo o subrutina si no devuelve nada
        //la firma de un metodo esta compuesta por: visibilidad-tipoDato-nombre-parametros
        public int Edad()
        {
            //implementacion: es lo que ejecutara el metodo, lo que hace
            int edad = (DateTime.Now - _fechaNacimiento).Days / 365;
            return edad;
        }

        public void Llamar()
        {
            _llamadas++;
        }

        public void RestarLlamada()
        {
            _llamadas--;
        }

        public override string ToString()
        {
            return "Nombre: " + this._nombre + "\n" + "Apellido: " + this._apellido + "\n" + "Telefono: " + this._telefono +
                "\n" + "Direccion: " + this._direccion + "\n" + "Fecha de nacimiento: " + this._fechaNacimiento + " (Edad: " + this.Edad() + ")" + "\n" + "Cantidad de llamadas: "
                + this._llamadas + "\n";
        }
    }
}
