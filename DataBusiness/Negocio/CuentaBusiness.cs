using AutoMapper;
using DataAccess.Dao;
using DataUtils.Models;
using Entities;
using Entities.Entidades;
using System;

namespace DataBusiness.Negocio
{
    public class CuentaBusiness : ABusiness
    {
        protected CuentaDao cuentaDao;
        public CuentaBusiness(PruebaContext _PruebaContext,
                                     IMapper mapper) : base(_PruebaContext, mapper)
        {
            cuentaDao = new CuentaDao(_PruebaContext);
        }

        public object GetAllCuentas()
        {
            return cuentaDao.GetCuentas();
        }

        public bool GuardarCuenta(CuentaM cuenta, string transaccion)
        {
            bool bandera = true;
            try
            {
                Cuenta itemC = new Cuenta();

                if (transaccion == "U" || transaccion == "D")
                {
                    itemC.IdCuenta = cuenta.IdCuenta;
                    
                }

                itemC.TipoCuenta = cuenta.TipoCuenta;
                itemC.NumeroCuenta = cuenta.NumeroCuenta;
                itemC.Estado = cuenta.Estado;
                itemC.SaldoInicial = cuenta.SaldoInicial;
                itemC.IdCliente = cuenta.IdCliente;

                cuentaDao.InsertUpdateOrDelete(itemC, transaccion);
            }
            catch (Exception e)
            {
                bandera = false;
                throw;
            }
            return bandera;
        }

    }
}

