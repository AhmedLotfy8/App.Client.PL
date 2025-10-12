﻿using App.Client.BLL.Interfaces;
using App.Client.DAL.Models;
using App.Client.PL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Client.PL.Controllers {
    public class DepartmentController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var departments = await _unitOfWork.DepartmentRespository.GetAllAsync();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto model) {

            if (ModelState.IsValid) {
                var department = new Department() {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };

                await _unitOfWork.DepartmentRespository.AddAsync(department);
                var count = await _unitOfWork.CompleteAsync();

                if (count > 0) {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id, string viewName = "Details") {

            if (id is null) return BadRequest("Invalid Id");

            var department = await _unitOfWork.DepartmentRespository.GetAsync(id.Value);
            if (department == null) return NotFound(new { StatusCode = 404, message = $"Department with :{id} id is not found" });

            return View(viewName, department);


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {

            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, Department model) {

            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();

                _unitOfWork.DepartmentRespository.Update(model);
                var count = await _unitOfWork.CompleteAsync();

                if (count > 0) {
                    return Redirect(nameof(Index));
                }

            }

            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id) {

            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, Department model) {


            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();

                _unitOfWork.DepartmentRespository.Delete(model);
                var count = await _unitOfWork.CompleteAsync();

                if (count > 0) {
                    return Redirect(nameof(Index));
                }

            }

            return View(model);

        }


    }

}
