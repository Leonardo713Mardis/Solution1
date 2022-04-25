using AutoMapper;
using DataAccess.Dao;
using Entities;

namespace DataBusiness.Negocio
{
    public class PersonaBusiness : ABusiness
    {
        protected PersonaDao personaDao;
        public PersonaBusiness(PruebaContext _PruebaContext,
                                     IMapper mapper) : base(_PruebaContext, mapper)
        {
            personaDao = new PersonaDao(_PruebaContext);
        }

        public object GetAllPersonas()
        {
            return personaDao.GetPersonas();
        }

    }
}

