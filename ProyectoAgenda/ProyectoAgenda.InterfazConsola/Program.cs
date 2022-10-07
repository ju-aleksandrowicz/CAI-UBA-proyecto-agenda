using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAgenda.Entidades;

namespace ProyectoAgenda.InterfazConsola
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            Validaciones v = new Validaciones();
            Agenda agenda1 = new Agenda("AgendaDeLaEmpresa", "Electronica", 100);
            Contacto contacto1 = new Contacto("Cecilia", "Lopez", "12345678", "Moldes 123", DateTime.Now.AddYears(-35));
            Contacto contacto2 = new Contacto("Juan", "Garcia", "12344565", "Viel 1378", DateTime.Now.AddYears(-20));
            agenda1.Contactos.Add(contacto1);
            agenda1.Contactos.Add(contacto2);

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Elija una opcion:" + Environment.NewLine);
                Console.WriteLine("1 - Mostrar todos los contactos.");
                Console.WriteLine("2 - Agregar nuevo contacto.");
                Console.WriteLine("3 - Registrar nuevo llamado");
                Console.WriteLine("4 - Eliminar contacto.");
                Console.WriteLine("5 - Mostrar contacto frecuente.");
                Console.WriteLine("6 - Salir.");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        foreach (Contacto contacto in agenda1.Contactos)
                        {
                            Console.WriteLine(contacto.ToString());
                        }
                        Console.Write("Pulse cualquier tecla para volver al menu principal...");
                        Console.ReadKey();
                        break;

                    case "2":
                        {
                            Console.Clear();
                            bool flag = false;
                            string nombre = "";
                            string apellido = "";
                            string telefono = "";
                            string direccion = "";
                            DateTime fechaNacimiento = DateTime.Parse("01/01/1900");

                            Console.WriteLine("Para crear un nuevo contacto complete la siguiente información:");
                            do
                            {
                                Console.Write("Nombre: ");
                                nombre = Console.ReadLine();
                                flag = v.validarTexto(nombre);
                                if (!flag)
                                {
                                    Console.WriteLine("El dato ingresado es nulo o vacio, vuelva a intentarlo.");
                                }
                            } while (!flag);

                            flag = false;

                            do
                            {
                                Console.Write("Apellido: ");
                                apellido = Console.ReadLine();
                                flag = v.validarTexto(apellido);
                                if (!flag)
                                {
                                    Console.WriteLine("El dato ingresado es nulo o vacio, vuelva a intentarlo.");
                                }
                            } while (!flag);

                            flag = false;

                            do
                            {
                                Console.Write("Telefono: ");
                                telefono = Console.ReadLine();
                                flag = v.validarTelefono(telefono);
                                if (!flag)
                                {
                                    Console.WriteLine("El dato ingresado no corresponde a un numero telefonico. Ingrese solamente entre 8 y 10" +
                                        "numeros.");
                                }
                            } while (!flag);

                            flag = false;

                            do
                            {
                                Console.Write("Direccion: ");
                                direccion = Console.ReadLine();
                                flag = v.validarTexto(direccion);
                                if (!flag)
                                {
                                    Console.WriteLine("El dato ingresado es nulo o vacio, vuelva a intentarlo.");
                                }
                            } while (!flag);

                            do
                            {
                                Console.Write("Fecha de Nacimiento (dd-MM-yyyy): ");
                                flag = v.validarFechaNac(Console.ReadLine(), ref fechaNacimiento);
                            } while (!flag);

                            Contacto nuevoContacto = new Contacto(nombre, apellido, telefono, direccion, fechaNacimiento);
                            agenda1.Contactos.Add(nuevoContacto);
                            Console.Write(Environment.NewLine + "Contacto agendado! Pulse cualquier tecla para volver al menu principal...");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        Console.Clear();
                        bool flag3 = false;
                        string telefonoRegistrar = "";

                        do
                        {
                            Console.Write("Ingrese el numero de telefono del contacto que llamo: ");
                            telefonoRegistrar = Console.ReadLine();
                            flag3 = v.validarTelefono(telefonoRegistrar);

                            if (!flag3)
                            {
                                Console.WriteLine("El dato ingresado no corresponde a un numero telefonico valido. Ingrese entre 8 y 10 numeros.");
                            }
                        } while (!flag3);

                        foreach (Contacto contactos in agenda1.Contactos.ToList())
                        {
                            if (contactos.Telefono == telefonoRegistrar)
                            {
                                contactos.Llamar();
                                Console.Write(Environment.NewLine + "La llamada se registro con exito. Pulse cualquier tecla para volver al menu principal.");
                                Console.ReadKey();
                            }
                        }

                        break;

                    case "4":
                        Console.Clear();
                        bool flag4 = false;
                        string telefonoEliminar = "";

                        do
                        {
                            Console.Write("Ingrese el numero de telefono del contacto que desea eliminar: ");
                            telefonoEliminar = Console.ReadLine();
                            flag4 = v.validarTelefono(telefonoEliminar);

                            if (!flag4)
                            {
                                Console.WriteLine("El dato ingresado no corresponde a un numero telefonico valido. Ingrese entre 8 y 10 numeros.");
                            }
                        } while (!flag4);

                        foreach (Contacto contactos in agenda1.Contactos.ToList())
                        {
                            if (contactos.Telefono == telefonoEliminar)
                            {
                                agenda1.EliminarContacto(telefonoEliminar);
                                Console.Write(Environment.NewLine + "El contacto se elimino con exito. Pulse cualquier tecla para volver al menu principal.");
                                Console.ReadKey();
                            }
                        }

                        break;

                    case "5":
                        Console.Clear();
                        Contacto contactoFrecuente = agenda1.TraerContactoFrecuente();
                        Console.WriteLine("El contacto mas frecuente, con un total de " + contactoFrecuente.Llamadas + " llamada(s) es:" + Environment.NewLine);
                        Console.WriteLine(contactoFrecuente.ToString());
                        Console.Write(Environment.NewLine + "Pulse cualquier tecla para volver al menu principal...");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.Write(Environment.NewLine + "Pulse cualquier tecla para cerrar esta ventana. Vuelva pronto!");
                        Console.ReadKey();
                        return;
                        break;

                    default:
                        Console.Write(Environment.NewLine + "Error! Asegúrese de elegir una opción entre el 1 y el 6. Pulse una tecla para volver a intentar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
