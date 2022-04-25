using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("Movimiento", Schema = "dbo")]
    public class Movimiento
    {

        public Movimiento()
        {

        }

        [Key]
        public int IdMovimiento { get; set; } = 0;
        public int IdCuenta { get; set; }

        [ForeignKey("IdCuenta")]
        public Cuenta Cuentas { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        
    }
}

