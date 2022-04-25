using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("Cuenta", Schema = "dbo")]
    public class Cuenta
    {

        public Cuenta()
        {

        }

        [Key]
        public int IdCuenta { get; set; } = 0;
        public int IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }


    }
}

