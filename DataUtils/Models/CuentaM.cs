using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataUtils.Models
{
    public class CuentaM
    {
        public CuentaM()
        {

        }
        public int IdCuenta { get; set; } = 0;
        public int IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Estado { get; set; }

    }
}

