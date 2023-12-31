﻿using Core.Entities;

namespace Core.Specification
{
    public class ProductWithTypesAndBrands : Specification<Product>
    {
        public ProductWithTypesAndBrands(ProductSpecParams productSpec) :
            base(x =>
            (string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search)) &&
            (!productSpec.BrandId.HasValue || x.ProductBrandId == productSpec.BrandId) &&
            (!productSpec.TypeId.HasValue || x.ProductTypeId == productSpec.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpec.PageSize * (productSpec.PageIndex - 1),
                productSpec.PageSize);

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
