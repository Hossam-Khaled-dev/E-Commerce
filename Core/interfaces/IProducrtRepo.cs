using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
  public interface IProducrtRepo
    {

        Task<IReadOnlyList<Product>> GetAll();
        Task<Product> GetByIdAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetAllBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetAllTypesAsync();


    }
}
