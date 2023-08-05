using Core.Entites;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepo : IProducrtRepo
    {

        private readonly StoreContext _context;

        public ProductRepo(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product?>> GetAll()
        {
            return await _context.Products
                .Include(p => p.ProductBrand).Include(p=>p.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(p =>p.Id==id);

        }
    }
}
