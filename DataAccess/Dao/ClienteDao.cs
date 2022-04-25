using Entities;
using System.Linq;

namespace DataAccess.Dao
{
    public class ClienteDao : ADao
    {
        public ClienteDao(PruebaContext context)
      : base(context)
        {

        }
        public object GetClientes()
        {
            var consulta = from p in Context.Clientes select p;
            return consulta.ToList();
        }

    }
}
