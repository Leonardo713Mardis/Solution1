using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataUtils.Models
{
    public class ReporteMovimiento
    {
        public ReporteMovimiento(DateTime Fecha,
         string Cliente, 
         string NumeroCuenta, 
         string Tipo, 
         decimal SaldoInicial, 
         string Estado, 
         decimal Movimiento, 
         decimal SaldoDisponible)
        {
            this.Fecha = Fecha;
            this.Cliente = Cliente;
            this.NumeroCuenta = NumeroCuenta;
            this.Tipo = Tipo;
            this.SaldoInicial = SaldoInicial;
            this.Estado = Estado;
            this.Movimiento = Movimiento;
            this.SaldoDisponible = SaldoDisponible;
        }

        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }

    }
}

