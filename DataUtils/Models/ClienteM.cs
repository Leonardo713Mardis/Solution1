using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataUtils.Models
{
    public class ClienteM
    {
        public ClienteM()
        {

        }

        public int IdCliente { get; set; } = 0;
        public string Contrasena { get; set; }
        public string Estado { get; set; }
        public int IdPersona { get; set; } = 0;
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

    }
}

