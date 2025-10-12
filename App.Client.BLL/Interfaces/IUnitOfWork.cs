using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL.Interfaces {
    public interface IUnitOfWork : IAsyncDisposable {

        public IDepartmentRepository DepartmentRespository { get; }
        public IEmployeeRepository EmployeeRespository { get; }

        Task<int> CompleteAsync();
    }
}
