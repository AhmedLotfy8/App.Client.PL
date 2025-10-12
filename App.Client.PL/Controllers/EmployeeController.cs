using App.Client.BLL.Interfaces;
using App.Client.DAL.Models;
using App.Client.PL.Dtos;
using App.Client.PL.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace App.Client.PL.Controllers {
    public class EmployeeController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(
            IUnitOfWork unitOfWork,
            IMapper mapper) {

            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Index(string? SearchInput) {

            IEnumerable<Employee> employees;

            if (string.IsNullOrEmpty(SearchInput)) {
                employees = await _unitOfWork.EmployeeRespository.GetAllAsync();
            }

            else {
                employees = await _unitOfWork.EmployeeRespository.GetByNameAsync(SearchInput);
            }


            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create() {

            var departments = await _unitOfWork.DepartmentRespository.GetAllAsync();
            ViewData["departments"] = departments;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto model) {

            if (ModelState.IsValid) {

                if (model.Image is not null) {

                    model.ImageName = DocumentSettings.UploadFile(model.Image, "Images");
                }

                var employee = _mapper.Map<Employee>(model);

                await _unitOfWork.EmployeeRespository.AddAsync(employee);
                var count = await _unitOfWork.CompleteAsync();

                if (count > 0) {

                    TempData["Message"] = "Employee is Created!";

                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id, string viewName = "Details") {

            if (id is null) return BadRequest("Invalid Id");

            var employee = await _unitOfWork.EmployeeRespository.GetAsync(id.Value);
            if (employee == null) return NotFound(new { StatusCode = 404, message = $"Employee with :{id} id is not found" });

            return View(viewName, employee);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {

            if (id is null) return BadRequest("Invalid Id");

            var employee = await _unitOfWork.EmployeeRespository.GetAsync(id.Value);
            var departments = await _unitOfWork.DepartmentRespository.GetAllAsync();
            ViewData["departments"] = departments;
            if (employee == null) return NotFound(new { StatusCode = 404, message = $"Department with :{id} id is not found" });

            var dto = _mapper.Map<CreateEmployeeDto>(employee);

            return View(dto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, CreateEmployeeDto model) {


            if (ModelState.IsValid) {


                if (model.ImageName is not null && model.Image is not null) {
                    DocumentSettings.DeleteFile(model.ImageName, "Images");

                }

                if (model.ImageName is not null) {
                    model.ImageName = DocumentSettings.UploadFile(model.Image, "Images");

                }

                var employee = _mapper.Map<Employee>(model);
                employee.Id = id;

                _unitOfWork.EmployeeRespository.Update(employee);
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
        public async Task<IActionResult> Delete([FromRoute] int id, Employee model) {


            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();

                var employee = _mapper.Map<Employee>(model);
                employee.Id = id;

                _unitOfWork.EmployeeRespository.Delete(model);
                var count = await _unitOfWork.CompleteAsync();

                if (count > 0) {

                    if (model.ImageName is not null) {
                        DocumentSettings.DeleteFile(model.ImageName, "Images");

                    }

                    return Redirect(nameof(Index));
                }

            }

            return View(model);

        }


    }
}