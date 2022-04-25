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
    public class MovimientoController : AController<MovimientoController>
    {

        private readonly MovimientoBusiness movimientoBusiness;

        public MovimientoController(PruebaContext pruebaContext, IMapper mapper) : base(pruebaContext, mapper)
        {
            movimientoBusiness = new MovimientoBusiness(pruebaContext, mapper);
        }

        // private readonly IMapper _mapper;

        [HttpGet]
        [Route("AllMovimientos")]
        public async Task<IActionResult> AllMovimientos()
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                
                var data = movimientoBusiness.GetAllMovimientos();

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

        [HttpGet]
        [Route("Reportes")]
        public async Task<IActionResult> Reportes(string fechas,int idcliente)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                List<string> fechasString = fechas.Split("/").ToList();
                DateTime fechaInicio = System.DateTime.Parse(fechasString[0]);
                DateTime fechaFin = System.DateTime.Parse(fechasString[1]);


                List<ReporteMovimiento> data = movimientoBusiness.ObtenerReporte(fechaInicio, fechaFin, idcliente);

                reply.status = "Ok";
                reply.messege = "Reporte Generado Exitosamente";
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
        [Route("InsertarMovimiento")]
        public async Task<IActionResult> InsertarMovimiento(MovimientoM movimiento, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = movimientoBusiness.GuardarMovimiento(movimiento, transaccion);

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
                reply.error = "Transaccion Fallida";
                return Ok(reply);

            }
        }

        [HttpPut]
        [Route("ActualizarMovimiento")]
        public async Task<IActionResult> ActualizarMovimiento(MovimientoM movimiento, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = movimientoBusiness.GuardarMovimiento(movimiento, transaccion);

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
        [Route("BorrarMovimiento")]
        public async Task<IActionResult> BorrarMovimiento(MovimientoM movimiento, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = movimientoBusiness.GuardarMovimiento(movimiento, transaccion);

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

