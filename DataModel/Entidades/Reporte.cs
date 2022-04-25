using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("Reporte", Schema = "dbo")]
    public class Reporte
    {

        public Reporte()
        {
    
        }

        [Key]
        public int IDMOVIMIENTO { get; set; } = 0;
        public DateTime FECHA { get; set; }
        public string CLIENTE { get; set; }
        public string NUMEROCUENTA { get; set; }
        public string TIPO { get; set; }
        public decimal SALDOINICIAL { get; set; }
        public string ESTADO { get; set; }
        public decimal MOVIMIENTO { get; set; }
        public decimal SALDODISPONIBLE { get; set; }
        public int IDCLIENTE { get; set; }

    }
}

