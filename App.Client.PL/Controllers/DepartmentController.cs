using App.Client.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Client.PL.Controllers {
    public class DepartmentController : Controller {

        private readonly IDepartmentRepository _departmentReposoitory;


        public DepartmentController(IDepartmentRepository departmentReposoitory) {
            _departmentReposoitory = departmentReposoitory;
        }

        [HttpGet]
        public IActionResult Index() {
            var departments = _departmentReposoitory.GetAll();
            return View(departments);
        }


    }
}
