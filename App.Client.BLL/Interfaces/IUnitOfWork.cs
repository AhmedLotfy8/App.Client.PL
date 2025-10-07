using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL.Interfaces {
    public interface IUnitOfWork : IDisposable {

        public IDepartmentRepository DepartmentRespository { get; }
        public IEmployeeRepository EmployeeRespository { get; }

        int Complete();
    }
}
