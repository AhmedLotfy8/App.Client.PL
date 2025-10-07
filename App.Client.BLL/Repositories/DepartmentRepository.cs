using App.Client.BLL.Interfaces;
using App.Client.DAL.Data.Contexts;
using App.Client.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL.Repositories {
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository {

        public DepartmentRepository(AppDbContext context) : base(context) {

        }

        //private readonly AppDbContext _context;

        //public DepartmentReposoitory(AppDbContext context) {
        //    _context = context;
        //}

        //public IEnumerable<Department> GetAll() {
        //    return _context.Departments.ToList();
        //}

        //public Department? Get(int id) {
        //    return _context.Departments.Find(id);
        //}

        //public int Add(Department model) {
        //    _context.Departments.Add(model);
        //    return _context.SaveChanges();
        //}

        //public int Update(Department model) {
        //    _context.Departments.Update(model);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Department model) {
        //    _context.Departments.Remove(model);
        //    return _context.SaveChanges();
        //}

    }
}
