using AutoMapper;
//using Services;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ServiceApis.Controllers
{
    public class AController<T> : ControllerBase
    {
        #region variable Class
        protected string TableName;
        protected string ControllerName;
        #endregion
        PruebaContext Context { get; }
        private readonly IConfiguration configuration;
        IMapper _mapper;
        public AController(PruebaContext _PruebaContext, IMapper mapper)
        {
            _mapper = mapper;
            Context = _PruebaContext;
        }
    }
}
