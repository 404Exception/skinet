using Core.Entities;

namespace Core.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
    }
}
