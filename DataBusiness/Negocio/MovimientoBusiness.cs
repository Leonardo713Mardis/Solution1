using AutoMapper;
using DataAccess.Dao;
using DataUtils.Models;
using Entities;
using Entities.Entidades;
using System;
using System.Collections.Generic;

namespace DataBusiness.Negocio
{
    public class MovimientoBusiness : ABusiness
    {
        protected MovimientoDao movimientoDao;
        protected CuentaDao cuentaDao;
        protected ReporteDao reporteDao;
        public MovimientoBusiness(PruebaContext _PruebaContext,
                                     IMapper mapper) : base(_PruebaContext, mapper)
        {
            movimientoDao = new MovimientoDao(_PruebaContext);
            cuentaDao = new CuentaDao(_PruebaContext);
            reporteDao = new ReporteDao(_PruebaContext);
        }

        public object GetAllMovimientos()
        {
            return movimientoDao.GetMovimientos();
        }

        public bool GuardarMovimiento(MovimientoM movimiento, string transaccion)
        {
            bool bandera = true;
            try
            {
                Movimiento itemM = new Movimiento();
                List<Movimiento> lista = new List<Movimiento>();
                List<Movimiento> listaMovimientos = new List<Movimiento>();

                if (transaccion == "U" || transaccion == "D")
                {
                    itemM.IdMovimiento = movimiento.IdMovimiento;

                }

                
                itemM.Valor = movimiento.Valor;
                itemM.IdCuenta = movimiento.IdCuenta;
                itemM.Tipo = movimiento.Tipo;
                itemM.Fecha = movimiento.Fecha;

                if (transaccion == "I") {
                    lista = movimientoDao.ObtenerMovimientosPorCuenta(itemM.IdCuenta);
                    decimal saldo = cuentaDao.ObtenerSaldoInicial(itemM.IdCuenta);
                    listaMovimientos = movimientoDao.ObtenerMovimientosRetiroDiario(itemM.IdCuenta,System.DateTime.Now);
                    decimal saldoDiario = 0;

                    for (int i = 0; i < listaMovimientos.Count; i++)
                    {
                        saldoDiario = saldoDiario + listaMovimientos[i].Valor;
                    }

                    decimal RetiroMaximoDiario = ((saldoDiario + movimiento.Valor) * -1);

                    if (RetiroMaximoDiario > 1000)
                    {
                        throw new Exception("CUPO DIARIO EXCEDIDO");
                    }

                    for (int i = 0; i < lista.Count; i++)
                    {
                        saldo = saldo + lista[i].Valor;
                    }

                    itemM.Saldo = saldo + movimiento.Valor;

                    if (itemM.Saldo < 0) {
                        throw new Exception("SALDO NO DISPONIBLE");
                    }
                } 
                else { 
                    itemM.Saldo = movimiento.Saldo; 
                }

                

                movimientoDao.InsertUpdateOrDelete(itemM, transaccion);
            }
            catch (Exception e)
            {
                bandera = false;
                throw;
            }
            return bandera;
        }

        public List<ReporteMovimiento> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin,int idcliente)
        {
            List<ReporteMovimiento> lista = new List<ReporteMovimiento>();

            try {
                movimientoDao.Context.Query<Movimiento>("EXEC dbo.sp_generar_reporte @idcliente = " + idcliente.ToString());
                List<Reporte> listaReporte = reporteDao.GetReportePorCliente(fechaInicio, fechaFin, idcliente);

                for (int i = 0; i < listaReporte.Count; i++) {
                    lista.Add(new ReporteMovimiento(
                        listaReporte[i].FECHA,
                        listaReporte[i].CLIENTE,
                        listaReporte[i].NUMEROCUENTA,
                        listaReporte[i].TIPO,
                        listaReporte[i].SALDOINICIAL,
                        listaReporte[i].ESTADO,
                        listaReporte[i].MOVIMIENTO,
                        listaReporte[i].SALDODISPONIBLE
                        ));
                }
                
            }
            catch (Exception e)
            {
                throw;
            }

            return lista;
        }

    }
}

