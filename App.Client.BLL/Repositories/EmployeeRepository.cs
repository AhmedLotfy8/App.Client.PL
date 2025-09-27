using App.Client.BLL.Interfaces;
using App.Client.DAL.Data.Contexts;
using App.Client.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL.Repositories {
    public class EmployeeRepository : IEmployeeRepository {
     
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() {
            return _context.Employees.ToList();
        }

        public Employee? Get(int id) {
            return _context.Employees.Find(id);
        }

        public int Add(Employee model) {
            _context.Employees.Add(model);
            return _context.SaveChanges();
        }

        public int Update(Employee model) {
            _context.Employees.Update(model);
            return _context.SaveChanges();
        }

        public int Delete(Employee model) {
            _context.Employees.Remove(model);
            return _context.SaveChanges();
        }


    }
}
