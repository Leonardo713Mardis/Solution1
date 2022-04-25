using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataUtils.Models
{
    public class MovimientoM
    {

        public MovimientoM()
        {

        }

        public int IdMovimiento { get; set; } = 0;
        public int IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }

    }
}

