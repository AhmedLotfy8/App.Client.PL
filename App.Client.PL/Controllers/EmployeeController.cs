using App.Client.BLL.Interfaces;
using App.Client.DAL.Models;
using App.Client.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace App.Client.PL.Controllers {
    public class EmployeeController : Controller {

        private readonly IEmployeeRepository _employeeReposoitory;

        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeReposoitory = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index() {
            var employees = _employeeReposoitory.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model) {

            if (ModelState.IsValid) {
                var employee = new Employee() {
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    HiringDate = model.HiringDate,
                    Email = model.Email,
                    isActive = model.isActive,
                    Salary = model.Salary,
                    isDeleted = model.isDeleted,
                    CreateAt = model.CreateAt
                };

                var count = _employeeReposoitory.Add(employee);

                if (count > 0) {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details") {

            if (id is null) return BadRequest("Invalid Id");

            var employee = _employeeReposoitory.Get(id.Value);
            if (employee == null) return NotFound(new { StatusCode = 404, message = $"Employee with :{id} id is not found" });

            return View(viewName, employee);


        }

        [HttpGet]
        public IActionResult Edit(int? id) {

            //if (id is null) return BadRequest("Invalid Id");

            //var department = _departmentReposoitory.Get(id.Value);
            //if (department == null) return NotFound(new { StatusCode = 404, message = $"Department with :{id} id is not found" });



            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee model) {


            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();

                var count = _employeeReposoitory.Update(model);
                if (count > 0) {
                    return Redirect(nameof(Index));
                }

            }

            return View(model);

        }


        #region //[HttpPost]

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit([FromRoute] int id, UpdateDepartmentDto model) {

        //    if (ModelState.IsValid) {

        //        var department = new Department() {
        //            Id = id,
        //            Name = model.Name,
        //            Code = model.Code,
        //            CreateAt = model.CreateAt,
        //        };

        //        var count = _departmentReposoitory.Update(department);
        //        if (count > 0) {
        //            return Redirect(nameof(Index));
        //        }

        //    }

        //    return View(model);

        //}

        #endregion


        [HttpGet]
        public IActionResult Delete(int? id) {

            //if (id is null) return BadRequest("Invalid Id");

            //var department = _departmentReposoitory.Get(id.Value);
            //if (department == null) return NotFound(new { StatusCode = 404, message = $"Department with :{id} id is not found" });

            return Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee model) {


            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();

                var count = _employeeReposoitory.Delete(model);
                if (count > 0) {
                    return Redirect(nameof(Index));
                }

            }

            return View(model);

        }


    }
}
