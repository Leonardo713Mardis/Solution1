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
using DataUtils.Models;
using DataUtils.Utils;

namespace ServiceApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : AController<ClienteController>
    {

        private readonly ClienteBusiness clienteBusiness;

        public ClienteController(PruebaContext pruebaContext, IMapper mapper) : base(pruebaContext, mapper)
        {
            clienteBusiness = new ClienteBusiness(pruebaContext, mapper);
        }

        // private readonly IMapper _mapper;

        [HttpGet]
        [Route("AllClients")]
        public async Task<IActionResult> AllPersons()
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                
                var data = clienteBusiness.GetAllClientes();

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
        [Route("InsertarCliente")]
        public async Task<IActionResult> InsertarCliente(ClienteM cliente,string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = clienteBusiness.GuardarCliente(cliente, transaccion);

                if (bandera) {
                    reply.status = "Ok";
                    reply.messege = "Item Guardado Correctamente";
                    reply.data = bandera;
                }
                else {
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
        [Route("ActualizarCliente")]
        public async Task<IActionResult> ActualizarCliente(ClienteM cliente, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = clienteBusiness.GuardarCliente(cliente, transaccion);

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
        [Route("BorrarCliente")]
        public async Task<IActionResult> BorrarCliente(ClienteM cliente, string transaccion)
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                bool bandera = clienteBusiness.GuardarCliente(cliente, transaccion);

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

