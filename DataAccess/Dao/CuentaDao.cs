using Entities;
using System.Linq;

namespace DataAccess.Dao
{
    public class CuentaDao : ADao
    {
        public CuentaDao(PruebaContext context)
      : base(context)
        {

        }
        public object GetCuentas()
        {
            var consulta = from p in Context.Cuentas select p;
            return consulta.ToList();
        }

        public decimal ObtenerSaldoInicial(int idcuenta)
        {
            decimal saldoinicial = 0;

            var consulta = (from c in Context.Cuentas where c.IdCuenta == idcuenta
                           select new {
                SaldoInicial = c.SaldoInicial
            }).ToList();

            if (consulta.Count > 0) {
                saldoinicial = consulta.First().SaldoInicial;
            }
            return saldoinicial;
        }

        
    }
}
