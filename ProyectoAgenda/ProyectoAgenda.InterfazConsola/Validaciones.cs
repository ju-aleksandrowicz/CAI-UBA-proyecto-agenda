using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda.Entidades
{
    public class Validaciones
    {
        public bool validarTexto(string textoParaValidar)
        {
            if (!string.IsNullOrEmpty(textoParaValidar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validarTelefono(string numeroParaValidar)
        {
            int numeroValidado = 0;
            if (!int.TryParse(numeroParaValidar, out numeroValidado))
            {
                return false;
            }
            else if (numeroParaValidar.Length < 8 || numeroParaValidar.Length > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validarFechaNac(string fechaParaValidar, ref DateTime fechaValidada)
        {
            if (!DateTime.TryParse(fechaParaValidar, out fechaValidada))
            {
                return false;
            }
            else if (fechaValidada >= DateTime.Today)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
