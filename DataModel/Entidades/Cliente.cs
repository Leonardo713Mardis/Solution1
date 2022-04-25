using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente
    {

        public Cliente()
        {

        }

        [Key]
        public int IdCliente { get; set; } = 0;
        
        public int IdPersona { get; set; }

        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }
        public string Contrasena { get; set; }
        public string Estado { get; set; }
        
    }
}

