using App.Client.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL.Interfaces {
    public interface IEmployeeRepository {

        IEnumerable<Employee> GetAll();

        Employee? Get(int id);

        int Add(Employee model);

        int Delete(Employee model);

        int Update(Employee model);


    }
}
