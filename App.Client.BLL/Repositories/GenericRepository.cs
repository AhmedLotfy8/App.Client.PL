using App.Client.BLL.Interfaces;
using App.Client.DAL.Data.Contexts;
using App.Client.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL.Repositories {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {

        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() {

            if (typeof(T) == typeof(Employee)) {
                return (IEnumerable<T>) await _context.Employees.Include(e => e.Department).ToListAsync();
            }

            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id) {

            if (typeof(T) == typeof(Employee)) {
                return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id) as T;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T model) {
            await _context.Set<T>().AddAsync(model);
        }

        public void Update(T model) {
            _context.Set<T>().Update(model);
        }
  
        public void Delete(T model) {
            _context.Set<T>().Remove(model);
        }
    }
}
