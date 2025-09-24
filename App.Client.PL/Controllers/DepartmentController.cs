using App.Client.BLL.Interfaces;
using App.Client.DAL.Models;
using App.Client.PL.Dtos;
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


        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model) {

            if (ModelState.IsValid) {
                var department = new Department() {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };

                var count = _departmentReposoitory.Add(department);

                if (count > 0) {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);
        }


    }
}
