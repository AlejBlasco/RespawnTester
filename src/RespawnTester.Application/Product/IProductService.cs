namespace RespawnTester.Application.Product
{
    public interface IProductService
    {
        Task<IEnumerable<Model.Product>> GetProductsAll();
    }
}
