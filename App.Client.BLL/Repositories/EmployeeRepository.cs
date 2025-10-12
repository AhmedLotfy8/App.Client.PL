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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository {

        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) : base(context) {
            _context = context;
        }

        public async Task<List<Employee>> GetByNameAsync(string name) {
            return await _context.Employees.Include(e => e.Department).Where(e => e.Name.Contains(name.ToLower())).ToListAsync();
        }
    }
}
