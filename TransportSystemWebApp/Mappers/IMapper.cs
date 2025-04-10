namespace TransportSystemWebApp.Mappers
{
    public interface IMapper<TIn,TOut>
    {
        TOut Map(TIn inValue);
    }
}
