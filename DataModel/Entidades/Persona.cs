using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("PERSONA", Schema = "dbo")]
    public class Persona
    {
        [Key]
        public int IDPERSONA { get; set; } = 0;
        public string NOMBRE { get; set; }
        public string GENERO { get; set; }
        public int EDAD { get; set; }
        public string IDENTIFICACION { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }

    }
}

