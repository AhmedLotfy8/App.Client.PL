using App.Client.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.BLL.Interfaces {
    public interface IGenericRepository<T> where T : BaseEntity {

        IEnumerable<T> GetAll();

        T? Get(int id);

        void Add(T model);

        void Delete(T model);

        void Update(T model);


    }
}
