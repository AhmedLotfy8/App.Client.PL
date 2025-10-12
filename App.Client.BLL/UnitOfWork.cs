using App.Client.BLL.Interfaces;
using App.Client.BLL.Repositories;
using App.Client.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext _context;

        public IDepartmentRepository DepartmentRespository { get; }

        public IEmployeeRepository EmployeeRespository { get; }


        public UnitOfWork(AppDbContext context) {

            _context = context;
            DepartmentRespository = new DepartmentRepository(_context);
            EmployeeRespository = new EmployeeRepository(_context);

        }

        public async Task<int> CompleteAsync() {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync() {
           await _context.DisposeAsync();
        }
    }
}
