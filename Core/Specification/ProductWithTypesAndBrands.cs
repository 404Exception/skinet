using Core.Entities;

namespace Core.Specification
{
    public class ProductWithTypesAndBrands : Specification<Product>
    {
        public ProductWithTypesAndBrands(ProductSpecParams productSpec) :
            base(x => 
            (productSpec.BrandId > 0 || x.ProductBrandId == productSpec.BrandId) &&
            (productSpec.TypeId > 0 || x.ProductTypeId == productSpec.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(productSpec.Sort))
            { 
            switch (productSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductWithTypesAndBrands(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
