using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecParam productSpecParam) : base(x =>

         (string.IsNullOrEmpty(productSpecParam.Search) || x.Name.ToLower().Contains(productSpecParam.Search)) &&
        (!productSpecParam.BrandId.HasValue || x.ProductBrandId == productSpecParam.BrandId) &&
      (!productSpecParam.TypeId.HasValue || x.ProductTypeId == productSpecParam.TypeId))
        {

            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            ApplyPaging(productSpecParam.PageSize * (productSpecParam.PageIndex - 1), productSpecParam.PageSize);

            AddOrderBy(x => x.Name);
            if (!string.IsNullOrEmpty(productSpecParam.Sort))
            {
                switch (productSpecParam.Sort)
                {
                    case "priceAsc": AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderBy(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;

                }
            }


        }

        public ProductSpecification(int id) :base(x=>x.Id==id)
        {

            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);


        }
    }
}
