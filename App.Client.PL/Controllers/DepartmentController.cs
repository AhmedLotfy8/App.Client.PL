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


        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details") {

            if (id is null) return BadRequest("Invalid Id");

            var department = _departmentReposoitory.Get(id.Value);
            if (department == null) return NotFound(new { StatusCode = 404, message = $"Department with :{id} id is not found" });

            return View(viewName, department);


        }

        [HttpGet]
        public IActionResult Edit(int? id) {

            //if (id is null) return BadRequest("Invalid Id");

            //var department = _departmentReposoitory.Get(id.Value);
            //if (department == null) return NotFound(new { StatusCode = 404, message = $"Department with :{id} id is not found" });



            return Details(id,"Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department model) {


            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();

                var count = _departmentReposoitory.Update(model);
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
        public IActionResult Delete([FromRoute] int id, Department model) {


            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();

                var count = _departmentReposoitory.Delete(model);
                if (count > 0) {
                    return Redirect(nameof(Index));
                }

            }

            return View(model);

        }


    }

}
