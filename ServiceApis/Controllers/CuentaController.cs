using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using DataBusiness.Negocio;
using Entities;
using DataUtils.Utils;
using DataUtils.Models;

namespace ServiceApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : AController<CuentaController>
    {

        private readonly CuentaBusiness cuentaBusiness;

        public CuentaController(PruebaContext pruebaContext, IMapper mapper) : base(pruebaContext, mapper)
        {
            cuentaBusiness = new CuentaBusiness(pruebaContext, mapper);
        }

        // private readonly IMapper _mapper;

        [HttpGet]
        [Route("AllCuenta")]
        public async Task<IActionResult> AllCuenta()
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                
                var data = cuentaBusiness.GetAllCuentas();

                reply.status = "Ok";
                reply.messege = "Item Guardado";
                reply.data = data;

                return Ok(reply);
            }
            catch (Exception e)
            {
                reply.data = null;
                reply.status = "Fail";
                reply.messege = e.Message;
                return Ok(reply);

            }
        }

        [HttpPost]
        [Route("InsertarCuenta")]
        public async Task<IActionResult> InsertarCuenta(CuentaM cuenta, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = cuentaBusiness.GuardarCuenta(cuenta, transaccion);

                if (bandera)
                {
                    reply.status = "Ok";
                    reply.messege = "Item Guardado Correctamente";
                    reply.data = bandera;
                }
                else
                {
                    reply.status = "Fail";
                    reply.messege = "Algo a ido mal";
                    reply.data = bandera;
                }

                return Ok(reply);
            }
            catch (Exception e)
            {
                reply.data = null;
                reply.status = "Exception Error";
                reply.messege = e.Message;
                return Ok(reply);

            }
        }

        [HttpPut]
        [Route("ActualizarCuenta")]
        public async Task<IActionResult> ActualizarCuenta(CuentaM cuenta, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = cuentaBusiness.GuardarCuenta(cuenta, transaccion);

                if (bandera)
                {
                    reply.status = "Ok";
                    reply.messege = "Item Guardado Correctamente";
                    reply.data = bandera;
                }
                else
                {
                    reply.status = "Fail";
                    reply.messege = "Algo a ido mal";
                    reply.data = bandera;
                }

                return Ok(reply);
            }
            catch (Exception e)
            {
                reply.data = null;
                reply.status = "Exception Error";
                reply.messege = e.Message;
                return Ok(reply);

            }
        }

        [HttpDelete]
        [Route("BorrarCuenta")]
        public async Task<IActionResult> BorrarCuenta(CuentaM cuenta, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = cuentaBusiness.GuardarCuenta(cuenta, transaccion);

                if (bandera)
                {
                    reply.status = "Ok";
                    reply.messege = "Item Eliminado Correctamente";
                    reply.data = bandera;
                }
                else
                {
                    reply.status = "Fail";
                    reply.messege = "Algo a ido mal";
                    reply.data = bandera;
                }

                return Ok(reply);
            }
            catch (Exception e)
            {
                reply.data = null;
                reply.status = "Exception Error";
                reply.messege = e.Message;
                return Ok(reply);

            }
        }

    }
}

