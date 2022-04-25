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
using Engine_V2.Libraries;
using DataBusiness.Negocio;
using Entities;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : AController<PersonaController>
    {

        private readonly PersonaBusiness personaBusiness;
        private IHostingEnvironment _Env;

        public PersonaController(PruebaContext pruebaContext, IMapper mapper, IHostingEnvironment envrnmt) : base(pruebaContext, mapper)
        {
            personaBusiness = new PersonaBusiness(pruebaContext, mapper);
            _Env = envrnmt;
        }

        // private readonly IMapper _mapper;

        [HttpGet]
        [Route("AllPersons")]
        public async Task<IActionResult> AllPersons()
        {
            ReplyViewModel reply = new ReplyViewModel();
            try
            {
                
                var data = personaBusiness.GetAllPersonas();

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
        
    }
}

