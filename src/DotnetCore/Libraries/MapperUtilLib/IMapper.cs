namespace CSD.Util.Mapper
{
    public interface IMapper
    {
        R Map<T, R>(T t);
    }
}
