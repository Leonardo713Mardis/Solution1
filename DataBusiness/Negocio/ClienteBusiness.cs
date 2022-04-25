using AutoMapper;
using DataAccess.Dao;
using DataUtils.Models;
using Entities;
using Entities.Entidades;
using System;

namespace DataBusiness.Negocio
{
    public class ClienteBusiness : ABusiness
    {
        protected ClienteDao clienteDao;
        protected PersonaDao personaDao;
        public ClienteBusiness(PruebaContext _PruebaContext,
                                     IMapper mapper) : base(_PruebaContext, mapper)
        {
            clienteDao = new ClienteDao(_PruebaContext);
            personaDao = new PersonaDao(_PruebaContext);
        }

        public object GetAllClientes()
        {
            return clienteDao.GetClientes();
        }

        public bool GuardarCliente(ClienteM cliente,string transaccion) {
            bool bandera = true;
            try
            {
                Cliente itemC = new Cliente();
                Persona itemP = new Persona();

                if (transaccion == "U") {
                    itemP.IDPERSONA = cliente.IdPersona;
                    itemC.IdCliente = cliente.IdCliente;
                }

                if (transaccion == "U" || transaccion == "I")
                {
                    
                        itemP.EDAD = cliente.Edad;
                        itemP.IDENTIFICACION = cliente.Identificacion;
                        itemP.DIRECCION = cliente.Direccion;
                        itemP.GENERO = cliente.Genero;
                        itemP.NOMBRE = cliente.Nombre;
                        itemP.TELEFONO = cliente.Telefono;

                    if (!(cliente.IdPersona != 0 && cliente.IdCliente == 0))
                    {
                        personaDao.InsertUpdateOrDelete(itemP, transaccion);
                        itemC.IdPersona = itemP.IDPERSONA;
                    }
                    else {
                        itemC.IdPersona = cliente.IdPersona;
                    }

                    
                    itemC.Contrasena = cliente.Contrasena;
                    itemC.Estado = cliente.Estado;

                    clienteDao.InsertUpdateOrDelete(itemC, transaccion);
                }

                if (transaccion == "D") {
                    itemP.IDPERSONA = cliente.IdPersona;
                    itemC.IdCliente = cliente.IdCliente;
                    clienteDao.InsertUpdateOrDelete(itemC, transaccion);
                    //personaDao.InsertUpdateOrDelete(itemP, transaccion);
                }
            }
            catch (Exception e) {
                bandera = false;
                throw;
            }
            return bandera;
        }
    }
}

