using Entities;
using System.Linq;

namespace DataAccess.Dao
{
    public class PersonaDao : ADao
    {
        public PersonaDao(PruebaContext context)
      : base(context)
        {

        }
        public object GetPersonas()
        {
            var consulta = from p in Context.Personas select p;
            return consulta.ToList();
        }

    }
}
