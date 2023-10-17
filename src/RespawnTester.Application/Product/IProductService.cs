namespace RespawnTester.Application.Product
{
    public interface IProductService
    {
        Task CreateProduct(Model.Product product);

        Task<IEnumerable<Model.Product>> GetProductsAll();

        Task UpdateProduct(Model.Product product);

        Task DeleteProduct(Guid productId);
    }
}
