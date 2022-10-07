using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda.Entidades
{
    public class Agenda
    {
        public Agenda(string nombre, string tipo, int cantidadMaximaContactos)
        {
            _nombre = nombre;
            _tipo = tipo;
            _contactos = new List<Contacto>();
            _cantidadMaximaContactos = cantidadMaximaContactos;
        }

        private string _nombre;
        private string _tipo;
        private List<Contacto> _contactos;
        private int _cantidadMaximaContactos;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public List<Contacto> Contactos
        {
            get { return _contactos; }
            set { _contactos = value; }
        }

        public int CantidadMaximaContactos
        {
            set { _cantidadMaximaContactos = value; }
        }

        public int CantidadDeRegistros()
        {
            return _contactos.Count;
        }

        public void AgregarContacto(Contacto contacto)
        {
            if (CantidadDeRegistros() < _cantidadMaximaContactos)
            {
                _contactos.Add(contacto);
            }
        }

        public void EliminarContacto(string telefono)
        {
            _contactos.RemoveAll(_contacto => _contacto.Telefono == telefono);
        }

        public Contacto TraerContactoFrecuente()
        {
            Contacto contactoFrecuente = new Contacto("a", "a", "1234567890", "a", DateTime.Parse("01/01/1900"));
            contactoFrecuente.RestarLlamada();

            foreach (Contacto contacto in _contactos)
            {
                if (contacto.Llamadas > contactoFrecuente.Llamadas)
                {
                    contactoFrecuente = contacto;
                }
            }

            return contactoFrecuente;
        }
    }
}