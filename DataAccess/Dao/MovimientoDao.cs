using Entities;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao
{
    public class MovimientoDao : ADao
    {
        public MovimientoDao(PruebaContext context)
      : base(context)
        {

        }
        public object GetMovimientos()
        {
            var consulta = from p in Context.Movimientos select p;
            return consulta.ToList();
        }

        public List<Movimiento> ObtenerMovimientosPorCuenta(int idcuenta)
        {
            var consulta = from m in Context.Movimientos where m.IdCuenta == idcuenta select m;
            return consulta.ToList();
        }

        public List<Movimiento> ObtenerMovimientosRetiroDiario(int idcuenta,DateTime fecha)
        {
            var consulta = from m in Context.Movimientos where m.IdCuenta == idcuenta
                           && m.Fecha.Date == fecha.Date
                           && m.Tipo.Equals("0")
                           select m;

            return consulta.ToList();
        }
    }
}
