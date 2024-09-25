namespace ApiProduct.Services
{
    public interface IHandler<TRequest, TResponse>
    {
        TResponse Handle(TRequest request);
    }
}
