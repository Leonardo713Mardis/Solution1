using AutoMapper;
using Entities;

namespace DataBusiness
{
    public abstract class ABusiness
    {
        protected PruebaContext Context { get; }
        protected IMapper _mapper;
        protected ABusiness(PruebaContext _PruebaContext, IMapper mapper)
        {
            Context = _PruebaContext;
            _mapper = mapper;

        }
    }
}
