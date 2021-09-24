using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Data
{
    public class StoreRepository : IRepository
    {
        private readonly DataContext _context;

        public StoreRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Store> GetStoreByIdAsync(Guid id) 
        {
            IQueryable<Store> query = _context.stores.Where(s => s.Id.CompareTo(id) == 0);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Store>> GetStoresAsync(){
            return await _context.stores.Include(x => x.Shifts).ToListAsync();
        }

        public async Task<List<Store>> GetStoresBySearchStringAsync(string searchString)
        {       
            IQueryable<Store> query =  _context.stores.Include(s => s.Shifts);

            if(!String.IsNullOrEmpty(searchString)){
                query = query.Where(s => s.Description.Contains(searchString));
            }

            return await query.ToListAsync();
        }
    }
}
