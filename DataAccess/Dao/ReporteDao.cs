using Entities;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao
{
    public class ReporteDao : ADao
    {
        public ReporteDao(PruebaContext context)
      : base(context)
        {

        }
        public List<Reporte> GetReportePorCliente(DateTime fechaInicio, DateTime fechaFin, int idcliente)
        {
            var consulta = from r in Context.Reportes 
                           where r.IDCLIENTE == idcliente
                           && r.FECHA.Date >= fechaInicio.Date
                           && r.FECHA.Date <= fechaFin.Date
                           select r;
            return consulta.ToList();
        }

    }
}
