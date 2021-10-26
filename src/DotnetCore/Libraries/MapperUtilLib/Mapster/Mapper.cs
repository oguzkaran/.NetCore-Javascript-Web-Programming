using Mapster;

namespace CSD.Util.Mapper.Mapster
{
    public class Mapper : IMapper
    {
        public D Map<S, D>(S source)
        {
            return source.Adapt<D>();
        }
    }
}
