using App.Client.DAL.Models;
using App.Client.PL.Dtos;
using App.Client.PL.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Client.PL.Controllers {
    public class UserController : Controller {

        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string? SearchInput) {

            IEnumerable<UserToReturnDto> users;

            if (string.IsNullOrEmpty(SearchInput)) {

                users = _userManager.Users.Select(u => new UserToReturnDto() {

                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.firstName,
                    LastName = u.lastName,
                    Roles = _userManager.GetRolesAsync(u).Result

                });
            }

            else {
                users = _userManager.Users.Select(u => new UserToReturnDto() {

                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.firstName,
                    LastName = u.lastName,
                    Roles = _userManager.GetRolesAsync(u).Result

                }).Where(u => u.FirstName.ToLower().Contains(SearchInput.ToLower()));
            }


            return View(users);
        }



        [HttpGet]
        public async Task<IActionResult> Details(string? id, string viewName = "Details") {

            if (id is null) return BadRequest("Invalid Id");

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound(new { StatusCode = 404, message = $"User with :{id} id is not found" });

            var dto = new UserToReturnDto() {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.firstName,
                LastName = user.lastName,
                Roles = _userManager.GetRolesAsync(user).Result
            };

            return View(viewName, dto);

        }




        [HttpGet]
        public async Task<IActionResult> Edit(string? id) {

            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, UserToReturnDto model) {


            if (ModelState.IsValid) {


                if (id != model.Id) return BadRequest("Invalid operation");

                var user = await _userManager.FindByIdAsync(id);

                if (user is null) return BadRequest("Invalid operation");

                user.UserName = model.UserName;
                user.firstName = model.FirstName;
                user.lastName = model.LastName;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded) {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> Delete(string? id) {

            return await Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string id, UserToReturnDto model) {


            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest("Invalid operation");

                var user = await _userManager.FindByIdAsync(id);
                if (user is null) return BadRequest("Invalid operation");


                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);

        }






    }
}
