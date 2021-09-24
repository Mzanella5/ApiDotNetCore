using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Data
{
    public class ShiftRepository : IRepository
    {
        private readonly DataContext _context;

        public ShiftRepository(DataContext context)
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

        public async Task<Shift> GetShiftByIdAsync(Guid id) 
        {
            IQueryable<Shift> query = _context.shifts.Where(s => s.Id.CompareTo(id) == 0);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Shift>> GetShiftsAsync(){
            return await _context.shifts.Include(s => s.Store).ToListAsync();
        }

        public async Task<List<Shift>> GetShiftsBySearchStringAsync(string searchString)
        {       
            IQueryable<Shift> query =  _context.shifts.Include(s => s.Store);


            if(!String.IsNullOrEmpty(searchString)){
                query = query.Where(s => s.StartAt.ToString().Contains(searchString)
                                    || s.EndAt.ToString().Contains(searchString)
                                    || s.Store.Description.Contains(searchString) 
                                );
            }

            return await query.ToListAsync();
        }
    }
}
