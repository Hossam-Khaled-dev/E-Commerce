using Core.Entites;
using Core.interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
       
    {

        private readonly StoreContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepo(StoreContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplaySpecification(spec).CountAsync();

        }

        public async  Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstAsync(x => x.Id == id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplaySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplaySpecification(spec).ToListAsync();
        }

        private IQueryable<T>ApplaySpecification(ISpecification<T> spec)
        {

            return SpecificationEvaluater<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }
    }
}
